using System.Security.Cryptography;
using UnityEngine;

public class GravityEvent : TimeEvent
{
    private Vector3 _initialGravity;
    private Vector3 _floatingGravity;
    private Vector3 _finalGravity;
    private bool _once1;
    private bool _once2;
    private GameObject[] _changeSize;

    public GravityEvent(float maxTime) : base(maxTime)
    {
        _initialGravity = Physics.gravity / 10;
        _floatingGravity = Vector3.zero;
        _finalGravity = Physics.gravity;
        _changeSize = GameObject.FindGameObjectsWithTag("Attachable");
    }

    public override void Initializer()
    {
        base.Initializer();
        Physics.gravity = -_initialGravity;
    }

    public override void Update()
    {
        base.Update();
        if (Timer >= (_maxTime / 10) && !_once1)
        {
            _once1 = true;
            GameController.GetInstance().PlayerController.ResetVerticalSpeed();
            Physics.gravity = _floatingGravity;
            foreach (GameObject gameObject in _changeSize)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        //Random movement
        if (Timer >= (_maxTime / 4) && !_once2)
        {
            _once2 = true;
            Physics.gravity = -_finalGravity;
            foreach (GameObject gameObject in _changeSize)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }

            GameController.GetInstance().PlayerController.InversePlayer();
        }
    }

    public override void Destructor()
    {
        base.Destructor();
        Physics.gravity = _finalGravity;
        GameController.GetInstance().PlayerController.NormalState();
    }

    public override string EventName()
    {
        return "Gravity Event";
    }
}