using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new StringBool Event", menuName = "Events/StringBool")]
public class StringBoolEvent : ScriptableObject
{
    private List<StringBoolEventListener> listeners = new List<StringBoolEventListener>();

    //[Button("Raise")]
    public void Raise(string txt, bool cond)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(txt, cond);
    }

    public void RegisterListener(StringBoolEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(StringBoolEventListener listener)
    { listeners.Remove(listener); }
}
