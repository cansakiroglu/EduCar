using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionsScript : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform car;
    [SerializeField]
    TMP_Text missionsListText;
    [SerializeField]
    TMP_Text currentMissionText;

    bool barrier1=false;
    bool barrier2=false;
    bool barrier3=false;

    bool barrier11=false;
    bool barrier21=false;
    bool barrier31=false;
    [SerializeField]
    Transform ParkingCube1;
    [SerializeField]
    Transform ParkingCube2;

    private List<string> missions;

    // Start is called before the first frame update
    void Start()
    {
        // Init missions
        missions = new List<string>();

        // MISSION 0
        // Get in the car
        missions.Add("- Get in the car"); // Each mission is added as a string with format "- <missiontext>"

        // MISSION 1
        // TODO

        // MISSION 2
        // TODO
        missions.Add("- Obey the signs ");

        //MISSION
        missions.Add("- Pass through the barriers ");

        // ...

        // MISSION x
        // Perform L park
        missions.Add("- Perform L park");

        // MISSION x+1
        // Perform parallel park
        missions.Add("- Perform parallel park");
    }

    // Update is called once per frame
    void Update()
    {
        // Set missionsListText.text
        missionsListText.text = "";
        for (int i=0; i<missions.Count; i++)
        {
            missionsListText.text += missions[i];
            if (i != missions.Count - 1)
            {
                missionsListText.text += "\n";
            }
        }

        // Set currentMissionText.text
        bool allDone = true;
        currentMissionText.text = ">>> ";
        for (int i = 0; i < missions.Count; i++)
        {
            if (missions[i][0] == '-')
            {
                currentMissionText.text += missions[i].Substring(2);
                currentMissionText.text += " <<<";
                allDone = false;
                break;
            }
        }
        if (allDone)
            currentMissionText.text = ">>> ALL DONE <<<";


        // MISSION: Get in the car
        if (player.GetComponent<PlayerOrCarChooser>().inCar)
        {
            missions[0] = "+ Get in the car"; // Each completed mission is checked as "+ <missiontext>"
            // '+' instead of the '-' means DONE
        }
        else
        {
            missions[0] = "- Get in the car"; // So, if player steps out of the car, the mission becomes unchecked again, so that it can become the current mission next frame
        }

        if (car.position.x>250)
        {
            missions[1] = "+ Obey the signs"; // Each completed mission is checked as "+ <missiontext>"
            // '+' instead of the '-' means DONE
        }
        else
        {
            missions[1] = "- Obey the signs"; // So, if player steps out of the car, the mission becomes unchecked again, so that it can become the current mission next frame
        }
        //PAss THROUGH LEFT OF BARRİERS
        if (car.position.x==-16.46317&&car.position.z<3.1)
        {
            barrier1=true;
        }
        if (car.position.x==-7.43&&car.position.z>2&&barrier1)
        {
            barrier2=true;
        }
        if (car.position.x==0.74&&car.position.z<1&&barrier2)
        {
            barrier3=true;
        }
    //PAss THROUGH RIGHT OF BARRİERS
         if (car.position.x==-16.46317&&car.position.z>3.1)
        {
            barrier1=true;
        }
        if (car.position.x==-7.43&&car.position.z<2&&barrier1)
        {
            barrier2=true;
        }
        if (car.position.x==0.74&&car.position.z>1&&barrier2)
        {
            barrier3=true;
        }
        if ((barrier1&&barrier2&&barrier3)||(barrier11&&barrier21&&barrier31))
        {
            missions[2] = "+ Pass through the barriers "; // Each completed mission is checked as "+ <missiontext>"
            // '+' instead of the '-' means DONE
        }
        else
        {
            missions[2] = "- Pass through the barriers "; // So, if player steps out of the car, the mission becomes unchecked again, so that it can become the current mission next frame
        }   


        ///////
        // ...
        ///////

        // MISSION: Perform L park
        if (ParkingCube1.GetComponent<ParkingTrigger>().parkingCompleted)
        {
            int idx = missions.IndexOf("- Perform L park");
            if (idx != -1)
            {
                missions[idx] = "+ Perform L park";
            }
        }

        // MISSION: Perform parallel park
        if (ParkingCube2.GetComponent<ParkingTrigger>().parkingCompleted)
        {
            int idx = missions.IndexOf("- Perform parallel park");
            if (idx != -1)
            {
                missions[idx] = "+ Perform parallel park";
            }
        }

    }
}
