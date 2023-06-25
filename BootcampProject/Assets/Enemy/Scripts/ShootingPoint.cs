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

            // Yay�lma a��s�n� belirleyin (�rne�in, 45 derece)
            float spreadAngle = 45f;

            // Rastgele bir yay�lma a��s� olu�turun
            float randomSpread = Random.Range(-spreadAngle, spreadAngle);

            // Yay�lan rotasyonu hesaplay�n
            Quaternion spreadRotation = Quaternion.AngleAxis(randomSpread, Vector3.up);

            // Hedef rotasyonu ile yay�lan rotasyonu birle�tirin
            Quaternion finalRotation = targetRotation * spreadRotation;

            // Silah�n rotasyonunu d�zg�n bir �ekilde d�n��t�r�n
            transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, Time.deltaTime * 20);
        }

    }
}
