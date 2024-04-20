using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    public int Score => score;

    // Método para adicionar pontos ao jogador
    public void AddScore(int points)
    {
        score += points;
    }

    // Método para subtrair pontos do jogador
    public void SubtractScore(int points)
    {
        score -= points;
        if (score < 0)
        {
            score = 0;
        }
    }

    // Método para reiniciar a pontuação do jogador
    public void ResetScore()
    {
        score = 0;
    }
}
