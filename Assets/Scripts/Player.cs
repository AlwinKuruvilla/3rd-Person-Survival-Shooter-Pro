using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour {
    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;
    private GameObject _cameraGameObject;

    [SerializeField] private float _speed = 12.5f;
    [SerializeField] private float _jumpSpeed = 10.0f;
    [SerializeField] private float _gravity = 9.8f;

    private void Start() {
        _characterController = GetComponent<CharacterController>();
        
        if(_characterController == null) Debug.LogError("Character Controller Component is missing!");
        
        _cameraGameObject = GameObject.Find("Main Camera");
        
        if(_cameraGameObject == null) Debug.LogError("Main Camera is missing!");
        
    }


    private void Update()
    {
        //Map WASD to movement
        //input system (horizontal, vertical)
        //direction = vector to move
        //velocity = direction * speed
        
        //if jump
        //velocity = new velocity + y
        
        //controller.move 
        Move();

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        transform.Rotate(0,mouseX,0);
        _cameraGameObject.transform.Rotate(-mouseY, 0,0 );
        
    }

    private void Move() {

        if (_characterController.isGrounded) {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            _moveDirection = new Vector3(horizontal, 0.0f, vertical);
            _moveDirection *= _speed;

            if (Input.GetButton("Jump")) {
                _moveDirection.y = _jumpSpeed;
            }
        }

        _moveDirection.y -= _gravity * Time.deltaTime;

        _characterController.Move(_moveDirection * Time.deltaTime);
    }
}
