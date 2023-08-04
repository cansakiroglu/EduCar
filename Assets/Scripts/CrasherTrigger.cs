using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrasherTrigger : MonoBehaviour
{
    [SerializeField]
    TMP_Text mistakesText;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CarParkingColliderHolder")
        {
            mistakesText.text += "\n Try not to hit the red boundaries while parking!";
            Invoke("deleteTextLater", 2);
        }
    }

    void deleteTextLater()
    {
        mistakesText.text = mistakesText.text.Replace("\n Try not to hit the red boundaries while parking!", "");
    }
}
