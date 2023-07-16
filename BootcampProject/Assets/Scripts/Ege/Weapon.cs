using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float damage = 10f;
    [SerializeField]
    private float range = 100f;
    [SerializeField]
    private Camera PlayerCam;
    [SerializeField]
    private GameObject bulletImpactEffect;
    public AudioSource gunSound;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")){
            Shoot();
        }
    }
    private void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            FlyingEnemy fenemy = hit.transform.GetComponent<FlyingEnemy>();
            TriangleBossScript benemy = hit.transform.GetComponent<TriangleBossScript>();
            if (enemy != null)
            {
                enemy.takeDamage(damage);
            }
            if (fenemy != null)
            {
                fenemy.takeDamage(damage);
                Debug.Log("FLY");
            }
            if (benemy != null)
            {
                benemy.DecreaseHealth(damage);
                Debug.Log("deasd");
            }

            GameObject impactGO = Instantiate(bulletImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
            gunSound.Play();
        }
    }
    public void DamageIncrease(){
        damage = damage + 10;
    }
}
