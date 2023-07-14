using UnityEngine;
using UnityEngine.AI;

public class FlyingEnemy : MonoBehaviour
{
    public Transform target; 
    public float moveSpeed = 5f; 
    public float retreatDistance = 2f; 
    public float desiredHeight = 10f; 
    public float retreatDuration = 10f; 

    public float enemyHP = 50f;
    private Rigidbody rb;
    private Vector3 initialPosition; 
    private bool isRetreating = false; 
    private float retreatTimer = 0f; 
    private Vector3 retreatDirection;

    private NavMeshAgent navmesh;
    public GameObject aa;
    float distance;
    public GameObject bulletSpawnLocation;
    RaycastHit hit;
    private void Awake()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position; 
        retreatDirection = (initialPosition - target.position).normalized;
        distance = Vector3.Distance(target.position, aa.transform.position);
        
    }

    void Update()
    {
        distance = Vector3.Distance(target.position, aa.transform.position);
        EnemyShooting();
        if (isRetreating)
        {
            rb.velocity = retreatDirection * moveSpeed;

            retreatTimer += Time.deltaTime;
            if (retreatTimer >= retreatDuration)
            {
                isRetreating = false;
                retreatTimer = 0f;
            }
        }
        else
        {
            Vector3 moveDirection = (target.position - transform.position).normalized;
            rb.velocity = moveDirection * moveSpeed;

            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget < Mathf.Max(retreatDistance, 1.5f))
            {
                isRetreating = true;
            }

            Vector3 lookDirection = -(target.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            isRetreating = true;
            //Vector3 moveDirection = (target.position - transform.position).normalized;
            //Vector3 reverseDirection = -moveDirection;
            //Quaternion targetRotation = Quaternion.LookRotation(reverseDirection, Vector3.up);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1f);
        }
    }
    void EnemyShooting()
    {
        if (Physics.Raycast(bulletSpawnLocation.transform.position, bulletSpawnLocation.transform.forward, out hit, 30))
        {
            if (hit.transform.tag == "Player")
            { if (distance <= 2)
                {
                    var aliveObject = hit.transform.GetComponent<AliveObject>();
                    Debug.Log("Hitted");
                    if (aliveObject != null)
                    {
                        aliveObject.Damage(10);
                    }
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(bulletSpawnLocation.transform.position, bulletSpawnLocation.transform.forward * 30);
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
        Destroy(gameObject);
    }
}
