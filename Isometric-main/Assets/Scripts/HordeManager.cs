using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class HordeManager : MonoBehaviour
{
    public GameObject enemyPrefab;                      // Prefab do inimigo a ser spawnado
    public int initialEnemyCount = 10;                  // Quantidade inicial de inimigos na primeira horda
    public int minSpawnCount = 2;                       // Quantidade mínima de inimigos spawnados por intervalo de tempo
    public int maxSpawnCount = 5;                       // Quantidade máxima de inimigos spawnados por intervalo de tempo
    public float initialSpawnInterval = 4f;             // Intervalo de tempo inicial entre os spawns de inimigos
    public float minSpawnInterval = 2f;                 // Intervalo de tempo mínimo entre os spawns de inimigos
    public float maxSpawnInterval = 4f;                 // Intervalo de tempo máximo entre os spawns de inimigos
    public float timeBetweenHordes = 5f;                // Tempo entre o término de uma horda e o início da próxima
    public float preparationTime = 3f;                  // Tempo de preparação antes do início da próxima horda
    public float hordeDuration = 45f;                   // Tempo de duração da horda em segundos
    public TextMeshProUGUI preparationTimerText;        // Referência ao texto do timer de preparação na UI
    public TextMeshProUGUI hordeTimerText;              // Referência ao texto do timer da horda na UI


    public int round = 1;                   // Número da rodada atual
    public int remainingEnemies;            // Número de inimigos restantes na horda atual

    [System.Serializable]
    public class SpawnPoint
    {
        public Transform transform;         // Transform do ponto de spawn
        public Door associatedDoor;         // Porta associada ao ponto de spawn
    }

    public List<SpawnPoint> spawnPoints;    // Pontos de spawn dos inimigos


    private void Start()
    {
        StartCoroutine(SpawnEnemiesInWaves());
        StartCoroutine(HordeTimer());
    }

    private IEnumerator HordeTimer()
    {
        float timer = hordeDuration;

        // Mostrar o tempo restante da horda
        UpdateHordeTimerUI(timer);

        while (timer > 0)
        {
            // Atualizar texto da UI com o tempo restante da horda
            UpdateHordeTimerUI(timer);

            // Aguardar um frame
            yield return null;

            // Reduzir o tempo restante
            timer -= Time.deltaTime;
        }

        // Reiniciar o timer da horda
        ResetHordeTimer();

        // Iniciar o timer de preparação para a próxima horda
        StartPreparationTimer();
    }


    private IEnumerator SpawnEnemiesInWaves()
    {
        remainingEnemies = initialEnemyCount;

        while (remainingEnemies > 0)
        {
            // Lógica de spawn de inimigos...
            int spawnCount = Random.Range(minSpawnCount, maxSpawnCount + 1);

            // Spawn dos inimigos
            for (int i = 0; i < spawnCount; i++)
            {
                if (spawnPoints.Count > 0)
                {
                    int randomSpawnIndex = Random.Range(0, spawnPoints.Count);
                    SpawnPoint spawnPoint = spawnPoints[randomSpawnIndex];

                    if (spawnPoint.associatedDoor == null || spawnPoint.associatedDoor.isUnlocked)
                    {
                        SpawnEnemy(spawnPoint.transform.position);
                        remainingEnemies--;
                    }
                }
            }

            float spawnInterval = Mathf.Lerp(maxSpawnInterval, minSpawnInterval, (float)remainingEnemies / initialEnemyCount);
            yield return new WaitForSeconds(spawnInterval);
        }

        yield return new WaitForSeconds(timeBetweenHordes);
        StartPreparationTimer();
    }

    private IEnumerator PreparationTimer()
    {
        float timer = preparationTime;

        while (timer > 0)
        {
            // Atualiza o texto do timer na UI
            UpdatePreparationTimerUI(timer);

            // Aguarda um frame
            yield return null;

            // Reduz o tempo restante
            timer -= Time.deltaTime;
        }

        // Reinicia o timer de preparação
        ResetPreparationTimer();

        // Inicia a próxima horda
        StartHordeTimer();
        StartCoroutine(SpawnEnemiesInWaves());
    }

    private void UpdateHordeTimerUI(float timeRemaining)
    {
        if (hordeTimerText != null)
        {
            hordeTimerText.text = Mathf.CeilToInt(timeRemaining).ToString();
        }
    }

    private void ResetHordeTimer()
    {
        if (hordeTimerText != null)
        {
            hordeTimerText.text = "";
        }
    }

    private void StartHordeTimer()
    {
        StartCoroutine(HordeTimer());
    }

    private void StartPreparationTimer()
    {
        StartCoroutine(PreparationTimer());
    }

    private void UpdatePreparationTimerUI(float timeRemaining)
    {
        if (preparationTimerText != null)
        {
            preparationTimerText.text = Mathf.CeilToInt(timeRemaining).ToString();
        }
    }

    private void ResetPreparationTimer()
    {
        if (preparationTimerText != null)
        {
            preparationTimerText.text = "";
        }
    }

    private void SpawnEnemy(Vector3 spawnPosition)
    {
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }


}