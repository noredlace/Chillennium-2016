using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 3;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.

    public Image DamageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

    public Image Battery1;                                      //Image for first battery of health.
    public Image Battery2;                                      //Image for second battery of health.
    public Image Battery3;                                      //Image for third battery of health.

    public Image GameOver;                                      //Image for game over screen.


    //Animator anim;                                              // Reference to the Animator component.
    PlayerMovement playerMovement;                              // Reference to the player's movement.
    PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.


    void Awake()
    {
        // Setting up the references.
        //anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();

        // Set the initial health of the player.
        currentHealth = startingHealth;
    }


    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            DamageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Hide the batteries that the player lost.
        if(currentHealth < 3)
        {
            Battery3.enabled = false;
        }
        if (currentHealth < 2)
        {
            Battery2.enabled = false;
        }
        if (currentHealth < 1)
        {
            Battery1.enabled = false;
        }

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Turn off any remaining shooting effects.
        playerShooting.DisableEffects();

        GameOver.enabled = true;

        // Tell the animator that the player is dead.
        //anim.SetTrigger("Die");

        // Turn off the movement and shooting scripts.
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }
}
