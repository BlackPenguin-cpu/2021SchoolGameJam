using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceEntity : Entity
{

    Vector3[] originPos;
    public Transform[] shakeableObj;

    protected override void Die()
    {
    }

    protected override void Hit()
    {
        StartCoroutine(Shake(0.2f, 0.5f));
    }

    protected override void Start()
    {
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
