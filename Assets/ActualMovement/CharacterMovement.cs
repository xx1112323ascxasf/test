
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

	[Header("Reference")]
	
	private CharacterController controller;

	
	public float moveSpeed = 5f;

	Vector2 moveInput = Vector2.zero;



    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Called by the Input System action (Performed / Canceled)
    public void OnMove(InputAction.CallbackContext context)
	{
		moveInput = context.ReadValue<Vector2>();
	}

	void Update()
	{
		Movement();

	}
	
	
	
	private void Movement()
	{
		GroundMovement();
	}
	
	
	
	
	
	private void GroundMovement()
	{
		Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
		if (move.sqrMagnitude > 0.00001f)
		{
			transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);
		}
		// Apply gravity
		float verticalVel = verticalVelocityCalculation();
		controller.Move(new Vector3(0f, verticalVel, 0f) * Time.deltaTime);
	}




	#region character physics
	[SerializeField] private float gravity = -9.81f;

	private float verticalVelocity; 

	private float verticalVelocityCalculation()
	{
		if (controller.isGrounded)
		{
			verticalVelocity = 0f;
		}
		else 
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}
		return verticalVelocity;
	}

     
	#endregion
}

