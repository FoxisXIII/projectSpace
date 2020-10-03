using System;
using System.Collections;
using System.Collections.Generic;
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
    private int _pitchInversion = -1;


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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        if (_attachingObject)
            UpdateAttachedObject();
    }

    private void Movement()
    {
        //Pitch
        float mouseAxisY = _pitchInversion * _lookInput.y;
        _pitch += mouseAxisY * pitchRotationalSpeed * Time.deltaTime;
        _pitch = Mathf.Clamp(_pitch, minPitch, maxPitch);
        pitchControllerTransform.localRotation = Quaternion.Euler(_pitch, 0, 0);


        //Yaw
        float mouseAxisX = _lookInput.x;
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
        _verticalSpeed += Physics.gravity.y * Time.deltaTime;
        movement.y = _verticalSpeed * Time.deltaTime;

        float lSpeedMultiplier = 1f;
        if (_runInput)
            lSpeedMultiplier = fastSpeedMultiplier;

        movement *= Time.deltaTime * speed * lSpeedMultiplier;

        CollisionFlags collisionFlags = _characterController.Move(movement);
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

    private void Shoot()
    {
        Ray lCameraRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit lRaycastHit;
        if (Physics.Raycast(lCameraRay, out lRaycastHit, maxDistance, shootLayerMask.value))
            switch (lRaycastHit.collider.tag)
            {
                case "Attachable":
                    _attachingObject = true;
                    _objectAttached = lRaycastHit.collider.gameObject.GetComponent<Rigidbody>();
                    lRaycastHit.collider.gameObject.GetComponent<Collider>().enabled = false;
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

    public void RotatePlayer()
    {
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        Camera.main.transform.Rotate(0,0,180);
        _pitchInversion = 1;
    }

    public void NormalState()
    {
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        Camera.main.transform.Rotate(0,0,180);
        _pitchInversion = -1;
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

    #endregion
}