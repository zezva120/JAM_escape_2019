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

    [SerializeField]
    LightColorController lightController;

    [YarnCommand("setCharacter")]
    public void SetDialogueBox(string name)
    {
        if (name == "sara")
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(dialoguePoint.position);
            dialogueGO.position = pos;
        }
    }

    [YarnCommand("time")]
    public void TimeDown(string fadeOut, string dur)
    {
        float duration = 0;
        float.TryParse(dur, out duration);
        StartCoroutine(IeTimeDown(fadeOut == "fadeOut", duration));
    }
    IEnumerator IeTimeDown(bool fadeOut, float duration)
    {
        
        if (fadeOut)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime / duration)
            {
                lightController.time = i;
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime / duration)
            {
                lightController.time = i;
                yield return null;
            }
        }
    }
}
