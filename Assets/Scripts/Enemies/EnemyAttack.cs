using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RayAttack))]

public class EnemyAttack : MonoBehaviour
{
    public LayerMask targetLayer;
    private EnemySO SO;
    public float rateOfFire;
    public float range;
    public float damage;
    RayAttack rayAtt;

    // Start is called before the first frame update
    void Start()
    {
        rayAtt = GetComponent<RayAttack>();
    }

    public void SetSO(EnemySO _so)
    {
        SO = _so;
        rateOfFire = SO.rateOfFire;
        range = SO.range;
        damage = SO.damage;
    }

    public void StartAttack()
    {
        InvokeRepeating("Attack", 0f, rateOfFire);
    }

    public void StopAttack() => CancelInvoke();

    void Attack()
    {
        Ray r = new Ray(transform.position, transform.right);
        rayAtt.Attack(r, damage, range, targetLayer);
        Debug.DrawRay(transform.position, transform.right * 10f, Color.red, 0.1f);
    }
}
