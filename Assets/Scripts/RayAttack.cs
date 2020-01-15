using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAttack : MonoBehaviour
{
    public void Attack(Ray rayDirection, float damage, float range, LayerMask targetLayer)
    {
        //Firing Logic
        RaycastHit hit;
        Debug.DrawRay(rayDirection.origin, rayDirection.direction * range, Color.red, 1f);

        if (Physics.Raycast(rayDirection, out hit, range, targetLayer))
        {
            Transform objectHit = hit.transform;

            Health h = objectHit.transform.root.GetComponentInChildren<Health>();

            if (h != null)
            {
                h.UpdateHealth(damage);
            }
        }
        else { Debug.Log("MISS"); }
    }
}

