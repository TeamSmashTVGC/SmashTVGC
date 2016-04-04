using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public int damage = 10;
    public float speed = 50f;
    public float damageVelocityMin = 30f;
    public float damageVelocityMax = 50f;

    private Rigidbody projectileRB;

	// Use this for initialization
	void Start () {
        projectileRB = GetComponent<Rigidbody>();
	}

    // On Collision apply damage
    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("hit " + coll.gameObject.name);
        Health otherHealth = coll.gameObject.GetComponent<Health>();
        if (otherHealth != null)
        {
            otherHealth.Damage(damage);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        // Should destroy itself when out of screen

	}
}
