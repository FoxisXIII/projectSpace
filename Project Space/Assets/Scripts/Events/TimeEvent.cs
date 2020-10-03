using UnityEngine;

public class TimeEvent : EventAbstract
{
    protected float Timer;
    protected readonly float _maxTime;

    public TimeEvent(float maxTime)
    {
        _maxTime = maxTime;
        Timer = 0;
    }

    public override void Update()
    {
        Timer += Time.deltaTime;
    }

    public override bool EndCondition()
    {
        return Timer >= _maxTime;
    }

    public override void Destructor()
    {
        Timer = 0;
    }

    public override string EventName()
    {
        return "Time Event";
    }
}