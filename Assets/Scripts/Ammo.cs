using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float DamageRate = 100f;
    public float LeftTime = 2f;

    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", LeftTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Health H = other.gameObject.GetComponent<Health>();
        if (H == null)
        {
            return;
        }
        H.HealthPoints -= DamageRate;
        Die();
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
