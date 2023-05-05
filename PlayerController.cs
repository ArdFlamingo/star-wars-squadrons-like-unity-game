using UnityEngine;

public class Movement : MonoBehaviour
{
	public Transform player;
	public Transform orientation;
	public Rigidbody rb;

	public Camera cam;
	public Camera shipCam;

	Vector3 moveDir;

	private float verticalMovement;
	private float horizontalMovement;

	private float verticalMouse;
	private float horizontalMouse;

	public float movementSpeed;
	public float cameraSpeed;

	private float minTurnAngle = -90.0f;
	private float maxTurnAngle = 90.0f;

	public float interactLength;

	private bool lockCusor;

    void Update()
    {
		if (lockCusor)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			lockCusor = !lockCusor;
		}

        verticalMovement = Input.GetAxisRaw("Vertical");
		horizontalMovement = Input.GetAxisRaw("Horizontal");

		verticalMouse += Input.GetAxis("Mouse Y") * cameraSpeed * 10f * Time.deltaTime;
		horizontalMouse += Input.GetAxis("Mouse X") * cameraSpeed * 10f * Time.deltaTime; 

		verticalMouse = Mathf.Clamp(verticalMouse, minTurnAngle, maxTurnAngle); 

		player.transform.eulerAngles = new Vector3(0, horizontalMouse, 0);
		cam.transform.eulerAngles = new Vector3(-verticalMouse, horizontalMouse, 0);

		moveDir = orientation.forward * verticalMovement + orientation.right * horizontalMovement;

		rb.AddForce(moveDir.normalized * movementSpeed * 100f * Time.deltaTime, ForceMode.Force);

		Interact();
    }

	void Interact()
	{
		RaycastHit hit;

		if(Physics.Raycast(cam.transform.position, cam.transform.forward * interactLength, out hit))
		{
			if(hit.collider.tag == "Ship")
			{
				if(Input.GetKeyDown(KeyCode.E))
				{
					hit.collider.GetComponent<ShipMovement>().enabled = true;
					hit.collider.GetComponent<Shooting>().enabled = true;
					shipCam.enabled = true;

					cam.enabled = false;
					enabled = false;
				}
			}
		}
	}
}
