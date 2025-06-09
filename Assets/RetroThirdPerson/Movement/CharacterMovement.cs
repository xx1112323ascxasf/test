using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RetroThirdPerson
{

	[RequireComponent(typeof(CharacterController))]
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] float _speed = 6.0f;
		[SerializeField] float _gravity = 40.0f;

		CharacterController _controller;
		float _horizontal, _vertical;



		// use this for initialization
		void Awake()
		{
			_controller = GetComponent<CharacterController>();
		}

		// screen drawing update - read inputs here
		void Update()
		{
			_horizontal = Input.GetAxis("Horizontal");
			_vertical = Input.GetAxis("Vertical");

		}

		// physics simulation update - apply physics forces here
		void FixedUpdate()
		{
			Vector3 moveDirection = Vector3.zero;

			// is the controller on the ground?
			if (_controller.isGrounded)
			{
				// feed moveDirection with input.
				moveDirection = new Vector3(_horizontal, 0, _vertical);
				moveDirection = transform.TransformDirection(moveDirection);

				// multiply it by speed.
				moveDirection *= _speed;


			}



			// apply gravity to the controller
			moveDirection.y -= _gravity * Time.deltaTime;

			// make the character move //crazy hamburger //asdsad
			_controller.Move(moveDirection * Time.deltaTime);

		}
	}
}