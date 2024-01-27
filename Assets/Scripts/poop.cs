using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poop : MonoBehaviour
{
    public float lifeTime = 5.0f;

    void Start()
    {
        Invoke("DestroyPoop", lifeTime);
    }

    void DestroyPoop()
    {
        Destroy(gameObject);
    }
}
