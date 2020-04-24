using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectEventListener : MonoBehaviour
{
    public GameObjectEvent Event;
    public UnityGOEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(GameObject gameObject)
    { Response.Invoke(gameObject); }
}

[System.Serializable]
public class UnityGOEvent : UnityEvent<GameObject> { }