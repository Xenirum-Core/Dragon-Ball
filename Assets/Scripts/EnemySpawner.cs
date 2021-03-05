using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnCooldown = 4f;
    public GameObject Enemy;

    public GameObject[] m_SpawnPoints;
    private float m_SpawnCooldown;

    void Update()
    {
        m_SpawnCooldown -= Time.deltaTime;
        if (m_SpawnCooldown <= 0)
        {
            for (int i = 0; i < m_SpawnPoints.Length; i++)
            {
                Instantiate(Enemy, m_SpawnPoints[i].transform.position, m_SpawnPoints[i].transform.rotation);
            }
            m_SpawnCooldown = SpawnCooldown;
        }
    }
}