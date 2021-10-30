using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float MaxRadius = 1f;
    public float Interval = 5f;
    public GameObject ObjToSpawn = null;
    public Transform Origin = null;
    public int PoolSize = 50;
    public Queue<Transform> EnemyQueue = new Queue<Transform>();
    public static Spawner SpawnerSingleton = null;
    public float EnemyHealth = 100;

    private GameObject[] EnemyArray;
    private void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag("Player").transform;

        if (SpawnerSingleton != null)
        {
            Destroy(GetComponent<Spawner>());
            return;
        }

        SpawnerSingleton = this;
        EnemyArray = new GameObject[PoolSize];

        for (int i = 0; i < PoolSize; i ++)
        {
            EnemyArray[i] = Instantiate(ObjToSpawn, Vector3.zero, Quaternion.identity, transform) as GameObject;
            Transform objTransfotm = EnemyArray[i].transform;
            EnemyQueue.Enqueue(objTransfotm);
            EnemyArray[i].SetActive(false);
        }
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, Interval);
    }

    void Spawn()
    {
        if (Origin == null)
        {
            return;
        }

        Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius;
        SpawnPos = new Vector3(SpawnPos.x, 0.0f, SpawnPos.z);
        Transform SpawnedEnemy = EnemyQueue.Dequeue();
        SpawnedEnemy.gameObject.SetActive(true);
        SpawnedEnemy.position = SpawnPos;
        SpawnedEnemy.rotation = Quaternion.identity;
        Health enemyHealth = SpawnedEnemy.gameObject.GetComponent<Health>();
        enemyHealth.HealthPoints = EnemyHealth;
        EnemyQueue.Enqueue(SpawnedEnemy);
    }
}
