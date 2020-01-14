using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemySO SO;
    public Health hp;
    public EnemyAttack attack;
    public float speed;
    public bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }
    void Setup()
    {
        speed = SO.speed;
        hp = GetComponent<Health>();
        hp.SetMaxHP(SO.maxHealth);
        attack = GetComponent<EnemyAttack>();
        attack.SetSO(SO);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack == false) { MoveForward(); }
    }

    void MoveForward()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        Vector3 forwardSensor = transform.TransformDirection(Vector3.right);

        if (!isAttack)
        {
            if (Physics.Raycast(transform.position, forwardSensor, out hit, SO.range, attack.targetLayer))
            {
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject + " spotted!");
                    isAttack = true;
                    attack.StartAttack();
                }
            }
        }

        else if (isAttack)
        {
            if (!Physics.Raycast(transform.position, forwardSensor, out hit, SO.range, attack.targetLayer))
            {
                Debug.Log("Nothing spotted!");
                isAttack = false;
                attack.StopAttack();
            }
        }
    }
}
