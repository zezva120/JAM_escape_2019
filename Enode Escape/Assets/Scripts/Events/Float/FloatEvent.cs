using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Float")]
public class FloatEvent : ScriptableObject
{
    private List<FloatEventListener> listeners = new List<FloatEventListener>();

    //[Button("Raise")]
    public void Raise(float num)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(num);
    }

    public void RegisterListener(FloatEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(FloatEventListener listener)
    { listeners.Remove(listener); }
}
