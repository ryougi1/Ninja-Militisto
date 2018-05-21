using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLightpos : MonoBehaviour {

    Vector3 StartPos;
    Vector3 randomPos;

    float TimeSinceRandomRefresh = 9999.0f;
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        setRandomPos(0.1f);
        RandomLerpPos(4.0f);
    }


    void RandomLerpPos(float speed)
    {
        Vector3 newPos = Vector3.Lerp(transform.position, randomPos, Time.deltaTime * speed);
        transform.position = newPos;
    }
    void setRandomPos(float interval)
    {
        if (TimeSinceRandomRefresh > interval)
        {
            randomPos = Random.insideUnitSphere;
            randomPos += StartPos;
            Debug.Log(randomPos);
            TimeSinceRandomRefresh = 0.0f;
        }
        else
        {
            TimeSinceRandomRefresh += Time.deltaTime;
        }
    }
}
