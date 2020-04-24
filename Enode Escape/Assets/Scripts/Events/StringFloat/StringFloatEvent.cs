using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new StringFloat Event", menuName = "Events/StringFloat")]
public class StringFloatEvent : ScriptableObject
{

    private List<StringFloatListener> listeners = new List<StringFloatListener>();

    //[Button("Raise")]
    public void Raise(string txt, float number)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(txt, number);
    }

    public void RegisterListener(StringFloatListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(StringFloatListener listener)
    { listeners.Remove(listener); }
}
