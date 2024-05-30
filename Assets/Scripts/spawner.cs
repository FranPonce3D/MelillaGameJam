using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    [SerializeField] private GameObject[] obstaclePrefabs ;
    public float obstacleSpawnTime = 2f ;
    public float obstacleSpeed = 1f;

    private float timeUntilObstacleSpawn;

    public Rigidbody2D playerRB;


    private void Start()
    {
        Spawn();
    }

    private void Update()  {
        SpawnLoop() ;
        playerRB.velocity = Vector2.left * obstacleSpeed;
    }

    private void SpawnLoop() {
        timeUntilObstacleSpawn += Time.deltaTime ;

        if(timeUntilObstacleSpawn >= obstacleSpawnTime) {
            Spawn() ;
            timeUntilObstacleSpawn = 0f ;
            
        }

    }

    private void Spawn() {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            Spawn();
        }
    }*/



}

