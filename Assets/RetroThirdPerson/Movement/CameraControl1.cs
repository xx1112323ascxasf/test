using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CameraContol : MonoBehaviour
{

    [SerializeField]
    private float _mouseSensitivity = 3.0f;

    private float _rotationY;
    private float _rotationX;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _distanceFromTarger = 3.0f;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;


    [SerializeField]
    //если не понравится, вернутся в гайд это можно убрать целиком
    private float _smoothTime = 0.3f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _rotationY += mouseX;
        _rotationX += mouseY;

        _rotationX = Math.Clamp(_rotationX, -40, 40);

        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;

        transform.position = _target.position - transform.forward * _distanceFromTarger;
    }



}

