using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        spawnGun();
    }
    

    void spawnGun()
    {
        Object[] possible;
            possible = Resources.LoadAll("GunParts/Receiver", typeof(Receiver));
            //Make an instance, then call buildGun on the instantiated copy.
            Receiver gun;
            gun = Instantiate((Receiver)possible[Random.Range(0, possible.Length)]);
            gun.BuildGun();
            gun.CalculateStats();
    }

    void spawnReceiver()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Receiver", typeof(Receiver));
        Receiver gun;
        gun = Instantiate((Receiver)possible[Random.Range(0, possible.Length)]);
    }



    // Update is called once per frame
    void Update()
    {
        



    }
}
