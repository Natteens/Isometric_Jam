using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDetector : MonoBehaviour
{
    public float detectionRadius = 5f;
    public LayerMask ghostLayer;

    private Ghost currentTarget;

    void Update()
    {
        // Detecta os fantasmas dentro do raio de detecção
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, ghostLayer);

        // Seleciona o fantasma mais próximo como alvo
        Ghost nearestGhost = GetNearestGhost(colliders);

        // Verifica se o alvo mudou
        if (nearestGhost != currentTarget)
        {
            // Chama o evento de mudança de alvo
            OnTargetChanged(nearestGhost);
            currentTarget = nearestGhost;
        }
    }

    Ghost GetNearestGhost(Collider[] colliders)
    {
        Ghost nearestGhost = null;
        float minDistance = Mathf.Infinity;
        foreach (Collider col in colliders)
        {
            Ghost ghost = col.GetComponent<Ghost>();
            if (ghost != null)
            {
                float distance = Vector3.Distance(transform.position, ghost.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestGhost = ghost;
                }
            }
        }
        return nearestGhost;
    }

    void OnTargetChanged(Ghost newTarget)
    {
        Debug.Log("New target: " + (newTarget != null ? newTarget.name : "None"));
        // Aqui você pode adicionar qualquer lógica necessária quando o alvo muda
    }

    void OnDrawGizmosSelected()
    {
        // Desenha uma esfera para visualizar o raio de detecção
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
