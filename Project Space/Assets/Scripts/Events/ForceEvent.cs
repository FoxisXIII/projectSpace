using UnityEngine;

public class ForceEvent : TimeEvent
{
    private GameObject[] _changeSize;

    private float _force;

    public ForceEvent(float maxTime, float force) : base(maxTime)
    {
        _force = force;
        _changeSize = GameObject.FindGameObjectsWithTag("Attachable");
    }

    public override void Initializer()
    {
        base.Initializer();
        float randomPositionX = Random.Range(0f, 1f);
        float randomPositionY = Random.Range(0f, 1f);
        float randomPositionZ = Random.Range(0f, 1f);
        for (int i = 0; i < _changeSize.Length; i++)
        {
            _changeSize[i].GetComponent<Rigidbody>()
                .AddForce(new Vector3(randomPositionX, randomPositionY, randomPositionZ) * _force);
        }
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Destructor()
    {
        base.Destructor();
    }

    public override string EventName()
    {
        return "Force Event";
    }
}