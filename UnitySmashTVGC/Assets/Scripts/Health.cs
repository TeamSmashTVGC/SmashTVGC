using UnityEngine;
using System.Collections;
using System;

public class HealthDamagedEventArgs : EventArgs
{
    private HealthDamagedEventArgs() { }
    public HealthDamagedEventArgs(int damageAmount)
    {
        DamageAmount = damageAmount;
    }

    public int DamageAmount { get; private set; }
}

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    
    public int health { get; private set; }
    public bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

    public bool IsInvulnerable { get; set; }

    public event EventHandler Damaged;
    public event EventHandler Died;
    
    void Start()
    {
        health = maxHealth;
    }

    public void SetMaxHealth(int newMaxHealth)
    {
        if (newMaxHealth <= 0)
        {
            return;
        }

        maxHealth = newMaxHealth;
        health = maxHealth;
    }

    public void Heal(int healAmount)
    {
        if (healAmount <= 0)
        {
            return;
        }

        if (IsDead)
        {
            return;
        }

        health += healAmount;
        health = Mathf.Min(health, maxHealth);
    }

    public void Damage(int damageAmount)
    {
        if (damageAmount <= 0)
        {
            return;
        }

        if (IsDead)
        {
            return;
        }

        if (IsInvulnerable)
        {
            return;
        }
        
        health = Mathf.Max(0, health - damageAmount);

        if (Damaged != null)
        {
            Damaged(this, new HealthDamagedEventArgs(damageAmount));
        }

        if (IsDead && Died != null)
        {
            Died(this, new EventArgs());
        }
    }
}
