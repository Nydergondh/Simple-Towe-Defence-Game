using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // public ok here as is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    Vector2Int gridPos;

    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }
	
    // consider setting own color in Update()

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
    
    void OnMouseOver() {
        if (Input.GetMouseButtonUp(0)) {
            if (!isPlaceable) {
                print("Cannot Place in " + gameObject.name);
            }
            else {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
        }
    }
}
