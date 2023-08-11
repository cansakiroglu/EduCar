using TMPro;
using UnityEngine;

public class ShifterScript : MonoBehaviour
{
    public TMP_Text[] shifterModes;
    public GameObject canvas;
    public GameObject player;

    private PrometeoCarController mController;
    private PlayerOrCarChooser chooser;
    private int index = 0;

    private void Start()
    {
        PlayerPrefs.SetInt("ShifterMode", 0);
        mController = transform.GetComponent<PrometeoCarController>();
        chooser = player.GetComponent<PlayerOrCarChooser>();
    }

    private void Update()
    {
        if (chooser.inCar && mController.engineStarted)
        {
            canvas.SetActive(true);
            int prevIndex = index;
            if (Input.GetKeyUp(KeyCode.UpArrow) && index != 0)
            {
                index--;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) && index != 3)
            {
                index++;
            }
            shifterModes[prevIndex].color = Color.black;
            shifterModes[index].color = Color.green;
            PlayerPrefs.SetInt("ShifterMode", index);

        }
        else
        {
            canvas.SetActive(false);

        }
    }
}
