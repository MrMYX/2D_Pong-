using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    GameObject clone;
    [HideInInspector] public bool isBallAlive = false;
    [SerializeField] GameObject ballPrefab;
    void Update()
    {
        if(!isBallAlive)
        {
            StartCoroutine(CreateBall());
        }
    }
    IEnumerator CreateBall()
    {
        isBallAlive = true;
        yield return new WaitForSeconds(1f);
        clone = Instantiate(ballPrefab,
                    gameObject.transform.position,
                    Quaternion.identity);
    } 
    public GameObject SetInstanceBall()
    {
        return clone;
    }

}