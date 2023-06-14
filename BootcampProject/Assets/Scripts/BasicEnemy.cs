using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    Transform characterTransform;
    NavMeshAgent nav;

    private void Awake()
    {
        characterTransform = GameObject.FindGameObjectWithTag("Character").transform;
        nav= GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        nav.destination=characterTransform.position;
    }
}
