using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vector2EventListener : BaseEventListener<Vector2, Vector2Event, UnityVector2Event> { }

[System.Serializable]
public class UnityVector2Event : UnityEvent<Vector2> { }