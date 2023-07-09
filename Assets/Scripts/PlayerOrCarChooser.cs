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
            Debug.Log("inCar oldu");
            Cam.GetComponent<PlayerCam>().enabled = false;
            Cam.GetComponent<CameraFollow>().enabled = true;

            Player.GetComponent<PlayerMovement>().enabled = false;
        }
        else
        {
            Cam.GetComponent<PlayerCam>().enabled = true;
            Cam.GetComponent<CameraFollow>().enabled = false;

            Player.GetComponent<PlayerMovement>().enabled = true;
        }
    }
}
