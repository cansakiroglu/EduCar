using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Bonnet Controller")]
public class BonnetController : ScriptableObject
{
    bool[] dropdownCorrect = { false, false, false, false, false, false, false };

    public void OnEnable()
    {
        for (int i = 0; i < dropdownCorrect.Length; i++)
        {
            dropdownCorrect[i] = false;
        }
    }

    public void dropdownValueChanged(GameObject dropdown)
    {
        TMP_Dropdown tmpdropdown = dropdown.GetComponent<TMP_Dropdown>();
        if ( dropdown.name[8] == tmpdropdown.value.ToString()[0]) // True Answer
        {
            ColorBlock colors = tmpdropdown.colors;
            Color clr = Color.green;
            colors.disabledColor = clr;
            colors.highlightedColor = clr;
            colors.normalColor = clr;
            colors.pressedColor = clr;
            colors.selectedColor = clr;
            tmpdropdown.colors = colors;
            tmpdropdown.interactable = false;

            int idx = (int)(dropdown.name[8]) - (int)('1');
            dropdownCorrect[idx] = true;
        }
        else // False Answer
        {
            ColorBlock colors = tmpdropdown.colors;
            Color clr = Color.red;
            colors.disabledColor = clr;
            colors.highlightedColor = clr;
            colors.normalColor = clr;
            colors.pressedColor = clr;
            colors.selectedColor = clr;
            tmpdropdown.colors = colors;
            tmpdropdown.interactable = true;

            int idx = (int)(dropdown.name[8]) - (int)('1');
            dropdownCorrect[idx] = false;
        }
    }

    public void finishHit(GameObject MissionInfoText)
    {
        TMP_Text txt = MissionInfoText.GetComponent<TMP_Text>();

        bool allCorrect = true;
        for (int i = 0; i < dropdownCorrect.Length; i++)
        {
            if (dropdownCorrect[i] == false)
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            txt.text = "DONE - Congratulations!";
        }
        else
        {
            txt.text = "Please, answer all parts correctly before ending.";
        }
    }
}
