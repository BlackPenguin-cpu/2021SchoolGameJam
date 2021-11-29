using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonster : Enemy
{
    Coroutine attack;
    protected override void Start()
    {
        base.Start();
        entityState = EntityState.MOVING;
    }
    protected override void Update()
    {
        base.Update();
        if (_hp <= 0)
        {
            entityState = EntityState.DIE;
        }
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
        attack = StartCoroutine(realAttack());
        StartCoroutine(realAttack());
    }
    IEnumerator realAttack()
    {
        if (entityState == EntityState.DIE)
        {
            StopCoroutine(attack);
        }
        RaycastHit2D[] rayhit;
        yield return new WaitForSeconds(1f);
        if (player.transform.position.x > transform.position.x)
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
            if (entityState == EntityState.DIE) yield break;
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
        gameObject.layer = 4;
        StartCoroutine(destroy());
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(2);
        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    protected override void Hit()
    {
        base.Hit();
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        if (attack != null)
            StopCoroutine(attack);
        StartCoroutine(hitevent(sprite));
    }

}
