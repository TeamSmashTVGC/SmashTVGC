using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour
{
    private Rigidbody myRigidBody;
    private MeshCollider myCollider;
    private MeshRenderer myMeshRenderer;

	// Use this for initialization
	void Start ()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myCollider = GetComponent<MeshCollider>();
        myMeshRenderer = GetComponent<MeshRenderer>();
        //Destroy(myMeshRenderer);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Delete the rigid body and collider
        Destroy(myRigidBody);
        Destroy(myCollider);
    }
}
