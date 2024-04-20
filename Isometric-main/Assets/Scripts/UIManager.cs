using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    public HealthUI playerHealthUI;
    public ScoreManager scoreManager;
    public GameObject gameOver_Tela;
    public TMP_Text pontosText;

    // Método para atualizar a UI do jogador
    public void UpdatePlayerHealthUI(int currentHealth, int maxHealth)
    {
        playerHealthUI.UpdateHealthUI(currentHealth, maxHealth);
    }

    public void GameOver()
    {
        pontosText.text = ("Pontuação Final: " + scoreManager.score);
        gameOver_Tela.SetActive(true); 
        Time.timeScale = 0f;
    }
    public void Restarta()
    {
        gameOver_Tela.SetActive(false);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
