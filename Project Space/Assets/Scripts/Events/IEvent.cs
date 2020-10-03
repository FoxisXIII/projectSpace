using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public interface IEvent
{
    void Initializer();
    void Update();
    bool EndCondition();

    void Destructor();
    string EventName();
}
