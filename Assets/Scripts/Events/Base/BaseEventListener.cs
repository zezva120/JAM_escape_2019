using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseEventListener<T, E, U> : MonoBehaviour, IGameEventListener<T> where E : BaseEvent<T> where U : UnityEvent<T>
{
    public E Event;
    public U Response;
    public bool debug;

    public void OnEnable()
    { Event.RegisterListener(this); }

    public void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(T value)
    {
        Response.Invoke(value);
        if (debug)
            Debug.Log(this.name + " a reçu le signal de l'event " + Event.name);
    }
}
