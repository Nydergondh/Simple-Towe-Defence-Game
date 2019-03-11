using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseHealth : MonoBehaviour {

    
    [SerializeField] int health = 10;
    [SerializeField] Text playerHealth;
    [SerializeField] Text deathMessage;
    [SerializeField] Text enemyCounter;

    void Start() {
        playerHealth.text =  health.ToString();
        enemyCounter.text = "Enemies = " + FindObjectsOfType<EnemyMovement>().Length;
    }

    void Update() {
        enemyCounter.text = "Enemies: " + FindObjectsOfType<EnemyMovement>().Length;
    }

    private void OnTriggerEnter(Collider other) {
        health--;
        playerHealth.text = health.ToString();

        if (health <= 0) {
            deathMessage.enabled = true;
            Invoke("ReloadScene",5f);
        }
    }

    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }

}
