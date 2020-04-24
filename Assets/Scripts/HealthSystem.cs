using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] FloatReference health;
    [SerializeField] FloatReference maxHealth;
    [SerializeField] bool resetHP;
    [SerializeField] bool knockback;
    [ShowIf("knockback")]
    [SerializeField] [Range(1,100)] float projectionForceX = 1;
    [SerializeField] [Range(1,100)] float projectionForceY = 1;
    [ShowIf("knockback")]
    [SerializeField] bool forceX;
    [ShowIf("knockback")]
    [SerializeField] bool forceY;

    [SerializeField] UnityEvent DamagedEvent;
    [ShowIf("knockback")]
    [SerializeField] UnityVector2ForceModeEvent HitEvent;
    [SerializeField] UnityEvent KilledEvent;

    bool isDied;

    /*public bool IsDied { get { return isDied; } set { isDied = value; } }*/

    private void Start()
    {
        if (resetHP)
        {
            ResetHealth();
        }
    }

    public void Hit(Vector2 launchDirection)
    {
        if (isDied) return;

        if (knockback)
        {
            if(forceX && !forceY)
            {
                HitEvent.Invoke(new Vector2(launchDirection.x, 0) * projectionForceX, ForceMode2D.Impulse);
            }
            else if(forceY && !forceX)
            {
                HitEvent.Invoke(new Vector2(0, launchDirection.y) * projectionForceY, ForceMode2D.Impulse);

            }
            else if(forceX && forceY)
            {
                HitEvent.Invoke(new Vector2(launchDirection.x * projectionForceX, launchDirection.y * projectionForceY), ForceMode2D.Impulse);

            }
        }
            //HitEvent.Invoke(launchDirection * projectionForce);
    }

    public void TakeDamage(float amount)
    {
        if (isDied) return;

        DamagedEvent.Invoke();

        if (health.UseConstant)
            health.ConstantValue -= amount;
        else
            health.Variable.ApplyChange(-amount);

        if (health.Value <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDied = true;
        KilledEvent.Invoke();
    }

    public void ResetHealth()
    {
        if (health.UseConstant)
            health.ConstantValue = maxHealth.Value;
        else
            health.Variable.SetValue(maxHealth.Value);
    }
}
[System.Serializable]
public class UnityVector2ForceModeEvent : UnityEvent<Vector2, ForceMode2D> { }