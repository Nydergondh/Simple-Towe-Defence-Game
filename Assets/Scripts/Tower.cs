using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;

    public Waypoint baseWaypoint;


    Transform targetEnemy;
   
    // Update is called once per frame
    void Update () {
        SetTargetEnemy();
        if (targetEnemy)
        {
               
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
	}

    private void SetTargetEnemy() {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length == 0) { return; }

        Transform closetsEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies) {
            closetsEnemy = GetClosestEnemy(closetsEnemy,testEnemy.transform);
            targetEnemy = closetsEnemy;
        }
    }

    private Transform GetClosestEnemy(Transform transformA, Transform transformB) {

        float distA = Vector3.Distance(transformA.position, transformB.position);
        float distB = Vector3.Distance(transformA.position, transformB.position);

        if (distA < distB) {
            return transformA;
        }
        else {
            return transformB;
        }
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
