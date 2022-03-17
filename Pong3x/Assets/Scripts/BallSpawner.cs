using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    GameObject clone;
    public List<GameObject> _clones = new List<GameObject>();
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
        SetInstanceBall();

    } 
    public GameObject SetInstanceBall()
    {
        return clone;
    }

}