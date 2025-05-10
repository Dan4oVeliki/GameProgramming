using UnityEngine;
using UnityEngine.VFX;

public class Gun : Spawner
{
    public Transform shootFrom;
    public float POWER;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnThing(shootFrom, POWER);
        }
    }
}
