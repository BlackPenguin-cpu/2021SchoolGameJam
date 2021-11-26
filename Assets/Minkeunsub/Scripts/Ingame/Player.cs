using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAttackState
{
    SHOCKWAVE,
    ELECTRONIC,
}

public enum PlayerState
{
    Idle,
    Attack,
    Skill,
    Dash,
    OnDamaged,
    Die,
}

public class Player : Entity
{
    PlayerAttackState playerSkill;
    PlayerState playerState;
    Animator anim;
    bool attackAble = true;

    public GameObject[] attackCollider = new GameObject[3];
    public GameObject shockWaveCollider;

    public ParticleSystem shockWave;
    public float shockWaveDelay;
    float shockCurDelay;

    bool isMoving;
    bool waiting;

    public float DashForce;
    public float StartDashTimer;

    float CurrentDashTimer;
    float DashDirection;

    bool isDashing;

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
        anim.SetInteger("PlayerState", (int)playerState);
        anim.SetBool("IsMove", isMoving);
        shockCurDelay += Time.deltaTime;

        switch (playerState)
        {
            case PlayerState.Idle:
                IdleController();
                break;
            case PlayerState.Attack:
                PlayerAttack();
                break;
            case PlayerState.Skill:
                switch (playerSkill)
                {
                    case PlayerAttackState.SHOCKWAVE:
                        if (shockCurDelay >= shockWaveDelay)
                        {
                            ShockWaveAnimation();
                            shockCurDelay = 0;
                        }
                        break;
                    case PlayerAttackState.ELECTRONIC:
                        break;
                }
                break;
            case PlayerState.OnDamaged:

                break;
            case PlayerState.Die:

                break;
            case PlayerState.Dash:
                if (!isDashing)
                    Dash();
                break;
            default:
                break;
        }
    }

    void Dash()
    {
        isDashing = true;
        CurrentDashTimer = StartDashTimer;
    }

    private void FixedUpdate()
    {
        PlayerMove();
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
        playerState = PlayerState.Idle;
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
        playerState = PlayerState.Idle;
        foreach (var item in attackCollider)
        {
            item.SetActive(false);
        }
    }

    void IdleController()
    {
        attackAble = true;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerState = PlayerState.Attack;
        }
        if (Input.GetKeyDown(KeyCode.A) && shockCurDelay >= shockWaveDelay)
        {
            playerState = PlayerState.Skill;
            playerSkill = PlayerAttackState.SHOCKWAVE;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerState = PlayerState.Dash;
        }
    }

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && playerState != PlayerState.Attack)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && playerState != PlayerState.Attack)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            isMoving = false;
        }
    }

    protected override void Hit()
    {
        Stop(0.5f);
        playerState = PlayerState.OnDamaged;
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
        playerState = PlayerState.Idle;
    }
}
