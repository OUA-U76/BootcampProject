using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Controller : MonoBehaviour
{
    public float walkSpeed = 2f;  // Yürüme hýzý
    public float rotationSpeed = 100f;  // Dönme hýzý

    private Animator animator;  // Animator bileþeni referansý
    private Rigidbody rb;  // Rigid body bileþeni referansý

    private void Start()
    {
        // Gerekli bileþen referanslarýný al
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Yürüme kontrolleri
        float moveHorizontal = Input.GetAxis("Horizontal");  // Yatay eksende hareket
        float moveVertical = Input.GetAxis("Vertical");  // Dikey eksende hareket

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);  // Hareket vektörü oluþtur

        // Yürüme animasyonunu tetikle
        if (movement.magnitude > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // Karakterin yönünü güncelle
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            Quaternion rotation = Quaternion.RotateTowards(rb.rotation, toRotation, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rotation);
        }

        // Karakteri hareket ettir
        rb.MovePosition(rb.position + movement * walkSpeed * Time.deltaTime);
    }
}

