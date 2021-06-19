using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float MaxSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * MaxSpeed * Time.deltaTime;
    }
}
