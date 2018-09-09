using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXandY;
    public float SensivityHor = 9.0f;

    public float SensivityVert = 9.0f;

    public float MinimumVert = -45.0f;

    public float MaximumVert = 45.0f;

    private float _rotationX = 0;
	// Use this for initialization
	void Start () {
        Rigidbody body = GetComponent<Rigidbody>();

        if (body != null)
        {
            body.freezeRotation = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X")*SensivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * SensivityVert;

            _rotationX = Mathf.Clamp(_rotationX, MinimumVert, MaximumVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

            
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * SensivityVert;

            _rotationX = Mathf.Clamp(_rotationX, MinimumVert, MaximumVert);

            float delta = Input.GetAxis("Mouse X") * SensivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles= new Vector3(_rotationX, rotationY, 0);
        }
	}
}
