using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Player player;
    Transform target;

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
            transform.LookAt(target);
    }
}
