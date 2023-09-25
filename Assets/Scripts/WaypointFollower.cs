using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int waypointIndex = 1;

    [SerializeField] float Wspeed = 4f;


    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position ) < .1f)
        {
            waypointIndex++;
            if(waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Wspeed * Time.deltaTime);
    }
}
