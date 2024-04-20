using System.Collections;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField][Range(1, 50)] private int damage = 10;
    [SerializeField][Range(0, 1)] private float projectileLifeTime;

    private void Update()
    {
        StartCoroutine(LifeTime());
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            EnemyUICaralho hs = other.gameObject.GetComponent<EnemyUICaralho>();
            if(hs != null)
            {
                hs.TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }

    private IEnumerator LifeTime(){
    yield return new WaitForSeconds(projectileLifeTime);
    Destroy(gameObject);
}

}
