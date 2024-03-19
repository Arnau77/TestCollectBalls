using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab = null;

    [SerializeField]
    private float maxPositionLimitForSpawning = 0;

    [SerializeField]
    private float minPositionLimitForSpawning = 0;

    [SerializeField]
    private float minTimeToSpawn = 0;

    [SerializeField]
    private float maxTimeToSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBall(Random.Range(minTimeToSpawn, maxTimeToSpawn)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnBall(float timeToSpawn)
    {
        yield return new WaitForSecondsRealtime(timeToSpawn);
        GameObject newBall = Instantiate(ballPrefab, transform);
        Vector3 newPosition = newBall.transform.position;
        newPosition.x = Random.Range(minPositionLimitForSpawning, maxPositionLimitForSpawning);
        newBall.transform.position = newPosition;
        StartCoroutine(SpawnBall(Random.Range(0, maxTimeToSpawn)));
    }
}
