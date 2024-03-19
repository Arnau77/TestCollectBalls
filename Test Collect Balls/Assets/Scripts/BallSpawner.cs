using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Tooltip("The prefab of the ball that will spawn")]
    [SerializeField]
    private GameObject ballPrefab = null;

    [Tooltip("The max position in the X vector where the ball will spawn")]
    [SerializeField]
    private float maxPositionLimitForSpawning = 0;

    [Tooltip("The min position in the X vector where the ball will spawn")]
    [SerializeField]
    private float minPositionLimitForSpawning = 0;

    [Tooltip("The min time that the ball will take to spawn")]
    [SerializeField]
    private float minTimeToSpawn = 0;

    [Tooltip("The max time that the ball will take to spawn")]
    [SerializeField]
    private float maxTimeToSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBall(Random.Range(minTimeToSpawn, maxTimeToSpawn)));
    }

    /// <summary>
    /// This coroutine is called to spawn a ball
    /// </summary>
    /// <param name="timeToSpawn"> The time that has to pass before spawning the ball</param>
    private IEnumerator SpawnBall(float timeToSpawn)
    {
        yield return new WaitForSeconds(timeToSpawn);

        GameObject newBall = Instantiate(ballPrefab, transform);

        Vector3 newPosition = newBall.transform.position;
        newPosition.x = Random.Range(minPositionLimitForSpawning, maxPositionLimitForSpawning);
        newBall.transform.position = newPosition;

        StartCoroutine(SpawnBall(Random.Range(minTimeToSpawn, maxTimeToSpawn)));
    }
}
