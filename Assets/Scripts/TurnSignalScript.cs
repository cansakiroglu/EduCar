using System;
using TMPro;
using UnityEngine;

public class TurnSignalScript : MonoBehaviour
{
    public GameObject turnLeft;
    public GameObject turnRight;
    public TMP_Text mistakesText;
    //public GameObject car;

    private PrometeoCarController controller;

    private float yRotationRight;
    private float yRotationLeft;
    private float time;

    private bool signalLeft = false;
    private bool signalRight = false;

    private void Start()
    {
        controller = GetComponent<PrometeoCarController>();
    }

    private void Update()
    {
        if (controller.carActive && controller.engineStarted)
        {
            if (Input.GetKeyUp(KeyCode.O))
            {
                signalLeft = !signalLeft;
                signalRight = false;
                time = Time.time;
                turnLeft.SetActive(false);
            }
            else if (Input.GetKeyUp(KeyCode.P))
            {
                signalRight = !signalRight;
                signalLeft = false;
                time = Time.time;
                turnRight.SetActive(false);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                if (Math.Abs(transform.rotation.y - yRotationRight) > 0.25f && !signalRight)
                {
                    mistakesText.text += "\n Try using turn signals when turning!";
                    Invoke(nameof(DeleteTextLater), 1.5f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                yRotationRight = transform.rotation.y;
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                if (Math.Abs(transform.rotation.y - yRotationLeft) > 0.25f && !signalLeft)
                {
                    mistakesText.text += "\n Try using turn signals when turning!";
                    Invoke(nameof(DeleteTextLater), 1.5f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                yRotationLeft = transform.rotation.y;
            }
        }

        float timeSpent = (int)(Time.time - time % 1);
        if (signalLeft)
        {
            if (timeSpent % 2 == 0)
            {
                turnLeft.SetActive(false);
            }
            else
            {
                turnLeft.SetActive(true);
            }
        }
        else if (signalRight)
        {
            if (timeSpent % 2 == 0)
            {
                turnRight.SetActive(false);
            }
            else
            {
                turnRight.SetActive(true);
            }
        }
    }

    void DeleteTextLater()
    {
        mistakesText.text = mistakesText.text.Replace("\n Try using turn signals when turning!", "");
    }
}
