using UnityEngine;

public class Door : MonoBehaviour
{
    public int costToOpen = 70;
    public bool isUnlocked = false;

    public void OpenDoor(ScoreManager scoreManager)
    {
        if (!isUnlocked && scoreManager != null && scoreManager.Score >= costToOpen)
        {
            scoreManager.AddScore(-costToOpen); // Deduz o custo da pontuação do jogador
            isUnlocked = true;
            // Implemente a lógica para abrir a porta aqui (por exemplo, animação, mudança de sprite, etc.)
            Debug.Log("Porta aberta!");
        }
    }
}
