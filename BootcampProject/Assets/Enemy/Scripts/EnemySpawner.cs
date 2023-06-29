using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    float timer = 4f;
    Transform spawnerLocation;
    void Start()
    {
        spawnerLocation= GetComponent<Transform>();
    }
    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else 
        {
            timer = 4f;
            EnemySpawn();
        }
    }

    void EnemySpawn()
    {
        Instantiate(enemy,new Vector3(spawnerLocation.position.x,spawnerLocation.position.y,spawnerLocation.position.z),Quaternion.identity);
        
    }
}
