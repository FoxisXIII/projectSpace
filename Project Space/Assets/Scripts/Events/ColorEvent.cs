using UnityEngine;

public class ColorEvent : TimeEvent
{
    private bool _once1;
    private bool _once2;
    private GameObject _invertGameObject;

    public ColorEvent(float maxTime) : base(maxTime)
    {
        _invertGameObject = GameObject.FindGameObjectWithTag("Inversion");
    }

    public override void Initializer()
    {
        base.Initializer();
        _invertGameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Destructor()
    {
        base.Destructor();
        _invertGameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    public override string EventName()
    {
        return "Color Event";
    }
}