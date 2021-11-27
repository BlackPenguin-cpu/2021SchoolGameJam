using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonster : Enemy
{
    protected override void Start()
    {
        base.Start();
        entityState = EntityState.MOVING;
    }
    protected override void Update()
    {
        base.Update();
    }
    IEnumerator hitevent(SpriteRenderer sprite)
    {
        sprite.color = new Color(0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(0.7f);
        sprite.color = new Color(1, 1, 1);
    }

    protected override void Attack()
    {
        base.Attack();
        StartCoroutine(realAttack());
    }
    IEnumerator realAttack()
    {
        RaycastHit2D[] rayhit;
        yield return new WaitForSeconds(0.9f);
        if(player.transform.position.x > transform.position.x)
        {
            rayhit = Physics2D.RaycastAll(transform.position, Vector3.right, range);
        }
        else
        {
            rayhit = Physics2D.RaycastAll(transform.position, Vector3.left, range);
        }
        Debug.DrawRay(transform.position, Vector3.right * range);
        foreach (var hit in rayhit)
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("플레이어 공격");
                hit.collider.gameObject.GetComponent<Entity>()._hp -= Damage;
            }
            else
            {
                entityState = EntityState.MOVING;
            }
        }
    }
    protected override void Die()
    {
        base.Die();
    }
    protected override void Hit()
    {
        base.Hit();
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(hitevent(sprite));
    }

}
