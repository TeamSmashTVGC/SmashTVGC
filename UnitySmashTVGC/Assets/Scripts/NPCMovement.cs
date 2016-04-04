using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour {
    // Speed
    public float speed = 5f;

    // Destination
    public Vector3 destination;
    public float remainingDistance = 1000f;
    public float stoppingDistance = 1f;

    // Rigid body
    private Rigidbody myRigidBody;

    // Rigid body variables
    public Vector3 directionVector;
    
    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Tell the NPC where to go
    public void GoTo(Vector3 goToPoint)
    {
        destination = goToPoint;
    }

    public bool ReachedWayPoint()
    {
        directionVector = destination - myRigidBody.position;
        // Get the distance to our destination
        remainingDistance = directionVector.magnitude;

        if (remainingDistance < stoppingDistance)
            return true;
        else
            return false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // calculate the new direction vector
        directionVector = destination - myRigidBody.position;
        directionVector = directionVector.normalized * speed;

        Debug.Log("remaining distance is " + remainingDistance);

        // Move the rigidBody
        myRigidBody.velocity = directionVector;
    }
}
