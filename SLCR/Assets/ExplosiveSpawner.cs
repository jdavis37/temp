using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveSpawner : MonoBehaviour
{
    public GameObject TNT;
    public GameObject PAT;
    public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ExplosiveSpawning", 30, 10);
        InvokeRepeating("PatrolSpawning", 10, 20);
    }

    // Update is called once per frame
    void ExplosiveSpawning()
    {
        Instantiate(TNT, gameObject.transform.position, gameObject.transform.rotation, parent);
    }

    void PatrolSpawning()
    {
        Instantiate(PAT, gameObject.transform.position, gameObject.transform.rotation, parent);
    }
}
