using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;

    public GameObject ExplosionObject;
    public float Speed = 5f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb.velocity = Vector2.up * Speed;
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

            GameObject.Instantiate(ExplosionObject, this.transform.position, Quaternion.identity);
        }
    }
}
