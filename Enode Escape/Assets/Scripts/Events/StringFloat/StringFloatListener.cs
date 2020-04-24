using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringFloatListener : MonoBehaviour
{
    public StringFloatEvent Event;
    public UnityStringFloatEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(string txt, float number)
    { Response.Invoke(txt, number); }
}

[System.Serializable]
public class UnityStringFloatEvent : UnityEvent<string,float> { }
