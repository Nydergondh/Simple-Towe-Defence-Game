using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint) {
        if (towerQueue.Count < towerLimit) {
            AddNewTower(baseWaypoint);
        }
        else {
            MoveOldestTower(baseWaypoint);
        }
    }

    private void AddNewTower(Waypoint baseWaypoint) {
     
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = gameObject.transform;

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower);
    }

    private void MoveOldestTower(Waypoint baseWaypoint) {
        Tower dequedTower = towerQueue.Dequeue();
        dequedTower.transform.position = baseWaypoint.transform.position;

        baseWaypoint.isPlaceable = false;
        dequedTower.baseWaypoint.isPlaceable = true;
        dequedTower.baseWaypoint = baseWaypoint;

        towerQueue.Enqueue(dequedTower);
    }
}