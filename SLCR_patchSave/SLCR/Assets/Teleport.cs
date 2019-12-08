using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform Destination;
    public bool isEscapePortal;

    public GameObject Player;
    
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
        if(isEscapePortal & other.gameObject.tag == "Player")
        {
            if(Player.GetComponent<Inventory>().EscapeKey)
            {
                other.transform.position = Destination.transform.position;
                other.transform.rotation = Destination.transform.rotation;
                Player.GetComponent<PlayerController>().Victory = true;
            }
        }
        else if(other.gameObject.tag == "Player")
        {
            other.transform.position = Destination.transform.position;
            other.transform.rotation = Destination.transform.rotation;
        }
    }    
}
