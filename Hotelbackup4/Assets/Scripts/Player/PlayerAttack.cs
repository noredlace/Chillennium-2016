using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 1;               // The amount of health taken away per attack.
    public int floor = 0;
    public GameObject PlayerThrowingKnife;

    float moveForce = 100f;
    Rigidbody rbody;
    float shootForce = 1000f;
    //Animator anim;                              // Reference to the animator component.
    GameObject enemy;                     // Reference to the player GameObject.
    PlayerHealth playerHealth;           // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    float timer;                                // Timer for counting up to the next attack.
    bool hasTray = false;
    bool hasKnife = false;
    bool hasThrowingKnife = false;


    void Awake()
    {
        // Setting up the references.
        if(floor == 1)
        {
            hasThrowingKnife = true;
            hasTray = false;
            hasKnife = false;
        }
        else  if(floor == 2)
        {
            hasKnife = true;
            hasTray = false;
            hasThrowingKnife = false;
        }
        else if(floor == 3)
        {
            hasTray = true;
            hasKnife = false;
            hasThrowingKnife = false;
        }
        rbody = GetComponent<Rigidbody>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        //enemyHealth = enemy.GetComponent<EnemyHealth>();
        playerHealth = GetComponent<PlayerHealth>();
    }


    /*void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }*/


    /*void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        /*if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }*/


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks /*&& enemyHealth.currentHealth > 0*/)
        {
            if (hasTray)
            {
                // ... attack.
                trayAttack();

            }
            if (hasKnife)
            {
                knifeAttack();
            }
            if (hasThrowingKnife)
            {
                throwingKnifeAttack();
            }
        }


        // If the player has zero or less health...
        /*if (enemyHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            //anim.SetTrigger("PlayerDead");
        }*/
    }


    void trayAttack()
    {
        // Reset the timer.
        /*timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }*/
    }

    void knifeAttack()
    {
        // Reset the timer.
        /*timer = 0f;
        float h = Input.GetAxisRaw("Horizontal") * moveForce;
        float v = Input.GetAxisRaw("Vertical") * moveForce;

        rbody.velocity = new Vector3(h, v, 0);
        transform.LookAt(playerPosition);

        GameObject go = (GameObject)Instantiate(ThrowingKnife, transform.position, transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);*/
    }

    void throwingKnifeAttack()
    {
        // Reset the timer.
        timer = 0f;
        if (Input.GetButton("Fire1"))
        {
            float h = Input.GetAxisRaw("Horizontal") * moveForce;
            float v = Input.GetAxisRaw("Vertical") * moveForce;

            rbody.velocity = new Vector3(h, v, 0);

            GameObject go = (GameObject)Instantiate(PlayerThrowingKnife, transform.position, transform.rotation);
            go.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
        }
    }
}
