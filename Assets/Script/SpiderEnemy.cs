using System.Collections;
using UnityEngine;

public class SpiderEnemy : Enemy, IEnemy
{
    public float speed;
    public Tower target;
    public float stopDistance = 1.0f; // Distance to stop before touching the target
    public Coroutine attack;

    void Start()
    {
        base.Start();
        target = FindFirstObjectByType<Tower>();
    }
    void Update()
    {
        if (target != null)
        {
            Move(speed, target);
        }
        if (hit)
        {
            hit = false;
            GetHit(0f);
        }
        Die();
    }

    public void Move(float moveSpeed, Tower target)
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z); // same height
        Vector3 direction = (targetPosition - transform.position);
        float distance = direction.magnitude;

        if (distance > stopDistance)
        {
            Vector3 moveDirection = direction.normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (attack == null)
            {
                attack = StartCoroutine(Attack(target));
            }
        }
    }

    public override IEnumerator Attack(Tower tower)
    {
        tower.hp -= dmg;
        tower.hit = true;
        yield return new WaitForSeconds(2f);
        attack = null;
        Debug.Log("hit ya");
    }
    public override void GetHit(float dmg)
    {
        hp -= dmg;
        base.GetHit(dmg);
    }
    public override void Die()
    {
        if (hp <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
