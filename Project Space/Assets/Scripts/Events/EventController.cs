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
        _events = new List<IEvent>
        {
            new TimeEvent(200), new GravityEvent(25),new ForceEvent(10, 2500), new SizeEvent(10, .1f, 10), new MorseEvent(10),
            new ColorEvent(10), new TimeEvent(10)
        };
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