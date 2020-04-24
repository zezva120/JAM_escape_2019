﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Vector3/Variable")]
public class Vector3Variable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public Vector3 Value;

    public void SetValue(Vector3 value)
    {
        Value = value;
    }

    public void SetValue(Vector3Variable value)
    {
        Value = value.Value;
    }
}
