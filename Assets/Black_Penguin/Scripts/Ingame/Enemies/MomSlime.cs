using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomSlime : Enemy
{
    [SerializeField] GameObject babySlime;
    [SerializeField] Transform spawnPosition;
    float cooltime;
    protected override void Start()
    {
        base.Start();
        entityState = EntityState.MOVING;
    }
    protected override void Update()
    {
        base.Update();
        cooltime += Time.deltaTime;
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
    }
    protected override void Move()
    {
        if (entityState == EntityState.DIE) return;
        float x = player.transform.position.x;
        distance = Mathf.Abs(gameObject.transform.position.x - x);
        if (cooltime >= 8)
        {
            Debug.Log("공격시간!");
            cooltime = 0;
            entityState = EntityState.ATTACK;
        }

        if (gameObject.transform.position.x < x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
        }
        if (gameObject.transform.position.x > x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
        }
    }
    //소환 관련 함수 애니매이션
    void Summon()
    {
        GameObject baby;
       /* GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Collider2D>().isTrigger = true;
*/
        baby = Instantiate(babySlime, spawnPosition.position, Quaternion.identity);

        Entity BabySlime = baby.GetComponent<Entity>();
        BabySlime.MaxHp = 120;
        /*GetComponent<Collider2D>().isTrigger = false;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        */entityState = EntityState.MOVING;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && entityState != EntityState.ONDAMAGE && InGameUIManager.Instance.gameSuccess == false && GameManager.Instance.IsGameOver == false)
        {
            collision.gameObject.GetComponent<Entity>()._hp -= Damage;
        }
    }
    protected override void Die()
    {
        base.Die();
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
        StartCoroutine(hitevent(sprite));
    }

}
