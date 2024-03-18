using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab, transform);
        newBall.GetComponent<Ball>().ballDestroyed.AddListener(BallDestroyed);
    }

    private void BallDestroyed()
    {
        SpawnBall();
    }
}
