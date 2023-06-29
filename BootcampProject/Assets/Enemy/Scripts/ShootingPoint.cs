using UnityEngine;
public class ShootingPoint : MonoBehaviour
{
    Transform lazerTransform;
    public float distance;
    Vector3 position;
    void Start()
    {
        if (lazerTransform == null)
        {
            lazerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    void Update()
    {
        position = new Vector3(lazerTransform.position.x, lazerTransform.position.y + 1.4f, lazerTransform.position.z);
        if (distance < 30)
        {
            Vector3 direction = position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            float spreadAngle = 45f;
            float randomSpread = Random.Range(-spreadAngle, spreadAngle);
            Quaternion spreadRotation = Quaternion.AngleAxis(randomSpread, Vector3.up);
            Quaternion finalRotation = targetRotation * spreadRotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, Time.deltaTime * 20);
        }

    }
}
