using UnityEngine;

public class Target : MonoBehaviour{
    [SerializeField] private float health = 50f;

    public void TargetTakeDamage(float amount){
        health -= amount;
        if(health <= 0f){
            Die();
        }
    }
    private void Die(){
        Destroy(gameObject);
    }
}
