using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingTrigger : MonoBehaviour
{
    public bool parkingCompleted;

    Collider coll;

    // Start is called before the first frame update
    void Start()
    {
        parkingCompleted = false;
        coll = GetComponent<Collider>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "CarParkingColliderHolder")
        {
            if ( coll.bounds.Contains(other.bounds.max) && coll.bounds.Contains(other.bounds.min) ) {
                // Car is completely inside the target parking spot, MISSION DONE
                parkingCompleted = true;
            }
        }
    }
}
