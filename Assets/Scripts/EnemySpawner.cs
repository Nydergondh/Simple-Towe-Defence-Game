using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] float spawnEverySeconds = 5f;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnEnemies());
	}
	
    IEnumerator SpawnEnemies()
    {
        while(true) // forever
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(spawnEverySeconds);
        }
    }
}
