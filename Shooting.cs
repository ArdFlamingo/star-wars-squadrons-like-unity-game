using UnityEngine;

public class Shooting : MonoBehaviour
{
	public GameObject laser;
	
	public Transform blaster1SpawnPoint;
	public Transform blaster2SpawnPoint;
	//public Transform blaster3SpawnPoint;
	//public Transform blaster4SpawnPoint;

	private bool shooting;
	private bool readyToShoot;

	public float timeUntilNextShot;
	public float timeBetweenShots;

	void Update()
	{
		if(timeUntilNextShot <= 0)
		{
			readyToShoot = true;
		}
		else
		{
			readyToShoot = false;
			timeUntilNextShot -= 1 * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.Space) && readyToShoot)
		{
			shooting = true;
		}   

		if(shooting)
		{
			GameObject laser1 = Instantiate(laser, blaster1SpawnPoint.position, blaster1SpawnPoint.rotation);
			GameObject laser2 = Instantiate(laser, blaster2SpawnPoint.position, blaster2SpawnPoint.rotation);
			//GameObject laser3 = Instantiate(laser, blaster3SpawnPoint.position, blaster3SpawnPoint.rotation);
			//GameObject laser4 = Instantiate(laser, blaster4SpawnPoint.position, blaster4SpawnPoint.rotation);

			shooting = false;
			timeUntilNextShot = timeBetweenShots;
		}
	}
}
