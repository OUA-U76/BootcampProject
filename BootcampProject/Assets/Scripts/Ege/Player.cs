using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	[SerializeField] private int maxHealth = 100;
	[SerializeField] private int currentHealth;

	[SerializeField] private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update(){
		//if (Input.GetKeyDown(KeyCode.Space)){
		//	TakeDamage(20);
		//}
    }

	public void TakeDamage(int damage){
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
	}
}