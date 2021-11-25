using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    Animator anim;
    bool attackAble = true;

    public GameObject[] attackCollider = new GameObject[3];

    protected override void Die()
    {
    }

    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        foreach (var item in attackCollider)
        {
            item.SetActive(false);
        }
    }

    protected override void Update()
    {
        base.Update();
        anim.SetInteger("PlayerState", (int)entityState);
        switch (entityState)
        {
            case EntityState.IDLE:
                IdleController();
                break;
            case EntityState.MOVING:
                break;
            case EntityState.ONDAMAGE:
                break;
            case EntityState.ATTACK:
                PlayerAttack();
                break;
            case EntityState.DIE:
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (entityState)
        {
            case EntityState.IDLE:
                break;
            case EntityState.MOVING:
                PlayerMove();
                break;
            case EntityState.ONDAMAGE:
                break;
            case EntityState.ATTACK:
                break;
            case EntityState.DIE:
                break;
            default:
                break;
        }
    }

    void PlayerAttack()
    {
        if(attackAble)
        {
            int attack_index = Random.Range(0, 3);
            anim.SetInteger("AttackIndex", attack_index);
            attackAble = false;
        }
    }

    public void AttackColliderActive(int n)
    {
        attackCollider[n].SetActive(true);
    }

    public void EndAttack()
    {
        entityState = EntityState.IDLE;
        foreach (var item in attackCollider)
        {
            item.SetActive(false);
        }
    }

    void IdleController()
    {
        attackAble = true;
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            entityState = EntityState.MOVING;
        }
        else if(Input.GetKeyDown(KeyCode.Z))
        {
            entityState = EntityState.ATTACK;
        }
    }

    void PlayerMove()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            entityState = EntityState.IDLE; 
        }
    }

    protected override void Hit()
    {

    }
}
