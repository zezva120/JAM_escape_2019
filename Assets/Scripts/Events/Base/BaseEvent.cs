using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEvent<T> : ScriptableObject
{
    private List<IGameEventListener<T>> listeners = new List<IGameEventListener<T>>();
    public List<IGameEventListener<T>> Listeners { get { return listeners; } }
    /*[ReadOnly]
    [SerializeField] List<string> listenersGameobject;*/
    public bool debug;
    //[Button("Raise")]
    public void Raise(T value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(value);
            if (debug)
                Debug.Log(this.name + " a envoyé le signal a " + listeners[i]);
        }
    }

    public void RegisterListener(IGameEventListener<T> listener)
    {
        listeners.Add(listener);
        /*if (!listenersGameobject.Contains(listener.name))
        {
            listenersGameobject.Add(listener.name);
        }*/
    }

    public void UnregisterListener(IGameEventListener<T> listener)
    { listeners.Remove(listener); }
}
