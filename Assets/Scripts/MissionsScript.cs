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


        //MISSION
         missions.Add("- Pass through the pontoons ");
        // ...

        // MISSION x
        // Perform L park
        // TODO

        // MISSION x+1
        // Perform parallel park
        // TODO
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


        // MISSION: "Get in the car"
        if (player.GetComponent<PlayerOrCarChooser>().inCar)
        {
            missions[0] = "+ Get in the car"; // Each completed mission is checked as "+ <missiontext>"
            // '+' instead of the '-' means DONE
        }
        else
        {
            missions[0] = "- Get in the car"; // So, if player steps out of the car, the mission becomes unchecked again, so that it can become the current mission next frame
        }
    }
}
