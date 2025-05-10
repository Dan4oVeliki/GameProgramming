using System.Collections;
using UnityEngine;

public abstract class Enemy: EnemyBasic
{
    public abstract IEnumerator Attack(Tower helth);
    public abstract void Die();
}
