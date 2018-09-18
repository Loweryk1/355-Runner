using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public Track[] prefabTracks;
    public int score = 0;
    List<Track> tracks = new List<Track>();
    const float trackCount = 5;

    public const float trackSpeedMax = 10;
    public const float trackSpeedMin = 5;

    float slowmoTimer = 0;
    public float slowmoTimeMax = 3;

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

        //if slowMoTimer is > 0,.
        if (slowmoTimer > 0)
        {
            //set Track speed to trackSpeedMin
            SetTrackSpeed(trackSpeedMin);
            slowmoTimer -= Time.deltaTime;
        }
        else  //else,
        {
            //set Track speed to trackSpeedMax
            SetTrackSpeed(trackSpeedMax);
        }
        
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
    
    void SetSlowmoTimer()
    {
        slowmoTimer = slowmoTimeMax;
    }

    //create a function that updates the speed of every tack object every frame.
    void SetTrackSpeed(float trackSpeed)
    {
        for(int j = tracks.Count - 1; j >= 0; j--)
        {
            tracks[j].speed = trackSpeed;
        }
    }
}
