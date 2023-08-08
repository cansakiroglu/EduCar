using TMPro;
using UnityEngine;

public class NPC_Script : MonoBehaviour
{
    public Transform[] waypoints;
    public TMP_Text mistakesText;

    private int index = 0;

    private void Update()
    {
        int current = index;
        if (index == waypoints.Length)
        {
            index++;
        }
        if (index > waypoints.Length)
        {
            current = waypoints.Length * 2 - index;
        }  
        

        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].position, 1.1f * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[current].position) <= 1f)
        {
            index = (index + 1) % (waypoints.Length * 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="CarParkingColliderHolder" && !mistakesText.text.Contains("\n Try not to hit the civillian"))
        {
            mistakesText.text += "\n Try not to hit the civillian";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CarParkingColliderHolder")
        {
            Invoke(nameof(deleteTextLater), 1.5f);
        }
    }

    void deleteTextLater()
    {
        mistakesText.text = mistakesText.text.Replace("\n Try not to hit the civillian", "");
    }
}
