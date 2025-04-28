using UnityEngine;

namespace RetroThirdPerson
{

    [CreateAssetMenu(fileName = "RetroMovementData", menuName = "ThirdPersonController/Data/MovementInputData", order = 1)]
    public class RetroMovementData : ScriptableObject
    {
        #region Data
            Vector3 m_inputVector;

            bool m_isRunning;
            bool m_isCroucing; 

            bool m_runClicked;
            bool m_runReleased;
        #endregion

        #region  Properties 
            // public Vector3 InputVector = m_inputVector;
            // головиное яйцо
        #endregion
    }   


}

