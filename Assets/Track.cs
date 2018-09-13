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
    public GameObject prefabWallSmall;

    List<GameObject> prefabObjects = new List<GameObject>();
    
    const float speed = 10;

    [HideInInspector] public bool isDead = false;

    void Start()
    {
        // check to make sure all spawn points and game objects have been set.
        if (prefabSpawnPoints.Length == 0) return;
        if (!prefabWall) return;
        if (!prefabHealth) return;
        if (!prefabWallSmall) return;

        //Add the prefabs to prefObjects.
        prefabObjects.Add(prefabWall);
        prefabObjects.Add(prefabHealth);
        prefabObjects.Add(prefabWallSmall);
        //for (int k = prefabObjects.Count - 1; k >= 0; k--) print(prefabObjects[k]);

        // Sets the number of prefabs to spawn on this Track.
        spawnNumber = (Random.Range(0, spawnMax)) + spawnMin;
        
        for (int i = 0; i < spawnNumber; i++) {
            // Get a random position and store it as spawnPos:
            int randIndexPrefab = Random.Range(0, prefabSpawnPoints.Length);
            Vector3 spawnPos = prefabSpawnPoints[randIndexPrefab].position;

            
            //Used to check if current spawnPos has been used on this track before, by comparing it to stored positions within spawnPointsUsed.
            for(int j = spawnPointsUsed.Count-1; j >= 0; j--)
            {
                // if spawnPos has already been used to spawn an object...
                if(spawnPos == spawnPointsUsed[j])
                {
                    // ...change spawnPos to a new valid spawn position.
                    int thisOrThat = Random.Range(0, 1);
                    switch (randIndexPrefab)
                    {
                        case 0:
                            if (thisOrThat == 0)
                            { //spawn center
                                spawnPos = prefabSpawnPoints[randIndexPrefab + 1].position;
                            } else
                            { //spawn right
                                spawnPos = prefabSpawnPoints[randIndexPrefab + 2].position;
                            }
                            break;
                        case 1:
                            if(thisOrThat == 0)
                            { //spawn left
                                spawnPos = prefabSpawnPoints[0].position;
                            } else
                            { //spawn right
                                spawnPos = prefabSpawnPoints[prefabSpawnPoints.Length - 1].position;
                            }
                            break;
                        case 2:
                            if (thisOrThat == 0)
                            { //spawn center
                                spawnPos = prefabSpawnPoints[randIndexPrefab - 1].position;
                            } else
                            { //spawn left
                                spawnPos = prefabSpawnPoints[randIndexPrefab - 2].position;
                            }
                            break;
                    }
                }
            }
            //Add the current spawnPos to spawnPointsUsed.
            spawnPointsUsed.Add(spawnPos);

            int indexOfObject = Random.Range(0, prefabObjects.Count);
            GameObject spawnAObject = prefabObjects[indexOfObject];

            // Spawn a wall, parent it to this chunk of track:
            Instantiate(spawnAObject, spawnPos, Quaternion.identity, transform);
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
