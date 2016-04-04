using UnityEngine;
using System.Collections;

public class Brain : MonoBehaviour
{
    // Root 
    [HideInInspector]
    public Transform root;
    
    // Player
    [HideInInspector]
    public GameObject player;

    // Hit collider
    [HideInInspector]
    public SphereCollider hitCollider;
    
    // Debugging Visuals
    public bool showState = false;
    [HideInInspector]
    public MeshRenderer stateRenderer;
    
    // NPC Attack
    public NPCWeapon npcWeapon;

    // The current state
    [HideInInspector]
    public AIState currentState;
    
    // States
    [HideInInspector]
    public AIStateIdle idleState;
    [HideInInspector]
    public AIStateAlert alertState;
    [HideInInspector]
    public AIStateAttack attackState;
    [HideInInspector]
    public AIStatePatrol patrolState;
    [HideInInspector]
    public AIStateHide hideState;
    [HideInInspector]
    public AIStateDead deadState;

    // On Awake, initialize states
    private void Awake()
    {
        idleState = new AIStateIdle(this);
        alertState = new AIStateAlert(this);
        attackState = new AIStateAttack(this);
        patrolState = new AIStatePatrol(this);
        hideState = new AIStateHide(this);
        deadState = new AIStateDead(this);
    }
    
    // On change of state, call exit for the previous state, then enter for the next state
    public void ChangeState(AIState toState)
    {
        if (currentState != null)
            currentState.ExitState();
        currentState = toState;
        currentState.EnterState();
    }

    // Use this for initialization of current state in sub classes
    public virtual void Init()
    {
        root = transform.root;
        
        hitCollider = root.GetComponent<SphereCollider>();
        
        stateRenderer = GetComponent<MeshRenderer>();
        if (!showState)
            if (stateRenderer != null)
                stateRenderer.enabled = false;
        
        // Get the player
        player = GameObject.FindGameObjectWithTag("Player");

        // Listen for health death.
        root.GetComponent<Health>().Died += OnDeath;
    }

    void Start ()
    {
        Init();
        npcWeapon = root.GetComponent<NPCWeapon>();
    }

    // Update is called once per frame
    void Update () {
        if(currentState != null)
            currentState.UpdateState();
    }

    // Hide when disabled
    void OnDisable()
    {
        ChangeState(hideState);
    }

    // Show when enabled
    void OnEnable()
    {
        ChangeState(idleState);
    }

    //
    // State Actions
    //

    // Idle
    public virtual void Idle()
    {
        if (stateRenderer != null)
            stateRenderer.material.color = Color.black;
    }

    // Attack the target
    public virtual void Attack()
    {
        if (stateRenderer != null)
            stateRenderer.material.color = Color.red;
    }    
    
    // Alert
    public virtual void Alert()
    {
        if (stateRenderer != null)
            stateRenderer.material.color = Color.cyan;
    }

    // Patrol move around
    public virtual void Patrol()
    {
        if (stateRenderer != null)
            stateRenderer.material.color = Color.green;
    }


    // Dead
    public virtual void Dead()
    {
        // Turn off the mesh renderer
        if (stateRenderer != null)
            stateRenderer.material.color = Color.gray;
        
        Destroy(root.gameObject);
    }

    // Hide
    public virtual void Hide()
    {
        if (stateRenderer != null)
            stateRenderer.material.color = Color.blue;

        // Hide for a time
        if (hitCollider != null)
            hitCollider.enabled = false;
    }

    // Show
    public virtual void Show()
    {
        // show collider
        if (hitCollider != null)
            hitCollider.enabled = true;
    }

    // Show On Condition
    public virtual void ShowOnCondition()
    {
        // Go to idle
        ChangeState(idleState);
    }

    /// <summary>
    /// You're dead, so DIE!!!
    /// </summary>
    public virtual void OnDeath(object sender, System.EventArgs e)
    {
        // Change the state to the dead state
        ChangeState(deadState);
    }
}
