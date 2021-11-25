using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityState
{
    IDLE,
    MOVING,
    ONDAMAGE,
    ATTACK,
    DIE
}

public abstract class Entity : MonoBehaviour
{
    public float Damage;
    public float MaxHp;
    public float Speed;
    public float hp;
    public EntityState entityState;
    protected abstract void Die();
    //protected abstract void Attack();
    
    protected virtual void Start()
    {

    }
    protected virtual void Update()
    {
        if (hp > MaxHp)
        {
            hp = MaxHp;
        }
        if (hp <= 0)
        {
            Die();
        }


    }

}
