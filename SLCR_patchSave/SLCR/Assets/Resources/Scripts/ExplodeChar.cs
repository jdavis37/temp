using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExplodeChar : Character
{

    public NavMeshAgent nav;
    public GameObject player;

    public float triggerExplosion = 0;
    public float explosionRadius = 10;
    public float explosionDamage = 50;
    private ParticleSystem explosion;
    private float explosiveDamage = 50;

    /**
   * @pre: N/A.
   * @post: Character should be spawned and ready to use
   * @param: None.
   * @return: None.
   */

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    public override void Start()
    {
        player = GameObject.FindWithTag("Player");
        nav = this.GetComponent<NavMeshAgent>();
        rb = this.GetComponent("Rigidbody") as Rigidbody;
        tr = this.GetComponent("Transform") as Transform;
    }

    /**
   * @pre: N/A.
   * @post: Destorys character if they have no health
   * @param: None.
   * @return: None.
   */
 
    public override void Update()
    {
        if (health == 0 || (player.transform.position - tr.position).magnitude <= 2)
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
        /*triggerExplosion = Vector3.Distance(transform.position, player.transform.position);
        if (triggerExplosion < explodingRadius)
        {
            if (explosionDelay > 0)
                explosionDelay -= .1;
            else if (explosionDelay <= 0)
                Invoke("Explode", 1);
        }*/
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
        Collider[] colliders = Physics.OverlapSphere(tr.position, explosionRadius);
        float proximity;
        float dropoff;
        //AreaDamageEnemies(player.transform.position, explodingRadius, 50);
        explosion = this.GetComponent<ParticleSystem>();
        explosion.Play();
        for(int i = 0; i < colliders.Length; i++)
        {
            proximity = (colliders[i].transform.position - tr.position).magnitude;
            dropoff = proximity / explosionRadius;
            if(colliders[i].CompareTag("Patrol"))
                colliders[i].GetComponent<PatrolController>().ChangeHealth(CalculateExplosiveDamage(50, dropoff));
            else if(colliders[i].CompareTag("Explosive"))
                colliders[i].GetComponent<ExplodeChar>().ChangeHealth(CalculateExplosiveDamage(50, dropoff));
            else if(colliders[i].CompareTag("Player"))
                colliders[i].GetComponent<PlayerController>().ChangeHealth(CalculateExplosiveDamage(50, dropoff));
        }
        Destroy(gameObject, explosion.duration);

    }

    private float CalculateExplosiveDamage(float damage, float normal)
    {
        return (-(damage * (1-normal)));
    }

}