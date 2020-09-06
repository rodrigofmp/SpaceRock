using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreator : MonoBehaviour
{
    public GameObject MeteorObject;
    public float MinTimeToCreate = 1f;
    public float MaxTimeToCreate = 3f;

    private float _timeToNextCreation;
    private float _countTimer;
    private float _xMin;
    private float _xMax;

    void Start()
    {
        float horizontalExtension = Camera.main.orthographicSize * Screen.width / Screen.height;
        _xMin = -horizontalExtension * 0.8f;
        _xMax = horizontalExtension * 0.8f;

        GenerateNextTime();
    }

    void Update()
    {
        _countTimer += Time.deltaTime;
        if (_countTimer >= _timeToNextCreation)
        {
            _countTimer = 0;
            GenerateNextTime();

            Vector3 pos = transform.position;
            pos.x = Random.Range(_xMin, _xMax);
            GameObject.Instantiate(MeteorObject, pos, Quaternion.Euler(0, 0, Random.Range(0, 359)));
        }
    }

    void GenerateNextTime()
    {
        _timeToNextCreation = Random.Range(MinTimeToCreate, MaxTimeToCreate);
    }
}
