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

    CameraController mainCamera;

    PlayerAttackState playerSkill;
    PlayerState playerState;
    Animator anim;
    Rigidbody2D RB;
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

    int direction = 1;

    bool isDashing;

    public ParticleSystem hitEffect;
    protected override void Die()
    {
    }

    protected override void Start()
    {
        base.Start();
        MaxHp = GameManager.Instance.PlayerHp;
        RB = GetComponent<Rigidbody2D>();
        _hp = MaxHp;
        anim = GetComponent<Animator>();
        shockWave.Stop();
        hitEffect.Stop();
        shockWaveCollider.SetActive(false);
        mainCamera = Camera.main.GetComponent<CameraController>();
        shockCurDelay = shockWaveDelay;
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
        hitEffect.transform.position = transform.position;

        if (Input.GetKeyDown(KeyCode.A) && shockCurDelay >= shockWaveDelay)
        {
            playerState = PlayerState.Skill;
            playerSkill = PlayerAttackState.SHOCKWAVE;
        }

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
                Dash();
                break;
            default:
                break;
        }
    }

    void Dash()
    {
        if (isDashing)
        {
            RB.velocity = transform.right * DashForce;

            CurrentDashTimer -= Time.deltaTime;

            if (CurrentDashTimer <= 0)
            {
                isDashing = false;
                playerState = PlayerState.Idle;
                RB.velocity = Vector2.zero;
            }
        }
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
        else isMoving = false;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerState = PlayerState.Attack;
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerState = PlayerState.Dash;
            isDashing = true;
            CurrentDashTimer = StartDashTimer;
            RB.velocity = Vector2.zero;
            CurrentDashTimer -= Time.deltaTime;
        }
    }

    void PlayerMove()
    {
        if (!isDashing && playerState != PlayerState.OnDamaged)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && playerState != PlayerState.Attack)
            {
                transform.Translate(Vector3.right * Speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                direction = 1;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && playerState != PlayerState.Attack)
            {
                transform.Translate(Vector3.right * Speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                direction = -1;
            }
        }
    }

    protected override void Hit()
    {
        hitEffect.Play();
        mainCamera.Shake(5, 5);
        playerState = PlayerState.OnDamaged;
        anim.SetInteger("PlayerState", (int)playerState);
        anim.SetInteger("AttackIndex", 0);
        isMoving = false;
        anim.SetBool("IsMove", isMoving);
        Stop(0.25f);
    }

    public void Stop(float duration)
    {
        if (waiting)
            return;
        StartCoroutine(Wait(duration));
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 0;

        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
        foreach (var item in attackCollider)
        {
            item.SetActive(false);
        }
        RB.velocity = new Vector2(5 * direction, 5);
        waiting = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && playerState == PlayerState.OnDamaged)
        {
            RB.velocity = Vector2.zero;
            playerState = PlayerState.Idle;
        }
    }

}
