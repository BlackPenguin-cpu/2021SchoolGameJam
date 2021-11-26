using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAttackState
{
    SHOCKWAVE,
    ELECTRONIC,
    COMMONATTACK
}

public class Player : Entity
{
    PlayerAttackState playerSkill;
    Animator anim;
    bool attackAble = true;

    public GameObject[] attackCollider = new GameObject[3];
    public GameObject shockWaveCollider;

    public ParticleSystem shockWave;
    public float shockWaveDelay;
    float shockCurDelay;

    bool waiting;

    protected override void Die()
    {
    }

    protected override void Start()
    {
        base.Start();
        MaxHp = GameManager.Instance.PlayerHp;
        _hp = MaxHp;
        anim = GetComponent<Animator>();
        shockWave.Stop();
        shockWaveCollider.SetActive(false);
        foreach (var item in attackCollider)
        {
            item.SetActive(false);
        }
    }

    protected override void Update()
    {
        base.Update();
        anim.SetInteger("PlayerState", (int)entityState);
        shockCurDelay += Time.deltaTime;
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
                switch (playerSkill)
                {
                    case PlayerAttackState.SHOCKWAVE:
                        if(shockCurDelay >= shockWaveDelay)
                        {
                            ShockWaveAnimation();
                            shockCurDelay = 0;
                        }
                        break;
                    case PlayerAttackState.ELECTRONIC:
                        break;
                    case PlayerAttackState.COMMONATTACK:
                        PlayerAttack();
                        break;
                    default:
                        break;
                }
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
                foreach (var item in attackCollider)
                {
                    item.SetActive(false);
                }
                break;
            case EntityState.MOVING:
                IdleController();
                PlayerMove();
                break;
            case EntityState.ONDAMAGE:
                break;
            case EntityState.ATTACK:
                AttackMove();
                break;
            case EntityState.DIE:
                break;
            default:
                break;
        }
    }

    void ShockWaveAnimation()
    {
        if (attackAble)
        {
            attackAble = false;
            anim.SetInteger("AttackIndex", 3); // 3 == shockwave attack
            shockCurDelay = 0;
        }
    }

    public void ShockWaveAttackStart()
    {
        shockWave.Play();
        shockWaveCollider.SetActive(true);
    }
    
    public void ShockWaveAttackEnd()
    {
        entityState = EntityState.IDLE;
        shockWaveCollider.SetActive(false);
        attackAble = true;
    }

    void PlayerAttack()
    {
        if (attackAble)
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
    }

    void IdleController()
    {
        attackAble = true;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            entityState = EntityState.MOVING;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            entityState = EntityState.ATTACK;
            playerSkill = PlayerAttackState.COMMONATTACK;
        }
        if (Input.GetKeyDown(KeyCode.A) && shockCurDelay >= shockWaveDelay)
        {
            entityState = EntityState.ATTACK;
            playerSkill = PlayerAttackState.SHOCKWAVE;
        }
    }

    void AttackMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
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
        Stop(0.5f);
    }

    public void Stop(float duration)
    {
        if (waiting)
            return;
        Time.timeScale = 0;
        StartCoroutine(Wait(duration));
    }

    IEnumerator Wait(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
        waiting = false;
        entityState = EntityState.IDLE;
    }
}
