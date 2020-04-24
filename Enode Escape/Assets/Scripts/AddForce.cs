using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class AddForce : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] bool useRandomForce = false;
    [ShowIf("useRandomForce")]
    [SerializeField] [MinMaxSlider(0, 20)] Vector2 randomForce;
    [HideIf("useRandomForce")]
    [SerializeField] [Range(0, 10)] float force;
    Rigidbody2D rb2d;
    public void GetRigidbody(Rigidbody2D _rb2d)
    {
        rb2d = _rb2d;
    }

    public void AddForceImpulse()
    {
        rb2d.AddForce(direction * force, ForceMode2D.Impulse);
    }
    
    public void AddForceRandomImpulse()
    {
        rb2d.AddForce(direction * Random.Range(randomForce.x, randomForce.y), ForceMode2D.Impulse);
    }
}
