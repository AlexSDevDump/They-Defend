using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnim : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    string boolToReset;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ResetParams()
    {
        anim.SetBool(boolToReset, false);
    }
}
