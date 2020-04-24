using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collider2DEventListener : BaseEventListener<Collider2D, Collider2DEvent, UnityCollider2DEvent> { }

[System.Serializable]
public class UnityCollider2DEvent : UnityEvent<Collider2D> { }