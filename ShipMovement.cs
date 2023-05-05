using UnityEngine;
using TMPro;

public class ShipMovement : MonoBehaviour
{
	public Rigidbody rb;
	public Camera cam;
	public TMP_Text thrustLevel;

	public float thrust;

	public float turnSpeed;

	public float thrustControlAmount;

	public float maxThrust;

	Vector3 thirdPerson = new Vector3(0f,1.73000002f,-1.704f);
	Vector3 firstPerson = new Vector3(0f,0.370000005f,0.32100001f);

	[SerializeField]
	private bool useFirstPerson;

	void Update()
	{
		if(thrust > 0)
		{
			rb.useGravity = false;
			rb.freezeRotation = true;
		}
		else
		{
			rb.useGravity = true;
			rb.freezeRotation = false;
		}

		thrustLevel.SetText("Thrust: " + thrust);

		if(useFirstPerson)
		{
			cam.transform.localPosition = firstPerson;
		}
		else
		{
			cam.transform.localPosition = thirdPerson;
		}

		PlayerInput();
	}

    void FixedUpdate()
    {
		rb.AddForce(transform.forward * thrust * Time.deltaTime - rb.velocity, ForceMode.Force);
    }

	void PlayerInput()
	{
		if(thrust > 0)
		{
			if(Input.GetKey(KeyCode.A))
			{
				transform.Rotate(new Vector3(0, 0, turnSpeed));
			}

			if(Input.GetKey(KeyCode.D))
			{
				transform.Rotate(new Vector3(0, 0, -turnSpeed));
			}

			if(Input.GetKey(KeyCode.W))
			{
				transform.Rotate(new Vector3((turnSpeed * 0.75f), 0, 0));
			}

			if(Input.GetKey(KeyCode.S))
			{
				transform.Rotate(new Vector3((-turnSpeed * 0.75f), 0, 0));
			}

			if(Input.GetKey(KeyCode.LeftArrow))
			{
				transform.Rotate(new Vector3(0, (-turnSpeed * 0.25f), 0));
			}

			if(Input.GetKey(KeyCode.RightArrow))
			{
				transform.Rotate(new Vector3(0, (turnSpeed * 0.25f), 0));
			}
		}

		if(Input.GetKey(KeyCode.UpArrow))
		{
			if(thrust < maxThrust)
			{
				thrust += thrustControlAmount;
			}
		}

		if(Input.GetKey(KeyCode.DownArrow))
		{
			if(thrust > 0)
			{
				thrust -= thrustControlAmount;
			}
		}

		if(Input.GetKeyDown(KeyCode.V))
		{
			useFirstPerson = !useFirstPerson;
		}
	}
}
