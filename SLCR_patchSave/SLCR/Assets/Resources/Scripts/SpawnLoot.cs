using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnLoot : MonoBehaviour
{
    public bool openable = true;
        public Transform loot1;
        public Transform loot2;
        public Transform loot3;
        public Transform loot4;

    // Start is called before the first frame update
    void Start()
    {
        //spawnGun();
        //spawnReceiver();
        //spawnBarrel();
        //spawnCaliber();
        //spawnCyclicModifier();
        //spawnMagazine();
        //spawnSight();
        //spawnStock();
        //spawnUnderBarrel();
        //spawnHealth();
    }

    public void openChest()
    {
        if (openable)
        {
            rollSpawn(loot1);
            rollSpawn(loot2);
            rollSpawn(loot3);
            rollSpawn(loot4);
        }
        openable = false;
    }

    void rollSpawn(Transform location)
    {
        //10 functions
       int randoRoll = Random.Range(0, 10);

        switch (randoRoll)
        {
            case 0:
                spawnGun(location);
                break;
            case 1:
                spawnReceiver(location);
                break;
            case 2:
                spawnBarrel(location);
                break;
            case 3:
                spawnCaliber(location);
                break;
            case 4:
                spawnCyclicModifier(location);
                break;
            case 5:
                spawnMagazine(location);
                break;
            case 6:
                spawnSight(location);
                break;
            case 7:
                spawnStock(location);
                break;
            case 8:
                spawnUnderBarrel(location);
                break;
            case 9:
                spawnHealth(location);
                break;

            default:
                Debug.Log("Spawner rolled a nonsensical value");
                break;
        }
    }

/**
* @pre: N/A.
* @post: A random gun will be created and built with calculated stats.
* @param: None.
* @return: None.
*/
    void spawnGun(Transform location)
    {
        Object[] possible;
            possible = Resources.LoadAll("GunParts/Receiver", typeof(Receiver));
            //Make an instance, then call buildGun on the instantiated copy.
            Receiver gun;
            gun = Instantiate((Receiver)possible[Random.Range(0, possible.Length)], location);
            gun.BuildGun();
            gun.CalculateStats();
    }

/**
* @pre: N/A.
* @post: A reciever will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnReceiver(Transform location)
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Receiver", typeof(Receiver));
        Receiver gun;
        gun = Instantiate((Receiver)possible[Random.Range(0, possible.Length)], location);
    }

/**
* @pre: N/A.
* @post: A barrel will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnBarrel(Transform location)
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Barrel", typeof(Barrel));
        Barrel barr;
        barr = Instantiate((Barrel)possible[Random.Range(0, possible.Length)], location);
    }

/**
* @pre: N/A.
* @post: A caliber will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnCaliber(Transform location)
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Caliber", typeof(Caliber));
        Caliber cal;
        cal = Instantiate((Caliber)possible[Random.Range(0, possible.Length)], location);
    }

/**
* @pre: N/A.
* @post: A cyclic modifier will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnCyclicModifier(Transform location)
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/CyclicModifier", typeof(CyclicModifier));
        CyclicModifier cyc;
        cyc = Instantiate((CyclicModifier)possible[Random.Range(0, possible.Length)], location);
    }

/**
* @pre: N/A.
* @post: A magazine will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnMagazine(Transform location)
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Magazine", typeof(Magazine));
        Magazine mag;
        mag = Instantiate((Magazine)possible[Random.Range(0, possible.Length)], location);
    }

/**
* @pre: N/A.
* @post: A sight will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnSight(Transform location)
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Sight", typeof(Sight));
        Sight sig;
        sig = Instantiate((Sight)possible[Random.Range(0, possible.Length)], location);
    }

/**
* @pre: N/A.
* @post: A stock will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnStock(Transform location)
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Stock", typeof(Stock));
        Stock sto;
        sto = Instantiate((Stock)possible[Random.Range(0, possible.Length)], location);
    }

/**
* @pre: N/A.
* @post: An underbarrel will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnUnderBarrel(Transform location)
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/UnderBarrel", typeof(UnderBarrel));
        UnderBarrel undBar;
        undBar = Instantiate((UnderBarrel)possible[Random.Range(0, possible.Length)], location);
    }

/**
* @pre: N/A.
* @post: Health will be spawned for collection.
* @param: None.
* @return: None.
*/
    void spawnHealth(Transform location)
    {
        Object[] possible;
        possible = Resources.LoadAll("Health", typeof(Health));
        Health hea;
        hea = Instantiate((Health)possible[Random.Range(0, possible.Length)], location);
    }





    // Update is called once per frame
    void Update()
    {
        



    }
}
