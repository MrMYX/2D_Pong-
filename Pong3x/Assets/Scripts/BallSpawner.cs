using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public bool isBallAlive = true;
    [SerializeField] GameObject ballPrefab;
    void Awake()
    {

    }
    void Start()
    {
        CreateStartBall();
    }

    void CreateStartBall()
    {
        Instantiate(ballPrefab,
                    gameObject.transform.position,
                    Quaternion.identity);
    }

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
        Instantiate(ballPrefab,
                    gameObject.transform.position,
                    Quaternion.identity);
    }
}
