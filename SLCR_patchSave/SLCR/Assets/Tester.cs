using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Tester : MonoBehaviour
{
    public CraftingStation craft;
    public Inventory inventory;
    public PlayerController player;
    public TextAsset output;
    public StreamWriter write;
    public AmmoType testAmmo1;
    public AmmoType testAmmo2;
    public Barrel testBarrel1;
    public Barrel testBarrel2;
    public Caliber testCaliber1;
    public Caliber testCaliber2;
    public CyclicModifier testCyclicModifier1;
    public CyclicModifier testCyclicModifier2;
    public Magazine testMagazine1;
    public Magazine testMagazine2;
    public Receiver testReceiver1;
    public Receiver testReceiver2;
    public Sight testSight1;
    public Sight testSight2;
    public Stock testStock1;
    public Stock testStock2;
    public UnderBarrel testUnderBarrel1;
    public UnderBarrel testUnderBarrel2;
    public string outputLocation = "Assets/Resources/Output/TestOutput.txt";
    public string outputText = "";

    // Start is called before the first frame update
    void Start()
    {
        StartTests();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartTests()
    {
        if (TestInventory())
        {
            outputText = outputText + "    Inventory seems to be working correctly\n";
        }
        else 
        {
            outputText = outputText + "    Inventory seems to be working incorrectly\n";
        }
        if(TestCraft())
        {
            outputText = outputText + "    Crafting seems to be working correctly\n";
        }
        else
        {
            outputText = outputText + "    Crafting seems to be working incorrectly\n";
        }

        StreamWriter writer = new StreamWriter(outputLocation);
        writer.WriteLine(outputText);
        writer.Close();
    }

    bool TestInventory()
    {
        if (TestInventoryAddToInventory() && TestInventoryTakeFromInventory())
            return true;
        else
            return false;
    }

    bool TestInventoryAddToInventory()
    {
        bool testFlag = true;
        ClearInventory();
        inventory.AddToInventory(testAmmo1);
        if (inventory.ammoTypes.Count != 1 ||
            inventory.barrels.Count != 0 ||
            inventory.calibers.Count != 0 ||
            inventory.magazines.Count != 0 ||
            inventory.receivers.Count != 0 ||
            inventory.builtGuns.Count != 0 ||
            inventory.sights.Count != 0 ||
            inventory.stocks.Count != 0 ||
            inventory.underBarrels.Count != 0 ||
            inventory.otherParts.Count != 0)
        {
            outputText = outputText + "Adding to an empty list isn't worrking correctly\n";
            testFlag = false;
        }
        else
        outputText = outputText + "Adding to an empty list is worrking correctly\n";

        inventory.AddToInventory(testAmmo1);
        if (inventory.ammoTypes.Count != 2 ||
            inventory.barrels.Count != 0 ||
            inventory.calibers.Count != 0 ||
            inventory.magazines.Count != 0 ||
            inventory.receivers.Count != 0 ||
            inventory.builtGuns.Count != 0 ||
            inventory.sights.Count != 0 ||
            inventory.stocks.Count != 0 ||
            inventory.underBarrels.Count != 0 ||
            inventory.otherParts.Count != 0)
        {
            outputText = outputText + "Adding to an non-empty list isn't worrking correctly\n";
            testFlag = false;
        }
        else
            outputText = outputText + "Adding to an non-empty list is worrking correctly\n";

        return testFlag;
    }

    
    bool TestInventoryTakeFromInventory()
    {
        bool testFlag = true;
        ClearInventory();
        inventory.AddToInventory(testAmmo1);
        if (testAmmo1 != inventory.TakeAmmoTypeFromInventory(0))
        {
            outputText = outputText + "Taking from a inventory isn't returning right part\n";
            testFlag = false;
        }
        else
            outputText = outputText + "Taking from a inventory is returning right part\n";

        if (inventory.ammoTypes.Count != 0 ||
            inventory.barrels.Count != 0 ||
            inventory.calibers.Count != 0 ||
            inventory.magazines.Count != 0 ||
            inventory.receivers.Count != 0 ||
            inventory.builtGuns.Count != 0 ||
            inventory.sights.Count != 0 ||
            inventory.stocks.Count != 0 ||
            inventory.underBarrels.Count != 0 ||
            inventory.otherParts.Count != 0)
        {
            outputText = outputText + "Taking from a inventory isn't removing from inventory\n";
            testFlag = false;
        }
        else
            outputText = outputText + "Taking from a inventory is removing from inventory\n";

        return testFlag;
    }

    bool TestCraft()
    {
        if (TestCraftBuildGun() && TestCraftBreakDownGun())
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    bool TestCraftBuildGun()
    {
        bool testFlag = true;
          ClearInventory();
        inventory.AddToInventory(testAmmo1);
        inventory.AddToInventory(testBarrel1);
        inventory.AddToInventory(testCaliber1);
        inventory.AddToInventory(testCyclicModifier1);
        inventory.AddToInventory(testMagazine1);
        inventory.AddToInventory(testReceiver1);
        inventory.AddToInventory(testSight1);
        inventory.AddToInventory(testStock1);
        inventory.AddToInventory(testUnderBarrel1);
        craft.ammos.value = 0;
        craft.barrels.value = 0;
        craft.calibers.value = 0;
        craft.cyclicModifiers.value = 0;
        craft.magazines.value = 0;
        craft.receivers.value = 0;
        craft.sights.value = 0;
        craft.stocks.value = 0;
        craft.underBarrels.value = 0;
        craft.BuildGun();
        if (inventory.ammoTypes.Count != 0 ||
            inventory.barrels.Count != 0 ||
            inventory.calibers.Count != 0 ||
            inventory.magazines.Count != 0 ||
            inventory.receivers.Count != 0 ||
            inventory.builtGuns.Count != 1 ||
            inventory.sights.Count != 0 ||
            inventory.stocks.Count != 0 ||
            inventory.underBarrels.Count != 0 ||
            inventory.otherParts.Count != 0)
        {
            outputText = outputText + "Building a gun doesn't take parts from inventory\n";
            testFlag = false;
        }
        else
        {
            outputText = outputText + "Building a gun does take parts from inventory\n"; 
        }
        if (inventory.builtGuns.Count != 1)
        {
            outputText = outputText + "Building a gun doesn't produce a gun properly\n";
            testFlag = false;
        }
        else 
        {
            outputText = outputText + "Building a gun does produce a gun properly\n";
        }
        craft.Guns.value = 0;
        return testFlag;
    }

    bool TestCraftBreakDownGun()
    {
        
        bool testFlag = true;
        
        craft.RecycleGun();

        if (inventory.ammoTypes.Count != 0 ||
            inventory.barrels.Count != 0 ||
            inventory.calibers.Count != 0 ||
            inventory.magazines.Count != 0 ||
            inventory.receivers.Count != 0 ||
            inventory.sights.Count != 0 ||
            inventory.stocks.Count != 0 ||
            inventory.underBarrels.Count != 0 ||
            inventory.otherParts.Count != 0)
        {
            outputText = outputText + "Trying to Recycle the last gun does add parts to inventory, shouldn't do that\n";
            testFlag = false;
        }
        else
        {
            outputText = outputText + "Trying to Recycle the last gun doesn't add parts to inventory\n";
        }

        if (inventory.builtGuns.Count != 1)
        {
            outputText = outputText + "Trying to recycle the last gun does remove the gun from inventory, shouldn't do that\n";
            testFlag = false;
        }
        else
        {
            outputText = outputText + "Trying to recycle the last gun doesn't remove the gun from inventory\n";
        }
            
        inventory.AddToInventory(testAmmo2);
        inventory.AddToInventory(testBarrel2);
        inventory.AddToInventory(testCaliber2);
        inventory.AddToInventory(testCyclicModifier2);
        inventory.AddToInventory(testMagazine2);
        inventory.AddToInventory(testReceiver2);
        inventory.AddToInventory(testSight2);
        inventory.AddToInventory(testStock2);
        inventory.AddToInventory(testUnderBarrel2);
        craft.ammos.value = 0;
        craft.barrels.value = 0;
        craft.calibers.value = 0;
        craft.cyclicModifiers.value = 0;
        craft.magazines.value = 0;
        craft.receivers.value = 0;
        craft.sights.value = 0;
        craft.stocks.value = 0;
        craft.underBarrels.value = 0;
        craft.BuildGun();
        craft.UpdateCraft(player);
        craft.RecycleGun();

        if (inventory.ammoTypes.Count != 1 ||
           inventory.barrels.Count != 1 ||
           inventory.calibers.Count != 1 ||
           inventory.magazines.Count != 1 ||
           inventory.receivers.Count != 1 ||
           inventory.sights.Count != 1 ||
           inventory.stocks.Count != 1 ||
           inventory.underBarrels.Count != 1)
        {
            outputText = outputText + "Trying to Recycle gun that isn't last doesn't add parts to inventory\n";
            testFlag = false;
        }
        else
        {
            outputText = outputText + "Trying to Recycle gun that isn't last does add parts to inventory\n";
        }

        if (inventory.builtGuns.Count != 1)
        {
            outputText = outputText + "Trying to Recycle gun that isn't last doesn't remove the gun from inventory\n";
            testFlag = false;
        }
        else
        {
            outputText = outputText + "Trying to Recycle gun that isn't last does remove the gun from inventory\n";
        }
        return testFlag;
    }

    void ClearInventory()
    {
        inventory.ammoTypes.Clear();
        inventory.barrels.Clear();
        inventory.calibers.Clear();
        inventory.cyclicModifiers.Clear();
        inventory.magazines.Clear();
        inventory.receivers.Clear();
        inventory.sights.Clear();
        inventory.stocks.Clear();
        inventory.underBarrels.Clear();
        inventory.builtGuns.Clear();
    }
}
