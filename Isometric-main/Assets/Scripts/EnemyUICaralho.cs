using UnityEngine;
using UnityEngine.UI;

public class EnemyUICaralho : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    private Transform uiCanvasTransform;
    [SerializeField] private Image sprite;
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        currentHealth = maxHealth;
        uiCanvasTransform = FindObjectOfType<Canvas>().transform; // Encontrar o canvas da UI
        OrientUITowardsCamera();
    }

private void OrientUITowardsCamera()
{
    // Orienta o objeto do canvas na direção da câmera
    if (uiCanvasTransform != null)
    {
        uiCanvasTransform.LookAt(uiCanvasTransform.position + Camera.main.transform.rotation * Vector3.forward,
            Camera.main.transform.rotation * Vector3.up);
    }
}

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthUI();
        if (currentHealth <= 0)
        {
            PlayerHealthSystem playerhp = FindObjectOfType<PlayerHealthSystem>();
            playerhp.HealDamage(5);
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        sprite.fillAmount = (float)currentHealth / maxHealth;
    }

    private void Die()
    {
        // Implementar a lógica de morte do inimigo, se necessário
        if (scoreManager != null)
        {
            scoreManager.AddScore(10); // Adiciona 10 pontos ao jogador
        }
        Destroy(gameObject);
    }

    private void LateUpdate()
    {
        OrientUITowardsCamera(); // Garantir que a UI do inimigo sempre esteja orientada na direção da câmera
    }
}
