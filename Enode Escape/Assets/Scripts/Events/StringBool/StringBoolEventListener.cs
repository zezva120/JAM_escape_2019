using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringBoolEventListener : MonoBehaviour
{
    public StringBoolEvent Event;
    public UnityStringBoolEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(string txt, bool cond)
    { Response.Invoke(txt, cond); }
}

[System.Serializable]
public class UnityStringBoolEvent : UnityEvent<string, bool> { }