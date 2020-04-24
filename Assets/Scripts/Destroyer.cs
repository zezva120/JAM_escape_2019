using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] bool runOnStart;
    public float lifeTime;
    void Start()
    {
        if(runOnStart)
            Destroy(gameObject, lifeTime);
    }

    public void DestroyGO()
    {
        Destroy(gameObject, lifeTime);
    }
}
