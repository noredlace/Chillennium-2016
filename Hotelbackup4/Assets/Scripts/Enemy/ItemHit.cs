using UnityEngine;
using System.Collections;

public class ItemHit : MonoBehaviour {

    public int AttackDamage = 0;

    GameObject player;                          // Reference to the player GameObject.
    GameObject enemy;
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (playerHealth.currentHealth > 0)
            {
                // ... damage the player.
                playerHealth.TakeDamage(AttackDamage);
            }
        }
    }
}