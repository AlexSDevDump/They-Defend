using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RayAttack))]

public class GunController : MonoBehaviour
{
    private RectTransform crosshairPosition;
    private Camera cam;

    [SerializeField]
    private LayerMask targetLayer;

    [SerializeField]
    private float rateOfFire;

    [SerializeField]
    private float gunCooldown;

    [SerializeField]
    private float damage;

    Animator anim;
    RayAttack rayAtt;

    [SerializeField]
    private GameObject gunEffect;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rayAtt = GetComponent<RayAttack>();
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
        //Firing Logic
        if (gunCooldown <= 0.0f)
        {
            //Animation
            anim.SetBool("GunFiring", true);
            rayAtt.Attack(cam.ScreenPointToRay(Input.mousePosition), damage, 75f, targetLayer);
            gunCooldown = rateOfFire;
        }
    }
}
