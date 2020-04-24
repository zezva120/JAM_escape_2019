using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behaviour/Variable")]
public class BehaviourVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    [SerializeField] Behaviour Value;

    public void SetValue(Behaviour value)
    {
        Value = value;
    }

    public void SetValue(BehaviourVariable value)
    {
        Value = value.Value;
    }

    public Behaviour GetValue()
    {
        return Value;
    }
}
