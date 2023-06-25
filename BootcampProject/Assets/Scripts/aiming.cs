using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiming : MonoBehaviour
{
    public Animator animator;
    public float range = 1000f;
    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2"))
        {
            animator.SetBool("aim", true);
        }
        if(Input.GetButtonUp("Fire2"))
        {
            animator.SetBool("aim", false);
        }
        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("fire", true);
        }
        else
        {
            animator.SetBool("fire", false);
        }


    }
}
