using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Rigidbody ghostRigidbody; // Referência ao Rigidbody do fantasma

    private void Start()
    {
        ghostRigidbody = GetComponent<Rigidbody>();
    }

    public void ApplyForce(Vector3 force)
    {
        ghostRigidbody.AddForce(force, ForceMode.Force);
    }
}
