using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatEventListener : MonoBehaviour
{
    public FloatEvent Event;
    public UnityFloatEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(float num)
    { Response.Invoke(num); }
}

[System.Serializable]
public class UnityFloatEvent : UnityEvent<float> { }