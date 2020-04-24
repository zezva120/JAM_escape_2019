﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameObject/Variable")]
public class GameObjectVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public GameObject Value;

    public void SetValue(GameObject value)
    {
        Value = value;
    }

    public void SetValue(GameObjectVariable value)
    {
        Value = value.Value;
    }

    public GameObject GetGameObject()
    {
        return Value;
    }
}
