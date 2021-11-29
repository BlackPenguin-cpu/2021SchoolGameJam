using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    float delay;
    bool canJump;
    bool isDead = false;
    [SerializeField] Sprite[] deadSprites;
    SpriteRenderer sprite;
    protected override void Start()
    {
        base.Start();
        entityState = EntityState.MOVING;
    }
    protected override void Update()
    {
        base.Update();
        delay -= Time.deltaTime;
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
    protected override void Move()
    {
        ////base 하지 않습니다!
        //float x = player.transform.position.x;
        //Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        //    if (gameObject.transform.position.x < x)
        //    {
        //        transform.rotation = Quaternion.Euler(0, 0, 0);
        //        rigid.AddForce(new Vector2(Speed, 5), ForceMode2D.Impulse);
        //    }
        //    if (gameObject.transform.position.x > x)
        //    {
        //        transform.rotation = Quaternion.Euler(0, 180, 0);
        //        rigid.AddForce(new Vector2(-Speed, 5), ForceMode2D.Impulse);
        //    }
    }

    void bounce()
    {
        if (!canJump || EntityState.DIE == entityState)
        {
            return;
        }
        float x = player.transform.position.x;
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if (gameObject.transform.position.x < x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rigid.AddForce(new Vector2(Speed, 3), ForceMode2D.Impulse);
        }
        if (gameObject.transform.position.x > x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rigid.AddForce(new Vector2(-Speed, 3), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
        else if (collision.gameObject == null)
        {
            canJump = false;
        }
        if (collision.gameObject.tag == "Player" && entityState != EntityState.ONDAMAGE && delay <= 0 && entityState != EntityState.DIE)
        {
            delay = 1;
            collision.gameObject.GetComponent<Entity>()._hp -= Damage;
        }
    }
    protected override void Die()
    {
        base.Die();
        if (!isDead)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetInteger("dead", Random.Range(1, 3));
            StartCoroutine(Dead());
            isDead = true;
        }
    }
    IEnumerator Dead()
    {
        Transform transform = GetComponent<Transform>();
        while (transform.localScale.y <= 0.1f)
        {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(transform.localScale.y, 0, 1));
            yield return new WaitForSeconds(0.1f);
        }
    }
    protected override void Hit()
    {
        base.Hit();
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(hitevent(sprite));
    }

}
