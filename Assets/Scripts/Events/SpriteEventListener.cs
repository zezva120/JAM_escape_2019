using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class SpriteEventListener : BaseEventListener<Sprite, SpriteEvent, UnitySpriteEvent> { }
[System.Serializable]
public class UnitySpriteEvent : UnityEvent<Sprite> { }