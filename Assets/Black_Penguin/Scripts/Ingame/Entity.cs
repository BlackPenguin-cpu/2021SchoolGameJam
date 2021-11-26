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
    public float InvinsibleTime;
    [SerializeField] private float hp;
    public float _hp
    {
        get { return hp; }
        set
        {
            if (value >= MaxHp)
            {
                hp = MaxHp;
            }
            if (value <= 0)
            {
                entityState = EntityState.DIE;
            }
            if ((entityState == EntityState.ONDAMAGE && gameObject.tag == "Player"))
            {
                return;
                
            }
                if (value < hp)
                {
                    StartCoroutine(Onhit());
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
        hp = MaxHp;
    }
    protected virtual void Update()
    {

    }
    protected virtual IEnumerator Onhit()
    {
        entityState = EntityState.ONDAMAGE;
        yield return new WaitForSeconds(0.5f);
        entityState = EntityState.MOVING;
    }

}
