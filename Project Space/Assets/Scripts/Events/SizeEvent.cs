using UnityEngine;

public class SizeEvent : TimeEvent
{
    private GameObject[] _changeSize;
    private float[] _sizesChanged;

    private float _minSize,_maxSize;

    public SizeEvent(float maxTime, float minSize, float maxSize) : base(maxTime)
    {
        _minSize = minSize;
        _maxSize = maxSize;
        _changeSize = GameObject.FindGameObjectsWithTag("Attachable");
        _sizesChanged = new float[_changeSize.Length];
    }

    public override void Initializer()
    {
        base.Initializer();
        for (int i = 0; i < _changeSize.Length; i++)
        {
            float randomSize = Random.Range(_minSize, _maxSize);
            _changeSize[i].transform.localScale *= randomSize;
            _sizesChanged[i] = 1 / randomSize;
        }
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Destructor()
    {
        base.Destructor();
        for (int i = 0; i < _changeSize.Length; i++)
        {
            _changeSize[i].transform.localScale *= _sizesChanged[i];
        }
    }

    public override string EventName()
    {
        return "Size Event";
    }
}