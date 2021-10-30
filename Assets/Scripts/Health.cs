using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject DeathParticlesPrefab = null;
    public bool ShouldDestroyOnDeath = true;
    [SerializeField] private float _HealthPoints = 100f;
    
    public float HealthPoints
    {
        get
        {
            return _HealthPoints;
        }
        set
        {
            _HealthPoints = value;
            if (HealthPoints <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);
                if (DeathParticlesPrefab != null)
                {
                    Instantiate(DeathParticlesPrefab, transform.position, transform.rotation);
                }
                if (ShouldDestroyOnDeath)
                {
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                    //if (gameObject.tag == "Enemy")
                }
            }
        }
    }
}
