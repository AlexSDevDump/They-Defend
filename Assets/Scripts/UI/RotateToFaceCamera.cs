using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToFaceCamera : MonoBehaviour
{
    public Camera camPos;
    // Start is called before the first frame update
    void Start()
    {
        camPos = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + camPos.transform.rotation * Vector3.forward,
            camPos.transform.rotation * Vector3.up);
    }
}
