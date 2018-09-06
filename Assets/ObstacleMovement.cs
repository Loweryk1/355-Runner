using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

    const float speed = -10;
    const float deadZone = -8;
    bool isDead = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        if(transform.position.z < deadZone)
        {
            isDead = true;
        }

        if (isDead)
        {
            Dispose(); 
        }
	}

    // Dispose is called when you're ready to kill the object.
    void Dispose()
    {
        
    }
}
