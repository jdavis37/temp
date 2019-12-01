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
    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
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
}
