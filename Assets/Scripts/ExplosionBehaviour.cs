using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float LifeTime = 0.8f;

    private float _lifeTime = 0;
    
    void Update()
    {
        _lifeTime += Time.deltaTime;
        if (_lifeTime >= LifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
