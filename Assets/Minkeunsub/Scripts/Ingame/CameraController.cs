using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraState
{
    FOLLOW,
    SHAKE
}

public class CameraController : MonoBehaviour
{

    Player player;
    Transform target;

    Vector3 originPos;

    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    CameraState cameraState = CameraState.FOLLOW;

    Vector3 shakeVector;
    public float shakeAmount;
    float shakeTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        target = player.transform;
    }

    void FixedUpdate()
    {
        switch (cameraState)
        {
            case CameraState.FOLLOW:
                shakeVector = Vector3.zero;
                break;
            case CameraState.SHAKE:
                if(shakeTime > 0)
                {
                    shakeVector = Random.insideUnitSphere * shakeAmount;
                    shakeTime -= Time.deltaTime;
                }
                else
                {
                    shakeTime = 0;
                    cameraState = CameraState.FOLLOW;
                }
                break;
            default:
                break;
        }

        Vector3 desire = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desire, smoothSpeed);
        transform.position = smoothPosition + shakeVector;

        if (GameManager.Instance.CameraLookat)
        {
            LookAt();
        }
    }

    public void ShakeForTime(float time)
    {
        shakeTime = time;
        cameraState = CameraState.SHAKE;
    }

    void LookAt()
    {
        transform.LookAt(target);
        Quaternion eulerRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        transform.rotation = eulerRotation;
    }
}
