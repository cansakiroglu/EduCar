using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrCarChooser : MonoBehaviour
{
    // RELATED GAMEOBJECTS
    public GameObject Cam;
    public GameObject Player;
    public GameObject Car;

    [HideInInspector]
    public bool inCar;

    // Start is called before the first frame update
    void Start()
    {
        inCar = false;

        Cam.GetComponent<PlayerCam>().enabled = true;
        Cam.GetComponent<CameraFollow>().enabled = false;

        Player.GetComponent<PlayerMovement>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (inCar)
        {
            Cam.GetComponent<PlayerCam>().enabled = false;
            Cam.GetComponent<CameraFollow>().enabled = true;

            Player.GetComponent<PlayerMovement>().enabled = false;

            Player.GetComponent<MeshRenderer>().enabled = false;
            Player.GetComponent<CapsuleCollider>().enabled = false;
            Player.GetComponent<Rigidbody>().Sleep();

            Player.transform.position = new Vector3(Car.transform.position.x, Car.transform.position.y, Car.transform.position.z) + new Vector3(0f, 2f, 0f);
        }
        else
        {
            Cam.GetComponent<PlayerCam>().enabled = true;
            Cam.GetComponent<CameraFollow>().enabled = false;

            Player.GetComponent<PlayerMovement>().enabled = true;

            Player.GetComponent<MeshRenderer>().enabled = true;
            Player.GetComponent<CapsuleCollider>().enabled = true;
            Player.GetComponent<Rigidbody>().WakeUp();

            
        }
    }
}
