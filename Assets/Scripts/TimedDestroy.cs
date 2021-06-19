using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float DestroyTime = 2f;

    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }
}
