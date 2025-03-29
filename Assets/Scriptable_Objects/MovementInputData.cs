using UnityEngine;

namespace Marchenkostuff
{
    [CreateAssetMenu(fileName = "MovementInputData", menuName = "FirstPersonController/Data/MovementInputData", order = 1)]
    public class MovementInputData : ScriptableObject
    {
        [SerializeField] private Vector2 inputVector;
        [SerializeField] private bool isRunning;
        [SerializeField] private bool isCrouching;
        [SerializeField] private bool jumpClicked;
        [SerializeField] private bool runClicked;
        [SerializeField] private bool runReleased;

        public Vector2 InputVector => inputVector;
        public bool HasInput => inputVector != Vector2.zero;

        public float InputVectorX { set => inputVector.x = value; }
        public float InputVectorY { set => inputVector.y = value; }

        public bool IsRunning { get => isRunning; set => isRunning = value; }
        public bool IsCrouching { get => isCrouching; set => isCrouching = value; }
        public bool JumpClicked { get => jumpClicked; set => jumpClicked = value; }
        public bool RunClicked { get => runClicked; set => runClicked = value; }
        public bool RunReleased { get => runReleased; set => runReleased = value; }

        public void ResetInput()
        {
            inputVector = Vector2.zero;
            isRunning = isCrouching = jumpClicked = runClicked = runReleased = false;
        }
    }
}
