using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	// CAMERA CONTROLLER OF THE CAR

	public Transform carTransform;
	//[Range(1, 10)]
	//public float followSpeed = 2;
	//[Range(1, 10)]
	//public float lookSpeed = 5;
	//Vector3 initialCameraPosition;
	//Vector3 initialCarPosition;
	//Vector3 absoluteInitCameraPosition;

	private Transform whereShouldCameraBe1;
	private Transform whereShouldCameraBe2;
	private Transform whereShouldCameraBe3;
	private int cameraMode;

	void Start(){
		//initialCameraPosition = gameObject.transform.position;
		//initialCarPosition = carTransform.position;
		//absoluteInitCameraPosition = initialCameraPosition - initialCarPosition;

		whereShouldCameraBe1 = carTransform.GetChild(0); // Camera 1
		whereShouldCameraBe2 = carTransform.GetChild(1); // Camera 2
		whereShouldCameraBe3 = carTransform.GetChild(2); // Camera 3
		cameraMode = 1;
	}

    void FixedUpdate()
    {
		////Look at car
		//Vector3 _lookDirection = (new Vector3(carTransform.position.x, carTransform.position.y, carTransform.position.z)) - transform.position;
		//Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
		//transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);

		////Move to car
		//Vector3 _targetPos = absoluteInitCameraPosition + carTransform.transform.position;
		//transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);

		if (cameraMode == 1) // Camera 1
        {
			transform.LookAt(carTransform);
			transform.position = whereShouldCameraBe1.position;
		}
        else if (cameraMode == 2) // Camera 2
        {
			transform.rotation = whereShouldCameraBe2.rotation;
			transform.position = whereShouldCameraBe2.position;
		}
		else if (cameraMode == 3) // Camera 3
        {
			transform.rotation = whereShouldCameraBe3.rotation;
			transform.position = whereShouldCameraBe3.position;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			cameraMode = 1;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			cameraMode = 2;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			cameraMode = 3;
		}
	}
}
