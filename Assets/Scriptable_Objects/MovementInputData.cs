using UnityEngine;

namespace Marchenkostuff
{
    // Создаёт объект ScriptableObject для хранения данных ввода
    [CreateAssetMenu(fileName = "MovementInputData", menuName = "FirstPersonController/Data/MovementInputData", order = 1)]
    public class MovementInputData : ScriptableObject
    {
        // Вектор ввода для направления движения (X - влево/вправо, Y - вперёд/назад)
        [SerializeField] private Vector2 inputVector;

        // Флаги состояний игрока
        [SerializeField] private bool isRunning;
        [SerializeField] private bool isCrouching;
        [SerializeField] private bool jumpClicked;
        [SerializeField] private bool runClicked;
        [SerializeField] private bool runReleased;

        // Публичные свойства для получения данных
        public Vector2 InputVector => inputVector;
        public bool HasInput => inputVector != Vector2.zero;

        // Устанавливаем координаты ввода
        public float InputVectorX { set => inputVector.x = value; }
        public float InputVectorY { set => inputVector.y = value; }

        // Свойства для управления состояниями игрока
        public bool IsRunning { get => isRunning; set => isRunning = value; }
        public bool IsCrouching { get => isCrouching; set => isCrouching = value; }
        public bool JumpClicked { get => jumpClicked; set => jumpClicked = value; }
        public bool RunClicked { get => runClicked; set => runClicked = value; }
        public bool RunReleased { get => runReleased; set => runReleased = value; }

        // Сброс всех данных ввода (например, при респауне)
        public void ResetInput()
        {
            inputVector = Vector2.zero;
            isRunning = false;
            isCrouching = false;
            jumpClicked = false;
            runClicked = false;
            runReleased = false;
        }
    }
}
