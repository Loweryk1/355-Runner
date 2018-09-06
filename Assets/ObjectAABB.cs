using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAABB : MonoBehaviour {

    MeshRenderer _mesh;      // private C# field

    public MeshRenderer mesh    // C# property
    {
        get
        {
            if (!_mesh) _mesh = GetComponent<MeshRenderer>();     // "lazy" initialization
            return _mesh;
        }
    }
    public Bounds bounds    // C# property
    {
        get
        {
            return mesh.bounds;
        }
    }

    [HideInInspector] public bool isDoneChecking = false;
    [HideInInspector] public bool isOverlapping = false;

	// Use this for initialization
	void Start () {
        CollisionController.Add(this);
	}
    void OnDestroy()
    {
        CollisionController.Remove(this);
    }
	
	// Update is called once per frame
	void Update () {
        isDoneChecking = false;
        isOverlapping = false;
	}

    void OnDrawGizmos()
    {
        Gizmos.color = isOverlapping ? Color.red : Color.white;
        Gizmos.DrawWireCube(transform.position, mesh.bounds.size);
    }
    /// <summary>
    /// Checks to see if some other AABB overlaps this AABB.
    /// </summary>
    /// <param name="other">The other AABB component to check against.</param>
    /// <returns>If true, the two AABBs overlap.</returns>
    public bool CheckOverlap(ObjectAABB other)
    {
        if (other.bounds.min.x > this.bounds.max.x) return false;
        if (other.bounds.max.x < this.bounds.min.x) return false;

        if (other.bounds.min.y > this.bounds.max.y) return false;
        if (other.bounds.max.y < this.bounds.min.y) return false;

        if (other.bounds.min.z > this.bounds.max.z) return false;
        if (other.bounds.max.z < this.bounds.min.z) return false;

        return true;
    }

    void OnOverlappingAABB(ObjectAABB other)
    {
        isOverlapping = true;
    }

    
}
