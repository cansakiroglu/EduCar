using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	// CAMERA CONTROLLER OF THE CAR
	// TODO: Update the camera controlls for the car driving in this file, not optimal for serious driving.

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
	private bool isThirdPerson;

	void Start(){
		//initialCameraPosition = gameObject.transform.position;
		//initialCarPosition = carTransform.position;
		//absoluteInitCameraPosition = initialCameraPosition - initialCarPosition;

		whereShouldCameraBe1 = carTransform.GetChild(0); // Camera 1
		whereShouldCameraBe2 = carTransform.GetChild(1); // Camera 2
		isThirdPerson = true;
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

		if (isThirdPerson) // Camera 1
        {
			transform.LookAt(carTransform);
			transform.position = whereShouldCameraBe1.position;
		}
        else // Camera 2
        {
			transform.rotation = whereShouldCameraBe2.rotation;
			transform.position = whereShouldCameraBe2.position;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			isThirdPerson = true;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			isThirdPerson = false;
		}
	}
}
