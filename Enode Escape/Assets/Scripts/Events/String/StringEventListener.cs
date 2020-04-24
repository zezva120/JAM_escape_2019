using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringEventListener : BaseEventListener<string, StringEvent, UnityStringEvent> { }

[System.Serializable]
public class UnityStringEvent : UnityEvent<string> { }
