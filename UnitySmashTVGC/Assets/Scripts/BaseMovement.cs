using UnityEngine;
using System.Collections;

public class BaseMovement : MonoBehaviour
{

    public float speed = 6f;

    Vector3 movement;
    Rigidbody objectRigidbody;

    void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        objectRigidbody.MovePosition(transform.position + movement);
    }
}
