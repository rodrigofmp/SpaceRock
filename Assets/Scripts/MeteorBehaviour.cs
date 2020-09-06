using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _renderer;

    public GameObject ExplosionObject;
    public float Speed = 5f;
    public int Health = 3;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        _rb.velocity = Vector2.down * Speed;
    }

    public void Hit()
    {
        Health--;

        switch(Health)
        {
            case 2:
                _renderer.color = Color.yellow;
                break;
            case 1:
                _renderer.color = Color.red;
                break;
            default:
                _renderer.color = new Color(122f, 66f, 6f);
                break;
        }

        if (Health <= 0)
        {
            GameObject.Instantiate(ExplosionObject, transform.position, Quaternion.identity);
            GameObject.Destroy(this.gameObject);
        }
    }
}
