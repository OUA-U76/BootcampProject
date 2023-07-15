using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverKiller : MonoBehaviour
{
    public GameObject player;   
    private void OnCollisionEnter(Collision collision)
    {
        AliveObject aa=player.GetComponent<AliveObject>();
        aa.Damage(100);
    }
}
