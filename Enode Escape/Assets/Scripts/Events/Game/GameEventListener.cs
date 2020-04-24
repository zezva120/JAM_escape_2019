using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : BaseEventListener<Void, GameEvent, UnityVoidEvent> { }

[System.Serializable]
public class UnityVoidEvent : UnityEvent<Void> { }