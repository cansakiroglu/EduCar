using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    bool barrier1 = false;
    bool barrier2 = false;
    bool barrier3 = false;

    bool barrier11 = false;
    bool barrier21 = false;
    bool barrier31 = false;
    [SerializeField]
    Transform ParkingCube1;
    [SerializeField]
    Transform ParkingCube2;

    private List<string> missions;
    private float time = -1;

    // Start is called before the first frame update
    void Start()
    {
        // Init missions
        missions = new List<string>();

        // MISSION 0
        // Get in the car
        missions.Add("- Get in the car"); // Each mission is added as a string with format "- <missiontext>"

        // MISSION 1
        missions.Add("- Start the Engine by pressing 'K'");
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

        // MISSION x+2 Last mission in the missions list
        // Car Bonnet Mission
        // User switches to CarBonnetScene from the GameScene in order to perform the mission
        missions.Add("- Open the car's bonnet by pressing 'B' & name the parts within");

        // Fix the Engine
        missions.Add("- Car's engine is broken, fix it by going to car's bonnet and press 'F'");

    }

    // Update is called once per frame
    void Update()
    {
        // Set missionsListText.text
        missionsListText.text = "";
        for (int i = 0; i < missions.Count - 1; i++)
        {
            missionsListText.text += missions[i];
            if (i != missions.Count - 2)
            {
                missionsListText.text += "\n";
            }
        }

        if (time != -1 && Time.time - time >= 4.5f) {
            time = -1;
            PlayerPrefs.SetInt("EngineBroken", 0);
        }
        else if (PlayerPrefs.GetInt("EngineBroken") == 1)
        {
            missionsListText.text += "\n- Car's engine is broken, fix it by going to car's bonnet and press 'F'";
        }else if (PlayerPrefs.GetInt("EngineBroken") == 2)
        {
            missionsListText.text += "\n+ Car's engine is broken, fix it by going to car's bonnet and press 'F'";
            if (time  == -1)
            {
                time = Time.time;
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

        if (car.gameObject.GetComponent<PrometeoCarController>().engineStarted)
        {
            missions[1] = "+ Start the Engine by pressing 'K'";
        }
        else
        {
            missions[1] = "- Start the Engine by pressing 'K'";
        }

        if (car.position.x > 223)
        {
            missions[2] = "+ Obey the signs"; // Each completed mission is checked as "+ <missiontext>"
            // '+' instead of the '-' means DONE
        }
        else
        {
            missions[2] = "- Obey the signs"; // So, if player steps out of the car, the mission becomes unchecked again, so that it can become the current mission next frame
        }
        //PASS THROUGH LEFT OF BARRİERS
        if (car.position.x > 234.43 &&car.position.x < 246.67&& car.position.z < 2168.5)
        {
            barrier1 = true;
             Debug.Log("barrier1");
            
        }
        if (car.position.x > 246.67 &&car.position.x < 259.6&& car.position.z > 2169.72 )
        {
            barrier2 = true;
            Debug.Log("barrier2");
        }
        
        if (car.position.x > 259.6 &&car.position.x < 281.7&& car.position.z < 2171.09 )
        {
            barrier3 = true;
            Debug.Log("barrier3");
        }
        //PASS THROUGH RIGHT OF BARRİERS
        if (car.position.x > 234.43 &&car.position.x < 246.67&& car.position.z > 2168.5)
        {
            barrier31 = true;
            Debug.Log("barrier31");
        }
        if (car.position.x > 246.67 &&car.position.x < 259.6&& car.position.z < 2169.72)
        {
            barrier21 = true;
            Debug.Log("barrier21");
        }
        if (car.position.x > 259.6 &&car.position.x < 271.7 && car.position.z > 2171.09 )
        {
            barrier11 = true;
            Debug.Log("barrier11");
        }
        if ((barrier1 && barrier2 && barrier3) || (barrier11 && barrier21 && barrier31))
        {
            missions[3] = "+ Pass through the barriers "; // Each completed mission is checked as "+ <missiontext>"
            // '+' instead of the '-' means DONE
        }
        else
        {
            missions[3] = "- Pass through the barriers "; // So, if player steps out of the car, the mission becomes unchecked again, so that it can become the current mission next frame
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

        // MISSION: Car Bonnet Mission
        if (currentMissionText.text == ">>> Open the car's bonnet by pressing 'B' & name the parts within <<<" && Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene(sceneName: "CarBonnetScene");
        }



    }
}
