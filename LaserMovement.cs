using UnityEngine;

public class LaserMovement : MonoBehaviour
{
	public float speed;

	public float damage;

    void Update()
    {
		GetComponent<Rigidbody>().velocity += transform.forward * speed * Time.deltaTime;

		Destroy(gameObject, 1);
    }

	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Map")
		{
			Destroy(gameObject);
		}

		if(collision.collider.tag == "Target")
		{
			collision.transform.GetComponent<TargetHealth>().Damage(damage);
			Destroy(gameObject);
		}	
	}
}
