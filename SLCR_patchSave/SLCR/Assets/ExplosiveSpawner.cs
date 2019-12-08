using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveSpawner : MonoBehaviour
{
    public GameObject TNT;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ExplosiveSpawning", 30, 10);
    }

    // Update is called once per frame
    void ExplosiveSpawning()
    {
        Instantiate(TNT, gameObject.transform.position, gameObject.transform.rotation);
    }

}
