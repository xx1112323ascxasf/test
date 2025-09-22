using UnityEngine;

namespace FirstPerson
{

    public class MoveFirstPersonCamera : MonoBehaviour
    {
        public Transform cameraPosition;
        private void Update()
        {
            transform.position = cameraPosition.position;
        }
    }


}

