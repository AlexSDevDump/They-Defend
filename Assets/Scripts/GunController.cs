using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    private RectTransform crosshairPosition;
    private Camera cam;

    [SerializeField]
    private float rateOfFire;

    [SerializeField]
    private float gunCooldown;

    // Start is called before the first frame update
    void Start()
    {
        crosshairPosition = GetComponent<RectTransform>();
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCursorPosition();
        if(Input.GetKeyDown(KeyCode.Mouse0)) { Shoot(); }
        if(gunCooldown > 0.0f) { gunCooldown -= Time.deltaTime; }
    }

    void UpdateCursorPosition()
    {
        crosshairPosition.position = Input.mousePosition;
    }

    void Shoot()
    {
        int layerMask = LayerMask.GetMask("Enemies");
        if (gunCooldown <= 0.0f)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000f, layerMask))
            {
                Transform objectHit = hit.transform;

                Debug.Log("Hit " + objectHit);
            }
            else { Debug.Log("MISS"); }

            gunCooldown = rateOfFire;
        }
    }
}
