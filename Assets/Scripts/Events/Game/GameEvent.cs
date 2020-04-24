using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "new GameEvent", menuName = "Events/Game")]
public class GameEvent : BaseEvent<Void>
{
    [Button("Raise")]
	public void Raise()
	{
        Raise(new Void());
	}
}

public struct Void { }