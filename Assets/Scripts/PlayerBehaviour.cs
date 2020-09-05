using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private float shootTimer = 0f;

    public float Speed = 4f;
    public float MinTimeToShoot = 1f;
    public GameObject LaserObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }

        rb.velocity = dir * Speed;
    }

    void Update()
    {
        if (shootTimer < MinTimeToShoot)
        {
            shootTimer += Time.deltaTime;
        }        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (MinTimeToShoot > shootTimer)
            return;

        shootTimer = 0;

        if (LaserObject != null)
        {
            Vector3 pos = this.transform.position;
            GameObject.Instantiate(LaserObject, pos, Quaternion.identity);
        }
    }
}
