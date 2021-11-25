using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonster : Enemy
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }
    IEnumerator hitevent(SpriteRenderer sprite)
    {
        sprite.color = new Color(0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(1);
        sprite.color = new Color(1, 1, 1);
    }

    protected override void Attack()
    {
        base.Attack();

        var rayhit = Physics2D.RaycastAll(transform.position, Vector3.right, range);  
        Debug.DrawRay(transform.position, Vector3.right * range);
        foreach (var hit in rayhit)
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                hit.collider.gameObject.GetComponent<Entity>()._hp -= Damage;
            }
        }

    }
    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
    protected override void Hit()
    {
        base.Hit();
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(hitevent(sprite));
    }
    
}
