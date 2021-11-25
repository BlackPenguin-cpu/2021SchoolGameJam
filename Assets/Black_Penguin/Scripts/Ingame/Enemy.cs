using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    GameObject player;
    float distance;
    public float range;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Update()
    {
        base.Update();
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
                break;
            case EntityState.DIE:
                break;
            default:
                break;
        }
    }
    protected override void Die()
    {
        Debug.Log($"{gameObject}ÀÌ Á×À½");
    }
    private void Attack()
    {
        
    }

    private void Move()
    {
        float x = player.transform.position.x;
        range = Mathf.Abs(gameObject.transform.position.x - x);
        if (range <= distance)
        {
            entityState = EntityState.ATTACK;
        }
        else
        {

            if (gameObject.transform.position.x < x)
            {
                transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            }
            if (gameObject.transform.position.x > x)
            {
                transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
