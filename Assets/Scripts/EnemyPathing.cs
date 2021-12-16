using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] WaveConfig waveConfig;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        waypoints = waveConfig.GetWaypoints();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }
    
    void EnemyMove()
    {
        if (waypointIndex <= waypoints.Count -1)
        {
            //save the current waypoint in targetPosition
            //targetPosition: where we want to go
            var targetPosition = waypoints[waypointIndex].transform.position;
    
            //to make sure z position is 0	
            targetPosition.z = 0f;
    
            var movementThisFrame = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            //move from the current position, to the target position, the maximum distance one can move
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            //if we reached the target waypoint
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        //if enemy moved to all waypoints
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }


}
