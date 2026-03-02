using UnityEngine;



public class CharacterCamera : MonoBehaviour
{
	public float rotationSpeed = 720f;

	public Transform cameraTransform;

	void Awake()
	{
		if (cameraTransform == null && Camera.main != null)
			cameraTransform = Camera.main.transform;
	}

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
    }

    void Update()
	{

		LookCursor();
		CameraRotate();

	}


	public void LookCursor()
	{
		if (cameraTransform != null)
		{
			// Get camera forward, flatten to horizontal plane (keep Y rotation only)
			Vector3 camForward = cameraTransform.forward;
			camForward.y = 0f;

			if (camForward.sqrMagnitude >= 1e-6f)
			{
				Quaternion targetRot = Quaternion.LookRotation(camForward.normalized, Vector3.up);
				float maxDeg = rotationSpeed * Time.deltaTime;
				transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, maxDeg);
			}
		}
	}

	public void CameraRotate()
	{
		if (cameraTransform != null)
		{
			// Get camera forward, flatten to horizontal plane (keep Y rotation only)
			Vector3 camForward = cameraTransform.forward;
			camForward.y = 0f;

			if (camForward.sqrMagnitude >= 1e-6f)
			{
				Quaternion targetRot = Quaternion.LookRotation(camForward.normalized, Vector3.up);
				float maxDeg = rotationSpeed * Time.deltaTime;
				transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, maxDeg);
			}
		}
	}
}
