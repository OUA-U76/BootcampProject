using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float distance;
    public Transform target;
    Vector3 position;
    Animator enemyAnimator;

    public float enemyHP = 100f;

    RaycastHit hit;
    public float bulletDistance;
    public GameObject bulletSpawnLocation;

    public Transform lazerTransform;
    float shootingTimer = 0f;
    float shootingInterval = 0.1f;

    [SerializeField] AudioSource shootingAudio;
    [SerializeField] GameObject muzzleFlash;
    [SerializeField] Transform muzzleFlashPosition;

    NavMeshAgent navmesh;
    void Start()
    {
        navmesh=GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        if (target == null)
        {
            target=GameObject.FindGameObjectWithTag("Player").transform;
        }if (lazerTransform == null)
        {
            lazerTransform = GameObject.FindGameObjectWithTag("bulletPoint").transform;
        }
        navmesh.destination = target.position;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);
        position = new Vector3(target.position.x, transform.position.y, target.position.z);
        enemyAnimator.SetFloat("distance", distance);

        if (distance > 30)
            navmesh.destination = target.position;

        if (distance > 40)
            navmesh.speed = 6;
        else if(distance<35)
            navmesh.speed = 3.5f;

        if (distance < 30) 
        {
            transform.LookAt(position);

            shootingTimer += Time.deltaTime;
            if (shootingTimer >= shootingInterval)
            {
                enemyAnimator.SetTrigger("combat");

                EnemyShooting();
                shootingTimer = 0f;
            }
        }
        else 
        {
            enemyAnimator.SetTrigger("idle");

        }
    }

    public void takeDamage(float damage)  //Silahlarin verdigi hasara gore hasar girilecek ve silahlarda hasar veren script icinde kullanilacak. "Kaan"
    {                                        //Dusman icin kullanilan tag=Enemy
        enemyHP -= damage;
        if (enemyHP <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        enemyAnimator.SetBool("enemyDeath", true);
        Destroy(gameObject,60f);
    }

    private void OnCollisionEnter(Collision collision) //Bu metot sadece hasar aldigi zaman ne oldugunu gormek icin yazildi. Silah ates ettigi zaman raycast icin hit.transform.tag=="Enemy" seklinde olucak. "Kaan".
    {
        if (collision.gameObject.CompareTag("deneme"))
        {
            takeDamage(100);
            Debug.Log("Collision DETECTED");
            Destroy(gameObject, 10);
        }
    }

    void EnemyShooting()
    {
        if (Physics.Raycast(bulletSpawnLocation.transform.position, bulletSpawnLocation.transform.forward, out hit, bulletDistance))
        {
            if (hit.transform.tag == "Player")
            {
                Debug.Log("Hitted");
                GameObject Flash = Instantiate(muzzleFlash, muzzleFlashPosition);
                Destroy(Flash, 0.1f);
                Player playerHP = hit.transform.GetComponent<Player>();
                shootingAudio.Play();
                playerHP.TakeDamage(20);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(bulletSpawnLocation.transform.position, bulletSpawnLocation.transform.forward * bulletDistance);
    }
}
