using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthMax, healthCurrent;

    // Start is called before the first frame update
    void Start()
    {
        healthCurrent = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageToTake)
    {
        healthCurrent -= damageToTake;
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
        Debug.Log("DEAD");
        Destroy(gameObject);
    }
}
