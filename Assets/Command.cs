using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Command : MonoBehaviour
{
    [SerializeField]
    Transform dialoguePoint;

    [SerializeField]
    Transform dialogueGO;

    [YarnCommand("setCharacter")]
    public void SetDialogueBox(string name)
    {
        if (name == "sara")
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(dialoguePoint.position);
            dialogueGO.position = pos;
        }
    }
}
