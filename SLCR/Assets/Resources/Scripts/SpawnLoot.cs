using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        spawnGun();
        spawnReceiver();
        spawnBarrel();
        spawnCaliber();
        spawnCyclicModifier();
        spawnMagazine();
        spawnSight();
        spawnStock();
        spawnUnderBarrel();
        spawnHealth();
    }

/**
* @pre: N/A.
* @post: A random gun will be created and built with calculated stats.
* @param: None.
* @return: None.
*/
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

/**
* @pre: N/A.
* @post: A reciever will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnReceiver()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Receiver", typeof(Receiver));
        Receiver gun;
        gun = Instantiate((Receiver)possible[Random.Range(0, possible.Length)]);
    }

/**
* @pre: N/A.
* @post: A barrel will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnBarrel()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Barrel", typeof(Barrel));
        Barrel barr;
        barr = Instantiate((Barrel)possible[Random.Range(0, possible.Length)]);
    }

/**
* @pre: N/A.
* @post: A caliber will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnCaliber()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Caliber", typeof(Caliber));
        Caliber cal;
        cal = Instantiate((Caliber)possible[Random.Range(0, possible.Length)]);
    }

/**
* @pre: N/A.
* @post: A cyclic modifier will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnCyclicModifier()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/CyclicModifier", typeof(CyclicModifier));
        CyclicModifier cyc;
        cyc = Instantiate((CyclicModifier)possible[Random.Range(0, possible.Length)]);
    }

/**
* @pre: N/A.
* @post: A magazine will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnMagazine()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Magazine", typeof(Magazine));
        Magazine mag;
        mag = Instantiate((Magazine)possible[Random.Range(0, possible.Length)]);
    }

/**
* @pre: N/A.
* @post: A sight will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnSight()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Sight", typeof(Sight));
        Sight sig;
        sig = Instantiate((Sight)possible[Random.Range(0, possible.Length)]);
    }

/**
* @pre: N/A.
* @post: A stock will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnStock()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Stock", typeof(Stock));
        Stock sto;
        sto = Instantiate((Stock)possible[Random.Range(0, possible.Length)]);
    }

/**
* @pre: N/A.
* @post: An underbarrel will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnUnderBarrel()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/UnderBarrel", typeof(UnderBarrel));
        UnderBarrel undBar;
        undBar = Instantiate((UnderBarrel)possible[Random.Range(0, possible.Length)]);
    }

/**
* @pre: N/A.
* @post: Health will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnHealth()
    {
        Object[] possible;
        possible = Resources.LoadAll("Health", typeof(Health));
        Health hea;
        hea = Instantiate((Health)possible[Random.Range(0, possible.Length)]);
    }





    // Update is called once per frame
    void Update()
    {
        



    }
}
