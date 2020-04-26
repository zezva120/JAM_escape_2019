using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnStartHook : MonoBehaviour
{
    [SerializeField] UnityEvent onAwake;
    [SerializeField] UnityEvent onStart;
    void Awake()
    {
        onAwake.Invoke();
    }
    void Start()
    {
        onStart.Invoke();
    }
}
