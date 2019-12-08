using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PatrolController : Character
{

    public float distance;
    public GameObject player;
    public float hitRadius = 3;
    public float meleeDamage = 4;
    public bool invokeRunning = false;
    private NavMeshAgent patrol;

    private void Awake()
    {
        patrol = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    public override void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = this.GetComponent("Rigidbody") as Rigidbody;
        tr = this.GetComponent("Transform") as Transform;
    }

    // Update is called once per frame
    public override void Update()
    {
        distance = (player.transform.position - tr.position).magnitude;
        if (health <= 0)
            Destroy(gameObject);
        if(distance <= hitRadius)
        {
            MeleeAttack();
        }
    }


    public void MeleeAttack()
    {
        player.GetComponent<PlayerController>().ChangeHealth(-(meleeDamage));
    }

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
}
