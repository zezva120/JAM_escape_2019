using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    UnityEvent onPress;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            onPress.Invoke();
    }
}