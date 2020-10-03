using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventController : MonoBehaviour
{
    private List<IEvent> _events;
    private int _index = 0;

    [SerializeField] private TextMeshProUGUI eventText;

    private void Start()
    {
        _events = new List<IEvent> {new TimeEvent(2), new ColorEvent(10), new TimeEvent(10), new GravityEvent(10)};
        StartEvent();
    }

    private void Update()
    {
        if (_events[_index].EndCondition())
        {
            EndEvent();
            StartEvent();
        }

        _events[_index].Update();
    }

    private void EndEvent()
    {
        _events[_index].Destructor();
        _index++;
        if (_index >= _events.Count)
            _index = 0;
    }

    private void StartEvent()
    {
        _events[_index].Initializer();
        eventText.text = _events[_index].EventName();
    }
}