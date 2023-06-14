using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject bullet;
    float timerofbullet = 4f;
    void Update()
    {
        Fire();
    }
    void Fire() 
    {
        timerofbullet -= Time.deltaTime;
        if (timerofbullet <= 0)
        {
            timerofbullet = 4f;
            GameObject bulletGO = Instantiate(bullet, spawnPoint.transform.position,spawnPoint.transform.rotation) as GameObject;
            Rigidbody bulletRB= bulletGO.GetComponent<Rigidbody>();
            bulletRB.AddForce(bulletRB.transform.forward * 5f);
            Destroy(bulletGO, 1f);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
            Destroy(gameObject);
    }
}
