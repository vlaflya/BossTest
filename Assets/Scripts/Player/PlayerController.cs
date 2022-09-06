using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	public float mouseSensitivityX = 1.0f;
	public float mouseSensitivityY = 1.0f;

	public float walkSpeed = 10.0f;
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;

	[SerializeField] private Transform cameraT;
	float verticalLookRotation;

	Rigidbody rigidbodyR;
	[SerializeField] private float dashInterval;
	[SerializeField] private float jumpForce = 250.0f;
	public UnityEvent onShoot = new UnityEvent();
	public UnityEvent onUseTool = new UnityEvent();
	public UnityEvent onShieldUse = new UnityEvent();
	bool grounded;
	public LayerMask groundedMask;
	private float dashTimer;
	bool cursorVisible;

	// Use this for initialization
	void Start()
	{
		rigidbodyR = GetComponent<Rigidbody>();
		LockMouse();
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
		verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
		cameraT.localEulerAngles = Vector3.left * verticalLookRotation;
		Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
		Vector3 targetMoveAmount = moveDir * walkSpeed;
		moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
		if (dashTimer < dashInterval)
			dashTimer += Time.deltaTime;
		// jump
		if (Input.GetButtonDown("Jump"))
		{
			if (grounded && dashTimer >= dashInterval)
			{
				dashTimer = 0;
				rigidbodyR.AddForce(transform.TransformDirection(moveDir) * jumpForce);
			}
		}

		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}
		if (Input.GetMouseButtonDown(0)) {
			onShoot.Invoke();
		}
		if (Input.GetMouseButtonDown(1))
		{
			onShieldUse.Invoke();
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			onUseTool.Invoke();
		}
	}

	void FixedUpdate()
	{
		rigidbodyR.MovePosition(rigidbodyR.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
	}

	public void Restart() {
		SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
	}

	public void ShakeHead(float time, float strenght, int vibro) {
		cameraT.DOShakeRotation(time, strenght, vibro, 90, true);
	}

	void LockMouse()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		cursorVisible = false;
	}
}
