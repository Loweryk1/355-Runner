using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {

    public Transform pointIn;
    public Transform pointOut;

    public Transform[] prefabSpawnPoints;
    List<Vector3> spawnPointsUsed = new List<Vector3>();

    int spawnNumber;
    public int spawnMin;
    public int spawnMax;

    public GameObject prefabWall;
    public GameObject prefabHealth;
    const float speed = 10;

    [HideInInspector] public bool isDead = false;

    void Start()
    {
        if (prefabSpawnPoints.Length == 0) return;
        if (!prefabWall) return;
        if (!prefabHealth) return;
        spawnNumber = Random.Range(spawnMin, spawnMax);
        print(spawnNumber);
        for (int i = 0; i < spawnNumber; i++) {
            // Get a random position:
            int randIndexPrefab = Random.Range(0, prefabSpawnPoints.Length);
            Vector3 spawnPos = prefabSpawnPoints[randIndexPrefab].position;

            for(int j = spawnPointsUsed.Count-1; j >= 0; j--)
            {
                if(spawnPos == spawnPointsUsed[j])
                {
                    switch(randIndexPrefab)
                    {
                        case 0:
                            spawnPos = prefabSpawnPoints[randIndexPrefab + 1].position;
                            break;
                        case 1:
                            int thisOrThat = Random.Range(0, 1);
                            if(thisOrThat == 0)
                            {
                                spawnPos = prefabSpawnPoints[0].position;
                            } else
                            {
                                spawnPos = prefabSpawnPoints[prefabSpawnPoints.Length - 1].position;
                            }
                            break;
                        case 2:
                            spawnPos = prefabSpawnPoints[randIndexPrefab - 1].position;
                            break;
                    }
                }
            }
            spawnPointsUsed.Add(spawnPos);

            // Spawn a wall, parent it to this chunk of track:
            Instantiate(prefabWall, spawnPos, Quaternion.identity, transform);
        }
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;

        if(pointOut.position.z < -5)
        {
            isDead = true;
        }
    }


}
