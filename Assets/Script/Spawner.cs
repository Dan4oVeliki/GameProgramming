using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public virtual void SpawnThing()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
    public virtual void SpawnThing(Transform where, float Power)
    {
        GameObject newBullet = Instantiate(prefab, where.position, Quaternion.identity);
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = transform.forward * Power;
        }
    }

}
