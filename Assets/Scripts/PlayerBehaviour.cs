using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _shootTimer = 0f;

    public GameObject LaserObject;
    public GameObject ExplosionObject;
    public float Speed = 4f;
    public float MinTimeToShoot = 1f;    

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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

        _rb.velocity = dir * Speed;
    }

    void Update()
    {
        if (_shootTimer < MinTimeToShoot)
        {
            _shootTimer += Time.deltaTime;
        }        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (MinTimeToShoot > _shootTimer)
            return;

        _shootTimer = 0;

        if (LaserObject != null)
        {
            Vector3 pos = this.transform.position;
            GameObject.Instantiate(LaserObject, pos, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Meteor"))
        {
            GameObject.Instantiate(ExplosionObject, this.transform.position, Quaternion.identity);

            GameObject.Destroy(this.gameObject);

            GameObject.Find("Main Camera").GetComponent<GamePlay>().ShowRestartButton();
        }
    }
}
