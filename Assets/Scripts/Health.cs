using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthMax, healthCurrent;
    public HealthBar hpBar;

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
    }

    public void UpdateHealth(float valueUpdate)
    {
        healthCurrent -= valueUpdate;
        UpdateHealthBar();
        CheckHealth();
    }

    public void CheckHealth()
    {
        if (healthCurrent <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void SetMaxHP(float max)
    {
        healthMax = max;
        ResetHealth();
    }

    private void ResetHealth()
    {
        healthCurrent = healthMax;
        UpdateHealthBar();

    }

    private void UpdateHealthBar()
    {
        if(hpBar != null)
        {
            hpBar.SetHealthBarPercent(healthCurrent, healthMax);
        }
    }
}
