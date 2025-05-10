using UnityEngine;

public class Tower : EnemyBasic
{
    public object Bullet;

    private void Update()
    {
        if (hp <= 0)
        {
            GameOver();
        }
        if (hit)
        {
            hit = false;
            GetHit(0f);
        }
    }
    public void GameOver()
    {
        Debug.Log("game over");
    }
}
