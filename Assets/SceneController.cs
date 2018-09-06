using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public Track[] prefabTracks;
    List<Track> tracks = new List<Track>();
    const float trackCount = 5;

	void Start () {
        SpawnSomeTrack();
	}
	
	// Update is called once per frame
	void Update () {
        for(int i = tracks.Count - 1; i >= 0; i--)
        {
            if(tracks[i].isDead)
            {
                Destroy(tracks[i].gameObject);
                tracks.RemoveAt(i);
            }
        }

        if (tracks.Count < trackCount) SpawnSomeTrack();
	}

    void SpawnSomeTrack()
    {
        while (tracks.Count < trackCount)
        {
            Vector3 ptOut = new Vector3(0, .3f, 0); ;

            if (tracks.Count > 0) ptOut = tracks[tracks.Count - 1].pointOut.position;

            Track prefab = prefabTracks[Random.Range(0, prefabTracks.Length)];

            Vector3 ptIn = prefab.pointIn.position;

            Vector3 pos = (prefab.transform.position - ptIn) + ptOut;

            Track newTrack = Instantiate(prefab, pos, Quaternion.identity);
            tracks.Add(newTrack);
        }
    }
}
