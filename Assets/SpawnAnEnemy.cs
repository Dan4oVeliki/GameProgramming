using System.Collections;
using UnityEngine;

public class SpawnAnEnemy : Spawner
{
    public Coroutine spawnshit;
    public float TimeWait;

    private void Update()
    {
        if (spawnshit == null)
        {
            spawnshit = StartCoroutine(SpawnEnemy());
        }
    }
    public IEnumerator SpawnEnemy()
    {
        SpawnThing();
        yield return new WaitForSeconds(TimeWait);
        spawnshit = null;
    }


}
