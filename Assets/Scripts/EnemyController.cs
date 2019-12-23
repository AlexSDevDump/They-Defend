using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
}
