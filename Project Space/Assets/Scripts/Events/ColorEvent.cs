using UnityEngine;

public class ColorEvent : TimeEvent
{
    private bool _once1;
    private bool _once2;
    private Material _invertMaterial;

    public ColorEvent(float maxTime) : base(maxTime)
    {
        _invertMaterial = GameObject.FindGameObjectWithTag("Inversion").GetComponent<MeshRenderer>().material;
    }

    public override void Initializer()
    {
        base.Initializer();
    }

    public override void Update()
    {
        base.Update();
        if (Timer <= 1)
        {
            _invertMaterial.color = new Color(1, 1, 1, 1) * Timer;
        }

        if (Timer >= _maxTime)
        {
            _invertMaterial.color = new Color(1, 1, 1, 1) * (_maxTime - Timer);
        }
    }

    public override void Destructor()
    {
        base.Destructor();
        _invertMaterial.color = new Color(1, 1, 1, 1);
    }

    public override string EventName()
    {
        return "Color Event";
    }
}