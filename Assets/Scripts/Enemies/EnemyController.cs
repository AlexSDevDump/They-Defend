using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemySO SO;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();

        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(gameObject.layer);
        }
    }

    void MoveForward()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    void Setup()
    {
        speed = SO.speed;
        Health hp = GetComponent<Health>();
        hp.SetMaxHP(SO.maxHealth);
    }
}
