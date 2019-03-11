using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem gettingHit;
    [SerializeField] ParticleSystem gettingDestroied;

    // Use this for initialization

    private void OnParticleCollision(GameObject other)
    {
        
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
        else {
            ProcessHit();
        }
    }
    
    private void ProcessHit()
    {
        gettingHit.Play();
        hitPoints = hitPoints - 1;
    }

    private void KillEnemy()
    {
        ParticleSystem dfx = Instantiate(gettingDestroied, transform.position, Quaternion.identity);
        dfx.Play();
        Destroy(dfx.gameObject,1f);
        Destroy(gameObject);
    }
}
