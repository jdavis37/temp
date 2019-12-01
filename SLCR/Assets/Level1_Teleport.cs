using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Teleport : MonoBehaviour
{
    public Transform Level1_Destination;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = Level1_Destination.transform.position;
            other.transform.rotation = Level1_Destination.transform.rotation;
        }
    }    
}
