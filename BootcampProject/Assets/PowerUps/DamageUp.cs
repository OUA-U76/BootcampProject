using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : MonoBehaviour
{
    public GameObject pickupEffect;
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Pickup(other);
        }
    }
    void Pickup(Collider player){
        Debug.Log("DamageUp");
        Instantiate(pickupEffect, transform.position, transform.rotation);
        Weapon weapon= player.GetComponent<Weapon>();
        weapon.DamageIncrease();
        Destroy(gameObject);
    }
}
