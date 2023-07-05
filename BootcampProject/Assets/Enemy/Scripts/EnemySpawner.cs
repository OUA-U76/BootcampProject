using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    public float timer;
    Transform spawnerLocation;

    Timer ttimer;
    void Start()
    {
        ttimer = FindObjectOfType<Timer>();
        timer = 10f;
        spawnerLocation= GetComponent<Transform>();
    }
    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else 
        {
            timer = ttimer.enemyTimer;
            EnemySpawn();
        }
    }

    void EnemySpawn()
    {
        Instantiate(enemy,new Vector3(spawnerLocation.position.x,spawnerLocation.position.y,spawnerLocation.position.z),Quaternion.identity);
        
    }
}
