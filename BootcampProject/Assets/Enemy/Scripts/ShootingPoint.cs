using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootingPoint : MonoBehaviour
{
    Transform lazerTransform;
    public float distance;
    Vector3 position;
    void Start()
    {
        if (lazerTransform == null)
        {
            lazerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    void Update()
    {
        position = new Vector3(lazerTransform.position.x, lazerTransform.position.y + 1.4f, lazerTransform.position.z);
        if (distance < 30)
        {
            Vector3 direction = position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Yayýlma açýsýný belirleyin (örneðin, 45 derece)
            float spreadAngle = 45f;

            // Rastgele bir yayýlma açýsý oluþturun
            float randomSpread = Random.Range(-spreadAngle, spreadAngle);

            // Yayýlan rotasyonu hesaplayýn
            Quaternion spreadRotation = Quaternion.AngleAxis(randomSpread, Vector3.up);

            // Hedef rotasyonu ile yayýlan rotasyonu birleþtirin
            Quaternion finalRotation = targetRotation * spreadRotation;

            // Silahýn rotasyonunu düzgün bir þekilde dönüþtürün
            transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, Time.deltaTime * 20);
        }

    }
}
