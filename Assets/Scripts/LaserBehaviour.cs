using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.up * Speed;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("MainCamera"))
        {
            GameObject.Destroy(this.gameObject);
        }

        if (coll.CompareTag("Meteor"))
        {
            coll.transform.GetComponent<MeteorBehaviour>().Hit();
            GameObject.Destroy(this.gameObject);
        }
    }
}
