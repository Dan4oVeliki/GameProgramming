using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dmg;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            EnemyBasic enemyBasic = collision.gameObject.GetComponent<EnemyBasic>();
            if (enemyBasic != null)
            {
                enemyBasic.GetHit(dmg);
            }
        }
        Destroy(gameObject);
    }
}
