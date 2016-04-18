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

        // Face player, but zero out position y to fire straight
        Vector3 lookAtPosition = target.transform.position;
        lookAtPosition.y = transform.position.y;
        gameObject.transform.LookAt(lookAtPosition, Vector3.up);
        
        // Fire projectile
        GameObject projectileOBJ = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        projectileOBJ.layer = LayerMask.NameToLayer("EnemyProjectile");
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}
