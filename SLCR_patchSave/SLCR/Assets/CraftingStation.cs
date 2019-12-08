using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingStation : MonoBehaviour
{
    public PlayerController player;
    public Receiver loadedGun;
    public Dropdown ammos;
    public Dropdown barrels;
    public Dropdown calibers;
    public Dropdown cyclicModifiers;
    public Dropdown magazines;
    public Dropdown receivers;
    public Dropdown sights;
    public Dropdown stocks;
    public Dropdown underBarrels;
    public Dropdown Guns;
    public InputField nameInput;
    // Damage after weapon mods
    public Text damage;
    // Sets per fire after weapon mods
    public Text setsPerFire;
    // Shots per set after weapon mods
    public Text shotsPerSet;
    // Spread in degrees after weapon mods
    public Text precision;
    // Rounds per minute after weapon mods
    public Text fireRate;
    // Recoil per shot after weapon mods
    public Text recoil;
    // Max ammo loaded per mag after weapon mods
    public Text capacity;
    // time for reload after weapon mods
    public Text reload;
    // Velocity of produced rounds after weapon mods
    public Text velocity;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCraft(player);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.inventory.builtGuns.Count != 0)
        {
            CalcStats(loadedGun);
            loadedGun = player.inventory.builtGuns[Guns.value];
        }
        
    }

    void CalcStats(Receiver input)
    {
        
        if (input != null)
        {
            damage.text = "Damage: " + input.damage.ToString();
            setsPerFire.text = "SetsPerFire: " + input.setsPerFire.ToString();
            shotsPerSet.text = "ShotsPerSet: " + input.shotsPerSet.ToString();
            precision.text = "Precision: " + input.precision.ToString();
            fireRate.text = "Firerate: " + input.fireRate.ToString();
            recoil.text = "Recoil: " + input.recoil.ToString();
            capacity.text = "Capacity: " + input.capacity.ToString();
            reload.text = "Reload: " + input.reload.ToString();
            velocity.text = "Velocity: " + input.velocity.ToString();
        }
    }

    public void UpdateCraft(PlayerController input)
    {
        ammos.ClearOptions();
        ammos.AddOptions(ConvertToStringList(input.inventory.ammoTypes));
        
        barrels.ClearOptions();
        barrels.AddOptions(ConvertToStringList(input.inventory.barrels));

        calibers.ClearOptions();
        calibers.AddOptions(ConvertToStringList(input.inventory.calibers));

        cyclicModifiers.ClearOptions();
        cyclicModifiers.AddOptions(ConvertToStringList(input.inventory.cyclicModifiers));

        magazines.ClearOptions();
        magazines.AddOptions(ConvertToStringList(input.inventory.magazines));

        receivers.ClearOptions();
        receivers.AddOptions(ConvertToStringList(input.inventory.receivers));

        sights.ClearOptions();
        sights.AddOptions(ConvertToStringList(input.inventory.sights));

        stocks.ClearOptions();
        stocks.AddOptions(ConvertToStringList(input.inventory.stocks));

        underBarrels.ClearOptions();
        underBarrels.AddOptions(ConvertToStringList(input.inventory.underBarrels));

        Guns.ClearOptions();
        Guns.AddOptions(ConvertToStringList(input.inventory.builtGuns));
    }

    public void BuildGun()
    {
        if (
            player.inventory.ammoTypes.Count > 0 &&
            player.inventory.barrels.Count > 0 &&
            player.inventory.calibers.Count > 0 &&
            player.inventory.cyclicModifiers.Count > 0 &&
            player.inventory.magazines.Count > 0 &&
            player.inventory.sights.Count > 0 &&
            player.inventory.stocks.Count > 0 &&
            player.inventory.underBarrels.Count > 0 &&
            player.inventory.receivers.Count > 0
            )
        {
            player.inventory.receivers[receivers.value].Attach(player.inventory.TakeAmmoTypeFromInventory(ammos.value));
            player.inventory.receivers[receivers.value].Attach(player.inventory.TakeBarrelFromInventory(barrels.value));
            player.inventory.receivers[receivers.value].Attach(player.inventory.TakeCaliberFromInventory(calibers.value));
            player.inventory.receivers[receivers.value].Attach(player.inventory.TakeCyclicModifierFromInventory(cyclicModifiers.value));
            player.inventory.receivers[receivers.value].Attach(player.inventory.TakeMagazineFromInventory(magazines.value));
            player.inventory.receivers[receivers.value].Attach(player.inventory.TakeSightFromInventory(sights.value));
            player.inventory.receivers[receivers.value].Attach(player.inventory.TakeStockFromInventory(stocks.value));
            player.inventory.receivers[receivers.value].Attach(player.inventory.TakeUnderBarrelFromInventory(underBarrels.value));
            player.inventory.receivers[receivers.value].ID = nameInput.text;
            player.inventory.receivers[receivers.value].readyForUse = true;


            player.inventory.builtGuns.Add(player.inventory.TakeReceiverFromInventory(receivers.value));
        }

    }

    public void RecycleGun()
    {
        if (player.inventory.builtGuns.Count > 1)
        {
            player.inventory.builtGuns[Guns.value].readyForUse = false;
            player.inventory.AddToInventory(loadedGun.DetachAmmoType());
            player.inventory.AddToInventory(loadedGun.DetachBarrel());
            player.inventory.AddToInventory(loadedGun.DetachCaliber());
            player.inventory.AddToInventory(loadedGun.DetachCyclicModifier());
            player.inventory.AddToInventory(loadedGun.DetachMagazine());
            player.inventory.AddToInventory(loadedGun.DetachSight());
            player.inventory.AddToInventory(loadedGun.DetachStock());
            player.inventory.AddToInventory(loadedGun.DetachUnderBarrel());
            player.inventory.AddToInventory(player.inventory.TakeBuiltGunFromInventory(Guns.value));
        }
    }

    public void EquipWeaponFirst()
    {
        player.defaultWeapon = loadedGun;
    }

    public void EquipWeaponSecond()
    {
        player.secondWeapon = loadedGun;
    }

    public void EquipWeaponThird()
    {
        player.thirdWeapon = loadedGun;
    }

    List<string> ConvertToStringList(List<AmmoType> input)
    {
        List<string> returnList = new List<string>();
        foreach (AmmoType part in input)
        {
            returnList.Add(part.ID);
        }
        return returnList;
    }

    List<string> ConvertToStringList(List<Barrel> input)
    {
        List<string> returnList = new List<string>();
        foreach (Barrel part in input)
        {
            returnList.Add(part.ID);
        }
        return returnList;
    }

    List<string> ConvertToStringList(List<Caliber> input)
    {
        List<string> returnList = new List<string>();
        foreach (Caliber part in input)
        {
            returnList.Add(part.ID);
        }
        return returnList;
    }

    List<string> ConvertToStringList(List<CyclicModifier> input)
    {
        List<string> returnList = new List<string>();
        foreach (CyclicModifier part in input)
        {
            returnList.Add(part.ID);
        }
        return returnList;
    }

    List<string> ConvertToStringList(List<Magazine> input)
    {
        List<string> returnList = new List<string>();
        foreach (Magazine part in input)
        {
            returnList.Add(part.ID);
        }
        return returnList;
    }

    List<string> ConvertToStringList(List<Receiver> input)
    {
        List<string> returnList = new List<string>();
        foreach (Receiver part in input)
        {
            returnList.Add(part.ID);
        }
        return returnList;
    }

    List<string> ConvertToStringList(List<Sight> input)
    {
        List<string> returnList = new List<string>();
        foreach (Sight part in input)
        {
            returnList.Add(part.ID);
        }
        return returnList;
    }

    List<string> ConvertToStringList(List<Stock> input)
    {
        List<string> returnList = new List<string>();
        foreach (Stock part in input)
        {
            returnList.Add(part.ID);
        }
        return returnList;
    }

    List<string> ConvertToStringList(List<UnderBarrel> input)
    {
        List<string> returnList = new List<string>();
        foreach (UnderBarrel part in input)
        {
            returnList.Add(part.ID);
        }
        return returnList;
    }

    List<string> ConvertToStringList(List<GunPart> input)
    {
        List<string> returnList = new List<string>();
        foreach (GunPart part in input)
        {
            returnList.Add(part.ID);
        }
        return returnList;
    }
}
