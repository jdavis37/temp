using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExplodeChar : Character
{
    public float explodingRadius = 8;
    public double explosionDelay = 2.0;

    public NavMeshAgent nav;
    public GameObject player;

    public float triggerExplosion = 0;

    private ParticleSystem explosion;

    /**
   * @pre: N/A.
   * @post: Character should be spawned and ready to use
   * @param: None.
   * @return: None.
   */
    public override void Start()
    {
        nav = this.GetComponent<NavMeshAgent>();
    }

    /**
   * @pre: N/A.
   * @post: Destorys character if they have no health
   * @param: None.
   * @return: None.
   */
 
    public override void Update()
    {
        if (health == 0)
        {
            nav.isStopped = true;
            Invoke("Explode", 1);
        }
        if (hit)
        {
            hit = false;
        }
        


    }

    public override void FixedUpdate()
    {
        triggerExplosion = Vector3.Distance(transform.position, player.transform.position);
        if (triggerExplosion < explodingRadius)
        {
            if (explosionDelay > 0)
                explosionDelay -= .1;
            else if (explosionDelay <= 0)
                Invoke("Explode", 1);
        }
    }

    /**
   * @pre: N/A.
   * @post: Adds input to player health
   * @param: None.
   * @return: None.
   */
    public override void ChangeHealth(float change)
    {
        if (health + change < 0)
        {
            health = 0;
        }

        else
        {
            health = health + change;
        }
    }

    /**
   * @pre: N/A.
   * @post: Converts a angle in degrees and a length to new vector. Not used
   * @param: None.
   * @return: None.
   */

    [System.Obsolete]
    public void Explode()
    {
        //AreaDamageEnemies(player.transform.position, explodingRadius, 50);
        explosion = this.GetComponent<ParticleSystem>();
        explosion.Play();
        Destroy(gameObject, explosion.duration);
    }

}