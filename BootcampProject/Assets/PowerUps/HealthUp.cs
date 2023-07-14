using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    public GameObject pickupEffect;
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Pickup(other);
        }
    }
    void Pickup(Collider player){
        Debug.Log("hEALTHuP");
        Instantiate(pickupEffect, transform.position, transform.rotation);
        AliveObject aliveObject= player.GetComponent<AliveObject>();
        aliveObject.Heal(25);
        Destroy(gameObject);
    }
}
