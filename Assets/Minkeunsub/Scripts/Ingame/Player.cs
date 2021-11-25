using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    Animator anim;
    protected override void Die()
    {
    }

    protected override void Start()
    {
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        anim.SetInteger("PlayerState", (int)entityState);
        switch (entityState)
        {
            case EntityState.IDLE:
                IdleController();
                break;
            case EntityState.MOVING:
                PlayerMove();
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

    void PlayerAttack()
    {
        int attack_index = Random.Range(0, 4);
        anim.SetInteger("AttackIndex", attack_index);
    }

    void IdleController()
    {
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
