using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : StandardReceiver
{
    //Next is health, gun parts

    /**
   * @pre: N/A.
   * @post: Gun should be set up for use by player.
   * @param: None.
   * @return: None.
   */
    public override void Start()
    {
        base.Start();
        parts = new GunPart[NUM_PARTS];
        BuildGun();
        CalculateStats();


    }

    // Update is called once per frame
    public override void Update()
    {

    }

    /**
   * @pre: CalculateStats function should be called on a fully built gun first .
   * @post: A shot should be produced if ammo can be deducted successfully and it is not cooling down from prior shot, nothing otherwise.
   * @param: None.
   * @return: Did at least one shot get produced.
   */
    public override bool Fire(Vector3 positon, Quaternion angle)
    {
        if (fireDelay == 0)
        {
            CalculateStats();
            fireDamage = (int)damage / shotsPerSet;
            for (int i = 0; setsPerFire > i; i++)
            {
                for (int j = 0; shotsPerSet > j; j++)
                {
                    if (loadedAmmoCount > 0)
                    {
                        ammo.Fire(new Vector3(0, 0, velocity), positon, angle, precision, fireDamage);
                        fireDelay = baseFireDelay;
                    }

                }
                loadedAmmoCount--;
            }

            return true;
        }

        else
        {
            return false;
        }
    }
    

}
