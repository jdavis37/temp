using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WinLoot : MonoBehaviour
{
    public GameObject Player;
    public bool openable = true;
    public Transform loot1;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
    }

    public void openChest()
    {
        if (openable)
        {
            Player.GetComponent<Inventory>().EscapeKey = true;
            openable = false;
        }
    }

}
