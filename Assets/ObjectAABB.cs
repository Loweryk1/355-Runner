using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAABB : MonoBehaviour {

    float width;
    float height;
    float depth;

	// Use this for initialization
	void Start () {     //Pass in the object?
		//Store GameObject's width (x) under width.
        //Store GameObject's height (y) under height.
        //Store GameObject's depth (z) under depth.
	}
	
	// Update is called once per frame
	void checkForCollision () {     //Pass in an AABB for another GameObject to check for collision.   
        //If this GameObject's x position is in the other GameObject's x position, return true.
        //If this GameObject's y position is in the other GameObject's y position, return true.
        //If this GameObject's z position is in the other GameObject's z position, return true.
        return false;
	}

    
}
