using UnityEngine;

public class NPC_Script : MonoBehaviour
{
    public Transform[] waypoints;

    private int index = 0;

    private void Update()
    {
        int current = index;
        if (index > waypoints.Length)
        {
            current = waypoints.Length * 2 - index;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].position, 1.1f * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[current].position) <= 1f)
        {
            index = (index + 1) % (waypoints.Length * 2);
            Debug.Log(index);
        }
    }
}
