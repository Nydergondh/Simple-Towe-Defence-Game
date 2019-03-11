using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] ParticleSystem gettingDestroied;
    [SerializeField] float moveSpeed  = 2;

    // Use this for initialization
    void Start () {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        StartCoroutine(FollowPath(pathfinder.GetPath()));
	}

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(moveSpeed);
        }
        SeflDestruct();
    }

    private void SeflDestruct() {
        ParticleSystem dfx = Instantiate(gettingDestroied, transform.position, Quaternion.identity);
        dfx.Play();
        Destroy(dfx.gameObject, 1f);
        Destroy(gameObject);
    }
}
