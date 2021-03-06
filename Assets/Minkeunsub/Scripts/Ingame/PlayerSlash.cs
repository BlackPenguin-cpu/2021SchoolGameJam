using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    CameraController main_camera;
    public Player player;

    private void Start()
    {
        main_camera = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            main_camera.ShakeForTime(0.2f);
            ParticleSystem system = player.Attack();
            system.transform.position = transform.position;
        }
    }
}
