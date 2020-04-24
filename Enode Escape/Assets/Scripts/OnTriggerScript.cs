using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using NaughtyAttributes;

public class OnTriggerScript : MonoBehaviour
{
    public bool triggerEnter;
    public bool triggerStay;
    public bool triggerExit;

    [Tag]
    public string tagField;

    [ShowIf("triggerEnter")]
    public UnityCollider2DEvent onTriggerEnter;
    [ShowIf("triggerStay")]
    public UnityCollider2DEvent onTriggerStay;
    [ShowIf("triggerExit")]
    public UnityCollider2DEvent onTriggerExit;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (tagField == null || string.IsNullOrEmpty(tagField) || string.IsNullOrEmpty(tag)) return;

        if (other.CompareTag(tagField))
        {
            onTriggerEnter.Invoke(other);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (tagField == null || string.IsNullOrEmpty(tagField) || string.IsNullOrEmpty(tag)) return;

        if (other.CompareTag(tagField))
        {
            onTriggerStay.Invoke(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onTriggerExit.Invoke(other);
    }
}
