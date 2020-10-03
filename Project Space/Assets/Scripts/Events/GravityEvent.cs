using System.Security.Cryptography;
using UnityEngine;

public class GravityEvent : TimeEvent
{
    private Vector3 _initialGravity;
    private Vector3 _floatingGravity;
    private Vector3 _finalGravity;
    private bool _once1;
    private bool _once2;

    public GravityEvent(float maxTime) : base(maxTime)
    {
        _initialGravity = Physics.gravity / 10;
        _floatingGravity = Vector3.zero;
        _finalGravity = Physics.gravity;
    }

    public override void Initializer()
    {
        base.Initializer();
        Physics.gravity = -_initialGravity;
    }

    public override void Update()
    {
        base.Update();
        if (Timer >= (_maxTime / 25) && !_once1)
        {
            GameController.GetInstance().PlayerController.ResetVerticalSpeed();
            Physics.gravity = _floatingGravity;
            _once1 = true;
        }

        //Random movement
        if (Timer >= (_maxTime / 4) && !_once2)
        {
            Physics.gravity = -_finalGravity;
            _once2 = true;
            GameController.GetInstance().PlayerController.RotatePlayer();
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