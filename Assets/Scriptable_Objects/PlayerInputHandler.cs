using UnityEngine;
using Marchenkostuff;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MovementInputData movementInputData;

    private void Update()
    {
        movementInputData.InputVectorX = Input.GetAxis("Horizontal");
        movementInputData.InputVectorY = Input.GetAxis("Vertical");

        movementInputData.IsRunning = Input.GetKey(KeyCode.LeftShift);
        movementInputData.IsCrouching = Input.GetKey(KeyCode.C);
        movementInputData.JumpClicked = Input.GetKeyDown(KeyCode.Space);
        movementInputData.RunClicked = Input.GetKeyDown(KeyCode.LeftShift);
        movementInputData.RunReleased = Input.GetKeyUp(KeyCode.LeftShift);
    }

    private void OnDisable()
    {
        movementInputData.ResetInput();
    }
}
