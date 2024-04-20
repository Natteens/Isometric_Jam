using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactionDistance = 2f; // Distância máxima para interação
    public KeyCode interactKey = KeyCode.F; // Tecla para interagir

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            TryInteractWithDoor();
        }
    }

    private void TryInteractWithDoor()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            Door door = hit.collider.GetComponent<Door>();
            if (door != null)
            {
                door.OpenDoor(GetComponent<ScoreManager>());
            }
        }
    }
}
