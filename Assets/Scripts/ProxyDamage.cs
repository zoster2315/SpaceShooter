using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour
{
    public float DamageRate = 10f;

    private void OnTriggerStay(Collider other)
    {
        Health H = other.gameObject.GetComponent<Health>();
        if (H == null)
        {
            return;
        }

        H.HealthPoints -= DamageRate * Time.deltaTime;
    }
}
