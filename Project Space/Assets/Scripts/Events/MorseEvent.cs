using System;
using UnityEngine;

public class MorseEvent : TimeEvent
{
    private GameObject _morseObject;

    public MorseEvent(float maxTime) : base(maxTime)
    {
        MorseCodeTranslator morse = GameObject.FindObjectOfType<MorseCodeTranslator>();
        _morseObject = morse.gameObject;
        _morseObject.SetActive(false);
        
    }

    public override void Initializer()
    {
        base.Initializer();
        _morseObject.SetActive(true);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Destructor()
    {
        base.Destructor();
        _morseObject.SetActive(false);
    }

    public override string EventName()
    {
        return "Morse Event";
    }
}