using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    Animator anim;
    public ParticleSystem Hitparticle;
    public ParticleSystem Deathparticle;
    public bool deadEffected = false;
    public GameObject player;
    public float distance;
    [SerializeField] float nowAttackCooldown;
    public float AttackCooldown = 0;
    public float range;
    public AudioClip AudioClip;

    protected override void Start()
    {
        base.Start();
        Hitparticle.Stop();
        Deathparticle.Stop();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Update()
    {
        base.Update();
        anim.SetInteger("State", (int)entityState);
        if (!GameManager.Instance.IsGameOver)
        { 
            switch (entityState)
            {
                case EntityState.IDLE:
                    break;
                case EntityState.MOVING:
                    Move();
                    break;
                case EntityState.ONDAMAGE:
                    break;
                case EntityState.ATTACK:
                    if (AttackCooldown < nowAttackCooldown && entityState != EntityState.ONDAMAGE)
                        Attack();
                    break;
                case EntityState.DIE:
                    Die();
                    break;
                default:
                    break;
            }
        }
        nowAttackCooldown += Time.deltaTime;
    }
    protected override void Die()
    {
        if (!deadEffected)
        {
            player.GetComponent<Player>().killCount++;
            Deathparticle.Play();
            deadEffected = true;
        }
        gameObject.layer = 5;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        entityState = EntityState.DIE;
    }
    protected virtual void Attack()
    {
        if (entityState == EntityState.DIE) return;
        nowAttackCooldown = 0;
    }

    //private void Attack()
    //{
    //    var rayhit = Physics2D.RaycastAll(transform.position, Vector3.right, distance);
    //    Debug.DrawRay(transform.position, Vector3.right * distance);
    //    foreach(var hit in rayhit)
    //    {
    //        if (hit.collider.gameObject.tag == "Player")
    //        {
    //            hit.collider.gameObject.GetComponent<Entity>()._hp -= Damage;
    //        }
    //    }
    //}

    protected virtual void Move()
    {
        bool attack = false;
        if (entityState == EntityState.DIE) return;
        float x = player.transform.position.x;
        distance = Mathf.Abs(gameObject.transform.position.x - x);
        RaycastHit2D[] hit;
        if (player.transform.position.x > transform.position.x)
        {
            hit = Physics2D.RaycastAll(transform.position, Vector3.right, range);
        }
        else
        {
            hit = Physics2D.RaycastAll(transform.position, Vector3.left, range);
        }
        foreach(RaycastHit2D player in hit)
        {
            if(player.collider.tag == "Player")
            {
                attack = true;
                break;
            }
            else
            {
                attack = false;
            }
        }
        if (distance <= range || attack == true)
        {
            entityState = EntityState.ATTACK;
        }
        else
        {
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
    }

    protected override void Hit()
    {
        Hitparticle.Play();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (entityState != EntityState.ONDAMAGE)
        {
            if (collision.gameObject.tag == "ShockWaveAttack")
            {
                _hp -= player.GetComponent<Player>().Damage * 1.5f / (Mathf.Abs(transform.position.x - player.transform.position.x) / 3);
                OnKnockback(50 / Mathf.Abs(transform.position.x - player.transform.position.x), 5);
            }
            if (collision.gameObject.tag == "PlayerAttack")
            {
                OnKnockback(5, 1);
                _hp -= player.GetComponent<Player>().Damage;
            }
        }
    }
    void OnKnockback(float value, float value2)
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if (value < 0)
        {
            return;
        }
        if (player.transform.position.x - gameObject.transform.position.x <= 0)
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            rigid.AddForce(new Vector2(value, value2), ForceMode2D.Impulse);
        }
        else
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            rigid.AddForce(new Vector2(-value, value2), ForceMode2D.Impulse);
        }
    }
}
