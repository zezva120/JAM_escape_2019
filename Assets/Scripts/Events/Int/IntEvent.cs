using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new IntEvent", menuName = "Events/Int")]
public class IntEvent : ScriptableObject
{
    private List<IntEventListener> listeners = new List<IntEventListener>();

    //[Button("Raise")]
    public void Raise(int num)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(num);
    }

    public void RegisterListener(IntEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(IntEventListener listener)
    { listeners.Remove(listener); }
}
