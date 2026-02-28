using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
	[Tooltip("Degrees per second the character will rotate to match the camera's forward.")]
	public float rotationSpeed = 720f;

	[Tooltip("Optional: assign the camera transform (Cinemachine target or Camera.main). If empty, Camera.main is used.")]
	public Transform cameraTransform;

	void Awake()
	{
		if (cameraTransform == null && Camera.main != null)
			cameraTransform = Camera.main.transform;
	}

	void Update()
	{
		if (cameraTransform == null) return;

		// Get camera forward, flatten to horizontal plane (keep Y rotation only)
		Vector3 camForward = cameraTransform.forward;
		camForward.y = 0f;

		if (camForward.sqrMagnitude < 1e-6f) return;

		Quaternion targetRot = Quaternion.LookRotation(camForward.normalized, Vector3.up);
		float maxDeg = rotationSpeed * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, maxDeg);
	}
}
