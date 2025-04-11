using UnityEngine;

namespace Marchenkostuff
{
    [CreateAssetMenu(fileName = "InteractionInputData", menuName = "interactionSystem/Data")]

    // лучше использовать почаще private variables и properties
    // в том числе что бы не expose вещи 
    public class InteractionInputData : ScriptableObject
    {
        private bool m_interactedClicked;
        private bool m_interactedRelease;
        
        //The get method returns the value of the variable name . The set method assigns a value to the name variable 
        public bool InteractedClicked
        {
            get => m_interactedClicked;
            set => m_interactedClicked = value;
            // value появляется когда ты вызываешь этот скрипт 
        }

            public bool InteractedRelease
        {
            get => m_interactedRelease;
            set => m_interactedRelease = value;
            
        }

    // в этом reset методе мы возвращает переменные в дефолтное состояние
    // scriptable object запомнит state переменной, когда будет конец
    // поэтому лучше сбрасывать это значение в начале 
        public void ResetInput()
        {
            m_interactedClicked = false;
            m_interactedRelease = false;
        }
}














}


