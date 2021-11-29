using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceEntity : Entity
{

    Vector3[] originPos;
    public Transform[] shakeableObj;
    int alreadyDead;
    Player player;
    bool dead = false;

    protected override void Die()
    {
        Rigidbody2D[] childrenFence = gameObject.GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D rigid in childrenFence)
        {
            if (alreadyDead != 2)
            {
                alreadyDead++;
                SpriteRenderer sprite = rigid.gameObject.GetComponent<SpriteRenderer>();
                rigid.bodyType = RigidbodyType2D.Dynamic;
                rigid.gravityScale = 2;
                rigid.AddForce(new Vector2(Random.Range(-2, 3), Random.Range(1, 2)), ForceMode2D.Impulse);
                StartCoroutine(Dead(sprite));
            }
        }
        if(!dead)
        {
            player.curFenceCount++;
            dead = true;
        }
    }
    IEnumerator Dead(SpriteRenderer sprite)
    {
        for (int i = 0; i < 20; i++)
        {
            sprite.color = new Color(1, 1, 1, 1.0f - (i * 0.1f));
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(sprite.gameObject);
        Destroy(gameObject);
    }
    protected override void Hit()
    {
        StartCoroutine(Shake(0.2f, 0.5f));
    }

    protected override void Start()
    {
        player = FindObjectOfType(typeof(Player)) as Player;
        originPos = new Vector3[shakeableObj.Length];
        for (int i = 0; i < shakeableObj.Length; i++)
        {
            originPos[i] = shakeableObj[i].localPosition;
        }
    }

    protected override void Update()
    {

    }

    IEnumerator Shake(float amount, float duration)
    {
        float timer = 0;
        while (timer <= duration)
        {

            for (int i = 0; i < shakeableObj.Length; i++)
            {
                shakeableObj[i].localPosition = (Vector3)Random.insideUnitCircle * amount + originPos[i];
            }

            timer += Time.deltaTime;
            yield return null;
        }
        for (int i = 0; i < shakeableObj.Length; i++)
        {
            shakeableObj[i].localPosition = (Vector3)Random.insideUnitCircle * amount + originPos[i];
        }
    }
}
