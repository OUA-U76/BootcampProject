using UnityEngine;
using UnityEngine.AI;

public class FlyingEnemy : MonoBehaviour
{
    public Transform target; 
    public float moveSpeed = 5f; 
    public float retreatDistance = 2f; 
    public float desiredHeight = 10f; 
    public float retreatDuration = 10f; 

    private Rigidbody rb;
    private Vector3 initialPosition; 
    private bool isRetreating = false; 
    private float retreatTimer = 0f; 
    private Vector3 retreatDirection;

    private NavMeshAgent navmesh;
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
        
    }

    void Update()
    {
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
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
    //    {
    //        isRetreating = true;
    //        //Vector3 moveDirection = (target.position - transform.position).normalized;
    //        //Vector3 reverseDirection = -moveDirection;
    //        //Quaternion targetRotation = Quaternion.LookRotation(reverseDirection, Vector3.up);
    //        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1f);
    //    }

    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        var aliveObject = collision.gameObject.GetComponent<AliveObject>();

    //        if (aliveObject != null)
    //        {
    //            aliveObject.Damage(20);
    //        }
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")||other.CompareTag("Player"))
        {
            isRetreating = true;
        }if (other.CompareTag("Player"))
        {
            var aliveObject = other.gameObject.GetComponent<AliveObject>();

               if (aliveObject != null)
               {
                     aliveObject.Damage(20);
               }
        }
    }
}
