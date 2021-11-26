using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Player player;
    Transform target;

    Vector3 originPos;

    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        target = player.transform;
    }

    void FixedUpdate()
    {
        Vector3 desire = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desire, smoothSpeed);
        transform.position = smoothPosition;

        if (GameManager.Instance.CameraLookat)
        {
            LookAt();
        }
    }

    void LookAt()
    {
        transform.LookAt(target);
        Quaternion eulerRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        transform.rotation = eulerRotation;
    }

    public IEnumerator Shake(float _amount, float _duration)
    {
        float timer = 0;
        while (timer <= _duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originPos;

    }
}
