using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour

{
    public CharacterController controller;
    public Animator animator;

    [Header("Weapon")]
    public GameObject Weapon;


    [Header("Movement")]
    public float speed = 1f;
    public float gravity = -9.10f;
    public float jumpHeight = 1f;

    [Header("Ground Check")]
    public Transform ground_check;
    public float ground_distance = 0.4f;
    public LayerMask ground_mask;

    Vector3 velocity;
    bool isGrounded;





    // Start is called before the first frame update
    void Start()
    {
        Weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(ground_check.position, ground_distance, ground_mask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        animator.SetFloat("forward", z);
        animator.SetFloat("strafe", x);

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            speed = 3f;
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }



        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("jump", true);
        }

        
 
        

        else
        {
            animator.SetBool("jump", false);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        Gun();
    }
    void Gun()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("weapon", true);
            Weapon.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("weapon", false);
            Weapon.SetActive(false);
        }
    }

    }

