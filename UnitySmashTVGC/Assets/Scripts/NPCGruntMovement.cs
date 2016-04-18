using UnityEngine;
using System.Collections;

public class NPCGruntMovement : MonoBehaviour
{

    // Target
    public GameObject target = null;
    //public Vector3 aimVector;

    //// Enemy Movement
    //public float speed = 3f;
    //Vector3 movement;
    //Rigidbody enemyRigidBody;

    //Transform player;
    NavMeshAgent nav;

    // Use this for initialization  
    void Awake()
    {
        //enemyRigidBody = GetComponent<Rigidbody>();
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
    void Update()
    {
        //movement = movement.normalized * speed * Time.deltaTime;
        nav.SetDestination(target.transform.position);
    }

    //void FixedUpdate()
    //{
    //    float h = target.transform.position.x;
    //    float v = target.transform.position.z;

    //    // Move the enemy
    //    Move(h, v);
    //}

    //void Move(float h, float v)
    //{
    //    movement.Set(h, 0f, v);
    //    movement = movement.normalized * speed * Time.deltaTime;
    //    enemyRigidBody.MovePosition(transform.position + movement);
    //}

}
