using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnCooldown = 4f;
    public GameObject Enemy;

    private GameObject[] m_SpawnPoints;

    void Start()
    {
        m_SpawnPoints = GameObject.FindGameObjectsWithTag("Enemy Spawn");
    }

    void Update()
    {
        SpawnCooldown -= Time.deltaTime;
        if (SpawnCooldown <= 0)
        {
            for (int i = 0; i < m_SpawnPoints.Length; i++)
            {
                Instantiate(Enemy, m_SpawnPoints[i].transform.position, m_SpawnPoints[i].transform.rotation);
            }
            SpawnCooldown = 4f;
        }
    }
}