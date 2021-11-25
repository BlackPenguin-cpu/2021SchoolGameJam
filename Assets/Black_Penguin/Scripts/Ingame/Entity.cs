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
    private float hp;
    public float _hp
    {
        get { return hp; }
        set 
        { 
            if(value >= MaxHp)
            {
                hp = MaxHp;
            }
            if(value <= 0)
            {
                entityState = EntityState.DIE;
            }
            if(value < hp)
            {
                Hit();
            }
            hp = value; 
        }
    }

    public EntityState entityState;
    protected abstract void Die();
    protected abstract void Hit();
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
