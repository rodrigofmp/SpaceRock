using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorExplosionBehaviour : MonoBehaviour
{
    private float _lifeTime = 0;
    private ParticleSystem _ps;

    void Start()
    {
        _ps = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        _lifeTime += Time.deltaTime;
        if (_lifeTime >= _ps.main.duration)
        {
            Destroy(this.gameObject);
        }
    }
}
