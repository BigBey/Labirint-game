using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    public float speed = 6.0f;
    public float maxHeight = 8.0f;
    public float jumpSpeed = 3.0f;

    public float gravity = -9.8f;
    private CharacterController _charController;
	// Use this for initialization
	void Start () {
        _charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        float deltaY = Input.GetAxis("Jump")*jumpSpeed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        Vector3 jumping = new Vector3(0,deltaY,0);
        //Vector3 maxJumping = new Vector3(0, maxHeight, 0);
        movement = Vector3.ClampMagnitude(movement, speed);
        jumping = Vector3.ClampMagnitude(jumping, speed);
        //jumping = Vector3.Max(jumping, maxJumping);
        movement.y = gravity;
        movement *= Time.deltaTime;
        jumping *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        jumping = transform.TransformDirection(jumping);
        _charController.Move(movement);
        _charController.Move(jumping);
	}
}
