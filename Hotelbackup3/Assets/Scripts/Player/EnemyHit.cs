using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {

    public int AttackDamage = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth.currentHealth > 0)
            {
                Debug.Log("Ow");
                // ... damage the player.
                enemyHealth.TakeDamage(AttackDamage);
            }
        }
    }
}
