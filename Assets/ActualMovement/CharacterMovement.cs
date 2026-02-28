
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
	public float moveSpeed = 5f;

	Vector2 moveInput = Vector2.zero;

	// Called by the Input System action (Performed / Canceled)
	public void OnMove(InputAction.CallbackContext context)
	{
		moveInput = context.ReadValue<Vector2>();
	}

	void Update()
	{
		Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
		if (move.sqrMagnitude > 0.00001f)
			transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);
	}
}

