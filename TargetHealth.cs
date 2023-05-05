using UnityEngine;

public class TargetHealth : MonoBehaviour
{
	public float health;

	public float maxHealth;

    void Start()
    {
        health = maxHealth;
    }

	void Update()
	{
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void Damage(float amount)
	{
		if (health > 0)
		{
			health -= amount;
		}
	}
}
