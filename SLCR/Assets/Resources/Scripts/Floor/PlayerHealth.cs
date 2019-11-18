using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : PlayerController
{

    public SimpleHealthBar healthBar;
    public float recoveryTime = 2.0f;
    bool startHealing = true;
    int tick = 0;

    // Use this for initialization
    public override void Start()
    {
        healthBar.UpdateBar(health, maxHealth);
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    /**
   * @pre: N/A.
   * @post: {hysics related requirements should be parsed.
   * @param: None.
   * @return: None.
   */
    public override void FixedUpdate()
    {
        if (health < maxHealth && health > 0)
        {
            if (startHealing)
            {
                HealPlayer();
                if (health >= maxHealth)
                {
                    startHealing = false;
                }
            }
            else
            {
                if (iFrames <= 0)
                {
                    startHealing = true;
                }
            }
        }
    }

    public void HealPlayer()
    {
        ChangeHealth(1, iFrames);
        healthBar.UpdateBar(health, maxHealth);
        /*
        float increment = 1;

        if (tick % 20 == 0)
        {
            // Increase the current health by 25%.
            health += increment;

            // If the current health is greater than max, then set it to max.
            if (health > maxHealth)
            {
                health = maxHealth;
                tick = -1;
            }

            // Update the Simple Health Bar with the new Health values.
            healthBar.UpdateBar(health, maxHealth);
        }

        tick += 1;
        */
    }
}
