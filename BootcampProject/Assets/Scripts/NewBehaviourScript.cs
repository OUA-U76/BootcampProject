using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Controller : MonoBehaviour
{
    public float walkSpeed = 2f;  // Y�r�me h�z�
    public float rotationSpeed = 100f;  // D�nme h�z�

    private Animator animator;  // Animator bile�eni referans�
    private Rigidbody rb;  // Rigid body bile�eni referans�

    private void Start()
    {
        // Gerekli bile�en referanslar�n� al
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Y�r�me kontrolleri
        float moveHorizontal = Input.GetAxis("Horizontal");  // Yatay eksende hareket
        float moveVertical = Input.GetAxis("Vertical");  // Dikey eksende hareket

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);  // Hareket vekt�r� olu�tur

        // Y�r�me animasyonunu tetikle
        if (movement.magnitude > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // Karakterin y�n�n� g�ncelle
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

