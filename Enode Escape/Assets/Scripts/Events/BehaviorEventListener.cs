using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BehaviorEventListener : BaseEventListener<Behaviour, BehaviorEvent, UnityBehaviorEvent> { }

[System.Serializable]
public class UnityBehaviorEvent : UnityEvent<Behaviour> { }