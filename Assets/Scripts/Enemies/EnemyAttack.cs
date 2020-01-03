using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RayAttack))]

public class EnemyAttack : MonoBehaviour
{

    [SerializeField]
    private LayerMask targetLayer;

    RayAttack rayAtt;

    // Start is called before the first frame update
    void Start()
    {
        rayAtt = GetComponent<RayAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) { Attack(); }
    }

    void Attack()
    {
        Ray r = new Ray(transform.position, transform.right);
        rayAtt.Attack(r, 10f, 10f, targetLayer);
    }
}
