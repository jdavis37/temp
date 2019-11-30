using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StandardReceiver : Receiver
{
    public bool buildOnStart = false;
    new public const int NUM_PARTS = 8;
    public AmmoType ammo;
    public Barrel barrel;
    public Caliber caliber;
    public CyclicModifier cyclicModifier;
    public Magazine magazine;
    public Sight sight;
    public Stock stock;
    public UnderBarrel underBarrel;
    public int fireDamage;

    /**
   * @pre: N/A.
   * @post: Calls stock's recoil function, a dummy function for now.
   * @param: None.
   * @return: Stub, should return if gun recoils correctly.
   */
    public override bool FireRecoil()
    {
        stock.Recoil();
        return true;
    }

    /**
   * @pre: N/A.
   * @post: Calls the cyclicModifier's HoldFire function.
   * @param: None.
   * @return: Stub for now, should return if cyclicModifier's HoldFire function returns correctly.
   */
    public override bool HoldFire(Vector3 position, Quaternion angle)
    {
        cyclicModifier.HoldFire(position, angle);
        return true;
    }

    /**
   * @pre: N/A.
   * @post: Calls the cyclicModifier's ReleaseHoldFire function.
   * @param: None.
   * @return: Stub for now, should return if cyclicModifier's ReleaseHoldFire function returns correctly.
   */
    public override bool ReleaseHoldFire()
    {
        cyclicModifier.ReleaseHoldFire();
        return true;
    }

    /**
   * @pre: N/A.
   * @post: Calls the underBarrel's AltFire function.
   * @param: None.
   * @return: Stub for now, should return if underBarrel's AltFire function returns correctly.
   */
    public override bool AltFire()
    {
        underBarrel.AltFire();
        return true;
    }

    /**
   * @pre: N/A.
   * @post: Calls the sight's ADS function.
   * @param: None.
   * @return: Stub for now, should return if sight's ADS function returns correctly.
   */
    public override bool ADS()
    {
        sight.ADSToggle();
        return true;
    }

    /**
   * @pre: N/A.
   * @post: Gun's loaded ammo should be refilled.
   * @param: None.
   * @return: Stub for now, should return if reload occurs with no issues function returns correctly.
   */
    public override bool ReloadMag()
    {
        loadedAmmoCount = capacity;
        return true;
    }

    /**
   * @pre: None.
   * @post: Gun's parts should be rolled, ready for stats to be calculated.
   * @param: None.
   * @return: Stub for now, should return if build occurs with no issues function returns correctly.
   */

    public override bool BuildGun()
    {
        ammo = Instantiate(RollAmmo(), this.transform);
        barrel = Instantiate(RollBarrel(), this.transform);
        caliber = Instantiate(RollCaliber(), this.transform);
        cyclicModifier = Instantiate(RollCyclicModifier(), this.transform);
        cyclicModifier.Attach(this);
        magazine = Instantiate(RollMagazine(), this.transform);
        sight = Instantiate(RollSight(), this.transform);
        stock = Instantiate(RollStock(), this.transform);
        underBarrel = Instantiate(RollUnderBarrel(), this.transform);
        underBarrel.Attach(this);
        readyForUse = true;
        return true;
    }

    /**
   * @pre: Gun is built.
   * @post: parts array should be populated.
   * @param: None.
   * @return: None.
   */
    public override void CatalogParts()
    {
        parts[0] = ammo;
        parts[1] = barrel;
        parts[2] = caliber;
        parts[3] = cyclicModifier;
        parts[4] = magazine;
        parts[5] = sight;
        parts[6] = stock;
        parts[7] = underBarrel;
    }

    public override bool Attach(AmmoType input)
    {
        ammo = input;
        input.transform.position = transform.position;
        input.transform.parent = transform;
        return false;
    }

    public override bool Attach(Barrel input)
    {
        barrel = input;
        input.transform.position = transform.position;
        input.transform.parent = transform;
        return false;
    }

    public override bool Attach(Caliber input)
    {
        caliber = input;
        input.transform.position = transform.position;
        input.transform.parent = transform;
        return false;
    }

    public override bool Attach(CyclicModifier input)
    {
        cyclicModifier = input;
        input.transform.position = transform.position;
        input.transform.parent = transform;
        return false;
    }

    public override bool Attach(Magazine input)
    {
        magazine = input;
        input.transform.position = transform.position;
        input.transform.parent = transform;
        return false;
    }

    public override bool Attach(Sight input)
    {
        sight = input;
        input.transform.position = transform.position;
        input.transform.parent = transform;
        return false;
    }

    public override bool Attach(Stock input)
    {
        stock = input;
        input.transform.position = transform.position;
        input.transform.parent = transform;
        return false;
    }

    public override bool Attach(UnderBarrel input)
    {
        underBarrel = input;
        input.transform.position = transform.position;
        input.transform.parent = transform;
        return false;
    }

    public override AmmoType DetachAmmoType()
    {
        AmmoType ToReturn = ammo;
        ammo.transform.parent = null;
        ammo = null;
        readyForUse = false;
        return ToReturn;
    }

    public override Barrel DetachBarrel()
    {
        Barrel ToReturn = barrel;
        barrel.transform.parent = null;
        barrel = null;
        readyForUse = false;
        return ToReturn;
    }

    public override Caliber DetachCaliber()
    {
        Caliber ToReturn = caliber;
        caliber.transform.parent = null;
        caliber = null;
        readyForUse = false;
        return ToReturn;
    }

    public override CyclicModifier DetachCyclicModifier()
    {
        CyclicModifier ToReturn = cyclicModifier;
        cyclicModifier.transform.parent = null;
        cyclicModifier = null;
        readyForUse = false;
        return ToReturn;
    }

    public override Magazine DetachMagazine()
    {
        Magazine ToReturn = magazine;
        magazine.transform.parent = null;
        magazine = null;
        readyForUse = false;
        return ToReturn;
    }

    public override Sight DetachSight()
    {
        Sight ToReturn = sight;
        sight.transform.parent = null;
        sight = null;
        readyForUse = false;
        return ToReturn;
    }

    public override Stock DetachStock()
    {
        Stock ToReturn = stock;
        stock.transform.parent = null;
        stock = null;
        readyForUse = false;
        return ToReturn;
    }

    public override UnderBarrel DetachUnderBarrel()
    {
        UnderBarrel ToReturn = underBarrel;
        underBarrel.transform.parent = null;
        underBarrel = null;
        readyForUse = false;
        return ToReturn;
    }
}
