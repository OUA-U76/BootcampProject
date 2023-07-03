
using UnityEngine;

public class aiming : MonoBehaviour
{
    public Animator animator;
    public float range = 1000f;
    public GameObject hitEffect;
    public GameObject mainCam;
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
        if(Input.GetButton("Fire1"))
        {
            Shoot();
            animator.SetBool("fire", true);
        }
        else
        {
            animator.SetBool("fire", false);
        }


    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
            Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
