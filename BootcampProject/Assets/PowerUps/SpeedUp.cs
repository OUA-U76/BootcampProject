using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;


public class SpeedUp : MonoBehaviour
{
    public GameObject pickupEffect;
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Pickup(other);
        }
    }
    void Pickup(Collider player){
        Debug.Log("SpeedUp");
        Instantiate(pickupEffect, transform.position, transform.rotation);
        ThirdPersonController tpc = player.gameObject.GetComponent<ThirdPersonController>();
        tpc.SpeedIncrease();
        Destroy(gameObject);
    }
}
