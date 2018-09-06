using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

    static private List<ObjectAABB> aabbs = new List<ObjectAABB>();

    static public void Add(ObjectAABB obj)
    {
        aabbs.Add(obj);
        //print("there are " + aabbs.Count + " AABBs registered");
    }
    static public void Remove(ObjectAABB obj)
    {
        aabbs.Remove(obj);
        //print("there are " + aabbs.Count + " AABBs registered");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		foreach(ObjectAABB a in aabbs)
        {
            foreach(ObjectAABB b in aabbs)
            {
                if (a == b) continue;
                if (a.isDoneChecking || b.isDoneChecking) continue;

                if(a.CheckOverlap(b))
                {
                    //overlapping!
                    a.BroadcastMessage("OnOverlappingAABB", b);   //observer design pattern
                    b.BroadcastMessage("OnOverlappingAABB", a);
                }
            }
            a.isDoneChecking = true;
        }
	}
}
