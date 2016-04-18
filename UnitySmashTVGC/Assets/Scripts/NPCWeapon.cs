using UnityEngine;
using System.Collections;

public class NPCWeapon : MonoBehaviour
{
    // Target
    public GameObject target = null;  // when target is set, fire at target
    private Vector3 aimVector;

    // Weapon properties
    public float attackSpeed;
    public float attackRate;
    public GameObject projectile;
    
    // Use this for initialization
    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Attack the target
    public virtual void Attack()
    {
        if (target == null)
            return;

        // Find out where the target is
        aimVector = target.transform.position - transform.position;
        
        GameObject projectileOBJ = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        projectileOBJ.layer = LayerMask.NameToLayer("EnemyProjectile");
        Rigidbody projectileRB = projectileOBJ.GetComponent<Rigidbody>();
        projectileRB.velocity = aimVector * attackSpeed;
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}
