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

    void spawnBarrel()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Barrel", typeof(Barrel));
        Barrel barr;
        barr = Instantiate((Barrel)possible[Random.Range(0, possible.Length)]);
    }

    void spawnCaliber()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Caliber", typeof(Caliber));
        Caliber cal;
        cal = Instantiate((Caliber)possible[Random.Range(0, possible.Length)]);
    }

    void spawnCyclicModifier()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/CyclicModifier", typeof(CyclicModifier));
        CyclicModifier cyc;
        cyc = Instantiate((CyclicModifier)possible[Random.Range(0, possible.Length)]);
    }

    void spawnMagazine()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Magazine", typeof(Magazine));
        Magazine mag;
        mag = Instantiate((Magazine)possible[Random.Range(0, possible.Length)]);
    }

    void spawnSight()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Sight", typeof(Sight));
        Sight sig;
        sig = Instantiate((Sight)possible[Random.Range(0, possible.Length)]);
    }

    void spawnStock()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Stock", typeof(Stock));
        Stock sto;
        sto = Instantiate((Stock)possible[Random.Range(0, possible.Length)]);
    }

    void spawnUnderBarrel()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/UnderBarrel", typeof(UnderBarrel));
        UnderBarrel undBar;
        undBar = Instantiate((UnderBarrel)possible[Random.Range(0, possible.Length)]);
    }

    //void spawnHealth()
    //{
    //    Object[] possible;
    //    possible = Resources.LoadAll("Health", typeof(Health));
    //    Health hea;
    //    Health = Instantiate((Health)possible[Random.Range(0, possible.Length)]);
    //}





    // Update is called once per frame
    void Update()
    {
        



    }
}
