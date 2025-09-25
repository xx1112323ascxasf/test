using UnityEngine;
using UnityEngine.InputSystem;

namespace FirstPerson 
{
    public class FPController : MonoBehaviour
    {
        private FPController fPController;
        private InputAction movement;

        private void Awake()
        {
            fPController = new FPController();

        }

        private void OnEnable()
        {
            //movement = fPController
        }
    }
}
