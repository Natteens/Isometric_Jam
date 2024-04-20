using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]private ScoreManager scoreManager;
    [SerializeField]private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        //scoreText = GetComponent<TextMeshProUGUI>();
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreManager != null && scoreText != null)
        {
            scoreText.text = "Pontuação: " + scoreManager.Score.ToString();
        }
    }

    private void Update()
    {
        UpdateScoreUI();
    }
}
