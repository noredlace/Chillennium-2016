using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {

    public int AttackDamage = 0;

    GameObject enemy;
    EnemyHealth enemyHealth;

    // Use this for initialization
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy)
        {
            if (enemyHealth.currentHealth > 0)
            {
                Debug.Log("Ow");
                // ... damage the player.
                enemyHealth.TakeDamage(AttackDamage);
            }
        }
    }
}
