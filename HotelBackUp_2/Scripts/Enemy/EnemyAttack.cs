using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 1;               // The amount of health taken away per attack.
    public bool isMiniBoss = false;
    public bool isFinalBoss = false;
    public bool isGrunt = false;
    public float moveForce = 0f;
    private Rigidbody rbody;
    public GameObject ThrowingKnife;
    public float shootForce = 0f;




    //Animator anim;                              // Reference to the animator component.
    public Transform playerPosition;                   // Used to find the player.
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    bool miniboss;
    bool finalboss;
    bool grunt;
    GameObject fire1;
    GameObject fire2;
    GameObject fire3;
    GameObject fire4;


    void Awake()
    {
        // Setting up the references.
        miniboss = isMiniBoss;
        finalboss = isFinalBoss;
        grunt = isGrunt;
        rbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        if (finalboss)
        {
            fire1 = transform.Find("FireFrontRight").gameObject;
            fire1.SetActive(false);
            fire2 = transform.Find("FireFrontLeft").gameObject;
            fire2.SetActive(false);
            fire3 = transform.Find("FireBackRight").gameObject;
            fire3.SetActive(false);
            fire4 = transform.Find("FireBackLeft").gameObject;
            fire4.SetActive(false);
        }
        //anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
            if(!playerInRange && finalboss)
            {
                fire1.SetActive(false);
                fire2.SetActive(false);
                fire3.SetActive(false);
                fire4.SetActive(false);
            }
        }
    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            if (miniboss == true && grunt == false && finalboss == false)
            {
                // ... attack.
                MiniBossAttack();
                
            }
            if (finalboss == true && grunt == false && miniboss == false)
            {
                FinalBossAttack();
            }
            if (grunt == true && miniboss == false && finalboss == false)
            {
                Attack();
            }
        }


        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            //anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
    }

    void MiniBossAttack()
    {
        // Reset the timer.
        timer = 0f;
        float h = Input.GetAxisRaw("Horizontal") * moveForce;
        float v = Input.GetAxisRaw("Vertical") * moveForce;

        rbody.velocity = new Vector3(h, v, 0);
        transform.LookAt(playerPosition);

        GameObject go = (GameObject)Instantiate(ThrowingKnife, transform.position, transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
    }

    void FinalBossAttack()
    {
        // Reset the timer.
        timer = 0f;
        fire1.SetActive(true);
        fire2.SetActive(true);
        fire3.SetActive(true);
        fire4.SetActive(true);
        StartCoroutine(waitFiveSec());
    }

    IEnumerator waitFiveSec()
    {
        yield return new WaitForSeconds(5f);
        fire1.SetActive(false);
        fire2.SetActive(false);
        fire3.SetActive(false);
        fire4.SetActive(false);
    }
}
