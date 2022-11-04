using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipesPrefab;
    [SerializeField] GameObject pipesSpawnPoint;
    [SerializeField] float pipeDestroyTime = 8f;
    [SerializeField] float minHeightOffset = -2f;
    [SerializeField] float maxHeightOffset = 2f;

    public bool stopSpawn;

    void Start() 
    {
        StartCoroutine(SpawnPipes());
    }

    IEnumerator SpawnPipes()
    {
        while(!stopSpawn)
        {
            float heightOffset = UnityEngine.Random.Range(minHeightOffset, maxHeightOffset);

            // Spawns pipes into the game world
            GameObject instance = Instantiate(pipesPrefab, pipesSpawnPoint.transform.position + 
            new Vector3(0f, heightOffset, 0f), Quaternion.identity, transform);

            Destroy(instance, pipeDestroyTime);

            // Select a random time to spawn the pipes
            float randomTime = UnityEngine.Random.Range(1.5f, 4f);

            // Wait for a delay to spawn the next set of pipes
            yield return new WaitForSeconds(randomTime);
        }
    }
}
