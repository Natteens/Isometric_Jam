using UnityEngine;

public class GhostSuction : MonoBehaviour
{
    [SerializeField] private float suctionForce = 10f; // Força de sucção aplicada ao fantasma
    [SerializeField] private float playerTurnForce = 5f; // Força de virada do jogador enquanto suga o fantasma
    [SerializeField] private float ghostEscapeForce = 5f; // Força aplicada pelo fantasma para escapar

    private bool isSucking = false; // Flag para indicar se o jogador está sugando o fantasma
    private Rigidbody playerRigidbody; // Referência ao Rigidbody do jogador
    private Ghost currentGhost; // Referência ao fantasma atualmente sendo sugado

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void StartSuction(Ghost ghost)
    {
        isSucking = true;
        currentGhost = ghost;
    }

    public void StopSuction()
    {
        isSucking = false;
        currentGhost = null;
    }

    private void FixedUpdate()
    {
        if (isSucking && currentGhost != null)
        {
            // Calcular a direção da sucção do jogador para o fantasma
            Vector3 suctionDirection = (currentGhost.transform.position - transform.position).normalized;

            // Aplicar força de sucção ao fantasma
            currentGhost.ApplyForce(suctionDirection * suctionForce);

            // Aplicar força para virar o jogador em direção ao fantasma
            Vector3 playerTurnDirection = (currentGhost.transform.position - transform.position).normalized;
            playerRigidbody.AddTorque(playerTurnDirection * playerTurnForce);

            // Aplicar força do fantasma para escapar
            Vector3 ghostEscapeDirection = (transform.position - currentGhost.transform.position).normalized;
            currentGhost.ApplyForce(ghostEscapeDirection * ghostEscapeForce);
        }
    }
}
