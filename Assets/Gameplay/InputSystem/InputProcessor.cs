using UnityEngine;

public class InputProcessor
{
    public InputProcessor()
    {
        
    }   


    Vector2 InputVector;

    public Vector2 inputVECTOR => InputVector;

    public Vector2 inputVECTORNORMAL => InputVector.normalized;

    public void ProcessInputVector(Vector2 value)
    {
        this.InputVector = value;
    }


}
