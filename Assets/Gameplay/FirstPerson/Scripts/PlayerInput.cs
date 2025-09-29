using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInput : MonoBehaviour
{
    private PlayerInput playerControlls;
    private Vector2 _moveAxis;

    void Awake()
    {
        playerControlls = new PlayerInput();
    }

    private void OnEnable()
    {
        
    }
}
