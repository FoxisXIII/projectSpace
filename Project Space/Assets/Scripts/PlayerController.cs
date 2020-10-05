using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Object = System.Object;

public class PlayerController : MonoBehaviour, SimpleControls.IGameplayActions
{
    private float _yaw;
    private float _pitch;

    [SerializeField] private float yawRotationalSpeed = 360f;
    [SerializeField] private float pitchRotationalSpeed = 180f;
    [SerializeField] private float minPitch = -80f;
    [SerializeField] private float maxPitch = 50f;

    [SerializeField] private Transform pitchControllerTransform;

    private CharacterController _characterController;
    [SerializeField] private float speed = 10f;

    private float _verticalSpeed;
    private bool _onGround;
    [SerializeField] private float fastSpeedMultiplier = 1.2f;
    [SerializeField] private float jumpSpeed = 10f;
    private SimpleControls _simpleControls;
    private Vector2 _moveInput;
    private Vector2 _lookInput;
    private bool _runInput;

    [SerializeField] private LayerMask shootLayerMask;


    private bool _isObjectAttached;
    private bool _attachingObject;
    private Rigidbody _objectAttached;
    [SerializeField] private Transform attachingTransform;
    [SerializeField] private float attachingObjectSpeed;
    [SerializeField] private Quaternion attachedObjectStartRotation;
    [SerializeField] private float maxDistance;
    private int _yawInversion = 1;

    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject normalUI;
    private bool _stopTime;
    private Item[] _itemsArray;


    // Start is called before the first frame update
    void Awake()
    {
        _simpleControls = new SimpleControls();
        _simpleControls.gameplay.SetCallbacks(this);
        _simpleControls.gameplay.Enable();

        _yaw = transform.rotation.eulerAngles.y;
        _pitch = pitchControllerTransform.localRotation.eulerAngles.x;
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameController.GetInstance().PlayerController = this;
        _itemsArray = new Item[inventoryUI.transform.childCount - 1];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_stopTime)
            Movement();
        if (_attachingObject)
            UpdateAttachedObject();
    }

    private void Movement()
    {
        //Pitch
        float mouseAxisY = -_lookInput.y;
        _pitch += mouseAxisY * pitchRotationalSpeed * Time.deltaTime;
        _pitch = Mathf.Clamp(_pitch, minPitch, maxPitch);
        pitchControllerTransform.localRotation = Quaternion.Euler(_pitch, 0, 0);


        //Yaw
        float mouseAxisX = _yawInversion * _lookInput.x;
        _yaw += mouseAxisX * yawRotationalSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, _yaw, 0);
        //Movement
        Vector3 movement = new Vector3(0, 0, 0);
        float yawInRadians = _yaw * Mathf.Deg2Rad;
        float yaw90InRadians = (_yaw + 90.0f) * Mathf.Deg2Rad;
        Vector3 forward = new Vector3(Mathf.Sin(yawInRadians), 0.0f, Mathf.Cos(yawInRadians));
        Vector3 right = new Vector3(Mathf.Sin(yaw90InRadians), 0.0f, Mathf.Cos(yaw90InRadians));
        if (_moveInput.y > 0)
            movement = forward;
        else if (_moveInput.y < 0)
            movement = -forward;

        if (_moveInput.x > 0)
            movement += right;
        else if (_moveInput.x < 0)
            movement -= right;

        movement.Normalize();
        movement = movement * Time.deltaTime * speed;

        //Gravity
        _verticalSpeed += (Physics.gravity.y * 1.5f) * Time.deltaTime;
        movement.y = _verticalSpeed * Time.deltaTime;

        float lSpeedMultiplier = 1f;
        if (_runInput)
            lSpeedMultiplier = fastSpeedMultiplier;

        movement *= Time.deltaTime * speed * lSpeedMultiplier;

        CollisionFlags collisionFlags = _characterController.Move(movement);
        if (_yawInversion == 1)
        {
            if ((collisionFlags & CollisionFlags.Below) != 0)
            {
                _onGround = true;
                _verticalSpeed = 0.0f;
            }
            else
                _onGround = false;

            if ((collisionFlags & CollisionFlags.Above) != 0 && _verticalSpeed > 0.0f)
                _verticalSpeed = 0.0f;
        }
        else
        {
            if ((collisionFlags & CollisionFlags.Above) != 0)
            {
                _onGround = true;
                _verticalSpeed = 0.0f;
            }
            else
                _onGround = false;

            if ((collisionFlags & CollisionFlags.Below) != 0 && _verticalSpeed > 0.0f)
                _verticalSpeed = 0.0f;
        }
    }

    private void Shoot()
    {
        Ray cameraRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit raycastHit;
        if (Physics.Raycast(cameraRay, out raycastHit, maxDistance, shootLayerMask.value))
            switch (raycastHit.collider.tag)
            {
                case "Attachable":
                    _attachingObject = true;
                    _objectAttached = raycastHit.collider.gameObject.GetComponent<Rigidbody>();
                    raycastHit.collider.gameObject.GetComponent<Collider>().enabled = false;
                    break;
                case "Item":
                    if (AddToItemList(raycastHit.collider.gameObject.GetComponent<ItemMono>())) ;
                    Destroy(raycastHit.collider.gameObject);
                    break;
            }
    }

    private void UpdateAttachedObject()
    {
        Vector3 lEulerAngles = attachingTransform.rotation.eulerAngles;
        if (!_isObjectAttached)
        {
            Vector3 lDirection = attachingTransform.transform.position - _objectAttached.transform.position;
            float lDistance = lDirection.magnitude;
            float lMovement = attachingObjectSpeed * Time.deltaTime;
            _objectAttached.isKinematic = true;
            if (lMovement >= lDistance)
            {
                _isObjectAttached = true;
                _objectAttached.MovePosition(attachingTransform.position);
                _objectAttached.MoveRotation(Quaternion.Euler(0.0f, lEulerAngles.y, lEulerAngles.z));
            }
            else
            {
                lDirection /= lDistance;
                _objectAttached.MovePosition(_objectAttached.transform.position + lDirection * lMovement);
            }
        }
        else
        {
            _objectAttached.MoveRotation(Quaternion.Euler(0.0f, lEulerAngles.y, lEulerAngles.z));
            _objectAttached.MovePosition(attachingTransform.position);
        }
    }

    private void DetachObject(float force)
    {
        _isObjectAttached = false;
        _attachingObject = false;
        _objectAttached.isKinematic = false;
        _objectAttached.gameObject.GetComponent<Collider>().enabled = true;
        _objectAttached.AddForce(attachingTransform.forward * force);
        _objectAttached = null;
    }

    public void ResetVerticalSpeed()
    {
        _verticalSpeed = 0;
    }

    public void InversePlayer()
    {
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        // StartCoroutine(RotatePlayer(180, 50));
        _yawInversion = -1;
    }

    public void NormalState()
    {
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        Camera.main.transform.Rotate(0, 0, 180);
        _yawInversion = 1;
    }

    // private IEnumerator RotatePlayer(float angle, float speed)
    // {
    //     while (Camera.main.transform.rotation.z != -1)
    //     {
    //         Debug.Log(Camera.main.transform.rotation.z);
    //         Camera.main.transform.Rotate(0, 0, speed * Time.deltaTime);
    //         yield return new WaitForSeconds(Time.deltaTime);
    //     }
    // }
    private bool AddToItemList(ItemMono itemMono)
    {
        for (int i = 0; i < _itemsArray.Length; i++)
        {
            if (_itemsArray[i] == null)
            {
                _itemsArray[i] = new Item(itemMono.inventoryImage, itemMono.name);
                return true;
            }
        }

        return false;
    }

    private void ReloadInventory()
    {
        for (int i = 0; i < _itemsArray.Length; i++)
        {
            if (_itemsArray[i] != null)
            {
                var uiChild = inventoryUI.transform.GetChild(i + 1);
                uiChild.GetComponent<Image>().sprite = _itemsArray[i].inventoryImage;
                uiChild.GetComponent<Button>().interactable = true;
            }
        }
    }

    #region Input

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (_onGround && context.performed)
            _verticalSpeed = jumpSpeed;
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (_onGround && context.performed)
            _runInput = true;

        else if (context.canceled)
            _runInput = false;
    }

    public void OnAttach(InputAction.CallbackContext context)
    {
        if (context.performed)
            if (_attachingObject)
                DetachObject(0);
            else
                Shoot();
    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        if (context.performed)
            if (_attachingObject)
                DetachObject(1000);
            else
                Shoot();
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            normalUI.SetActive(inventoryUI.activeInHierarchy);
            inventoryUI.SetActive(!normalUI.activeInHierarchy);
            if (inventoryUI.activeInHierarchy)
            {
                Time.timeScale = 0;
                _stopTime = true;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;
                _stopTime = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void OnSaveInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
            ReloadInventory();
        }
    }

    #endregion
}