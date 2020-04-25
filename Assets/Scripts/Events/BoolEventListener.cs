using UnityEngine.Events;

public class BoolEventListener : BaseEventListener<bool, BoolEvent, UnityBoolEvent> { }

[System.Serializable]
public class UnityBoolEvent : UnityEvent<bool> { }
