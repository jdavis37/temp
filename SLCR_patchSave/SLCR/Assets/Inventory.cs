using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public AmmoType test;
    public List<AmmoType> ammoTypes = new List<AmmoType>();
    public List<Barrel> barrels = new List<Barrel>();
    public List<Caliber> calibers = new List<Caliber>();
    public List<CyclicModifier> cyclicModifiers = new List<CyclicModifier>();
    public List<Magazine> magazines = new List<Magazine>();
    public List<Receiver> receivers = new List<Receiver>();
    public List<Sight> sights = new List<Sight>();
    public List<Stock> stocks = new List<Stock>();
    public List<UnderBarrel> underBarrels = new List<UnderBarrel>();
    public List<GunPart> otherParts = new List<GunPart>();

    public List<Receiver> builtGuns = new List<Receiver>();

    public bool EscapeKey = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AmmoType TakeAmmoTypeFromInventory(int index)
    {
        if (index <= ammoTypes.Count - 1)
        {
            AmmoType returnItem = ammoTypes[index];
            ammoTypes.RemoveAt(index);
            return returnItem;
        }
        else
        {
            AmmoType returnItem = ammoTypes[ammoTypes.Count - 1];
            ammoTypes.RemoveAt(ammoTypes.Count - 1);
            return returnItem;
        }
    }

    public Barrel TakeBarrelFromInventory(int index)
    {
        if (index <= barrels.Count - 1)
        {
            Barrel returnItem = barrels[index];
            barrels.RemoveAt(index);
            return returnItem;
        }
        else
        {
            Barrel returnItem = barrels[barrels.Count - 1];
            barrels.RemoveAt(barrels.Count - 1);
            return returnItem;
        }
    }

    public Caliber TakeCaliberFromInventory(int index)
    {
        if (index <= calibers.Count - 1)
        {
            Caliber returnItem = calibers[index];
            calibers.RemoveAt(index);
            return returnItem;
        }
        else
        {
            Caliber returnItem = calibers[calibers.Count - 1];
            calibers.RemoveAt(calibers.Count - 1);
            return returnItem;
        }
    }

    public CyclicModifier TakeCyclicModifierFromInventory(int index)
    {
        if (index <= cyclicModifiers.Count - 1)
        {
            CyclicModifier returnItem = cyclicModifiers[index];
            cyclicModifiers.RemoveAt(index);
            return returnItem;
        }
        else
        {
            CyclicModifier returnItem = cyclicModifiers[cyclicModifiers.Count - 1];
            cyclicModifiers.RemoveAt(cyclicModifiers.Count - 1);
            return returnItem;
        }
    }

    public Magazine TakeMagazineFromInventory(int index)
    {
        if (index <= magazines.Count - 1)
        {
            Magazine returnItem = magazines[index];
            magazines.RemoveAt(index);
            return returnItem;
        }
        else
        {
            Magazine returnItem = magazines[magazines.Count - 1];
            magazines.RemoveAt(magazines.Count - 1);
            return returnItem;
        }
    }

    public Receiver TakeReceiverFromInventory(int index)
    {
        if (index <= receivers.Count - 1)
        {
            Receiver returnItem = receivers[index];
            receivers.RemoveAt(index);
            return returnItem;
        }
        else
        {
            Receiver returnItem = receivers[receivers.Count - 1];
            receivers.RemoveAt(receivers.Count - 1);
            return returnItem;
        }
    }

    public Sight TakeSightFromInventory(int index)
    {
        if (index <= sights.Count - 1)
        {
            Sight returnItem = sights[index];
            sights.RemoveAt(index);
            return returnItem;
        }
        else
        {
            Sight returnItem = sights[sights.Count - 1];
            sights.RemoveAt(sights.Count - 1);
            return returnItem;
        }
    }

    public Stock TakeStockFromInventory(int index)
    {
        if (index <= stocks.Count - 1)
        {
            Stock returnItem = stocks[index];
            stocks.RemoveAt(index);
            return returnItem;
        }
        else
        {
            Stock returnItem = stocks[stocks.Count - 1];
            stocks.RemoveAt(stocks.Count - 1);
            return returnItem;
        }
    }

    public UnderBarrel TakeUnderBarrelFromInventory(int index)
    {
        if (index <= underBarrels.Count - 1)
        {
            UnderBarrel returnItem = underBarrels[index];
            underBarrels.RemoveAt(index);
            return returnItem;
        }
        else
        {
            UnderBarrel returnItem = underBarrels[underBarrels.Count - 1];
            underBarrels.RemoveAt(underBarrels.Count - 1);
            return returnItem;
        }
    }

    public GunPart TakeOtherFromInventory(int index)
    {
        if (index <= otherParts.Count - 1)
        {
            GunPart returnItem = otherParts[index];
            otherParts.RemoveAt(index);
            return returnItem;
        }
        else
        {
            GunPart returnItem = otherParts[otherParts.Count - 1];
            otherParts.RemoveAt(otherParts.Count - 1);
            return returnItem;
        }
    }

    public Receiver TakeBuiltGunFromInventory(int index)
    {
        if (index <= builtGuns.Count - 1)
        {
            Receiver returnItem = builtGuns[index];
            builtGuns.RemoveAt(index);
            return returnItem;
        }
        else
        {
            Receiver returnItem = builtGuns[builtGuns.Count - 1];
            builtGuns.RemoveAt(builtGuns.Count - 1);
            return returnItem;
        }
        

    }



    public void AddToInventory(AmmoType input)
    {
        ammoTypes.Add(input);
        input.transform.parent = transform;
    }

    public void AddToInventory(Barrel input)
    {
        barrels.Add(input);
        input.transform.parent = transform;
    }

    public void AddToInventory(Caliber input)
    {
        calibers.Add(input);
        input.transform.parent = transform;
    }

    public void AddToInventory(CyclicModifier input)
    {
        cyclicModifiers.Add(input);
        input.transform.parent = transform;
    }

    public void AddToInventory(Magazine input)
    {
        magazines.Add(input);
        input.transform.parent = transform;
    }

    public void AddToInventory(Receiver input)
    {
        if (input.readyForUse)
            builtGuns.Add(input);
        else
            receivers.Add(input);
        input.transform.parent = transform;
    }

    public void AddToInventory(Sight input)
    {
        sights.Add(input);
        input.transform.parent = transform;
    }

    public void AddToInventory(Stock input)
    {
        stocks.Add(input);
        input.transform.parent = transform;
    }

    public void AddToInventory(UnderBarrel input)
    {
        underBarrels.Add(input);
        input.transform.parent = transform;
    }

    public void AddToInventory(GunPart input)
    {
        otherParts.Add(input);
        input.transform.parent = transform;
    }

   
}
