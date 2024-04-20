using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo a ser spawnado
    public int initialEnemyCount = 5; // Quantidade inicial de inimigos
    public float spawnRadius = 10f; // Raio dentro do qual os inimigos serão spawnados

    void Start()
    {
        SpawnEnemies(initialEnemyCount);
    }

    void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randomSpawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(enemyPrefab, randomSpawnPos, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
