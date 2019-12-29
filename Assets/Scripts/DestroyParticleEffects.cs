using UnityEngine;
using System.Collections;

public class DestroyParticleEffects : MonoBehaviour
{
    private ParticleSystem ps;


    public void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                DestroyParticles();
            }
        }
    }

    public void DestroyParticles()
    {
        Destroy(gameObject);
    }
}