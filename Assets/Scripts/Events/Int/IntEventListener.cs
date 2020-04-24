using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntEventListener : MonoBehaviour
{
    public IntEvent Event;
    public UnityIntEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(int num)
    { Response.Invoke(num); }
}

[System.Serializable]
public class UnityIntEvent : UnityEvent<int> { }