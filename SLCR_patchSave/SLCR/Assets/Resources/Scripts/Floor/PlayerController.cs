﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : Character
{
    public bool Victory = false;
    // Camera attached to player. Needed for Aiming
    public Camera cam;
    // Value for hover function. Unused Currently
    public int hoverTime = 0;
    // Value for jumping, 1 allows for no air jumps
    int jumpsRemaining;
    // Force upwards used for jumping
    public float jumpForce = 10.0f;
    public Inventory inventory;

    public float lookpitch = 0;
    private float rightLeftPrior = 0;
    private float forwardBackPrior = 0;
    private float jumpPrior = 0;
    private float firePrior = 0;
    private float altFirePrior = 0;
    private float aimPrior = 0;
    private float selectWeaponBackPrior = 0;
    private float selectWeaponForwardPrior = 0;
    private float selectPrior = 0;
    private float submitPrior = 0;
    private float reloadPrior = 0;
    private float interactPrior = 0;
    public int rightLeftHeld = 0;
    public int forwardBackHeld = 0;
    public int jumpHeld = 0;
    public int fireHeld = 0;
    public int altFireHeld = 0;
    public int aimHeld = 0;
    public int reloadHeld = 0;
    public int selectWeaponBackHeld = 0;
    public int selectWeaponForwardHeld = 0;
    public int selectHeld = 0;
    public int submitHeld = 0;
    public int interactHeld = 0;

    // If the player is on the ground
    public bool grounded = true;

    //If the player is currently holding the fire button
    public bool holdFire = false;
    //If the player is currently holding the altFire button
    public bool holdAltFire = false;
    //If the player is currently holding the ADS button
    public bool holdADS = false;
    //If the player is currently holding the holdReload button
    public bool holdReload = false;
    //If the player is currently holding attacking
    public bool attacking = false;
    //If current action can be interupted. Not used currently
    public bool cancelable = true;

    //Timer for cancel mechanics, Not currently used
    public float timeCombo = -1f;
    //Timer for cancel mechanics, Not currently used
    public float timeCancel = -1f;
    //Timer for cancel mechanics, Not currently used
    public int attackState = 0;

    //Switch to control how player swaps between weapons
    public int weaponStyle;
    //Weapon player is currently using
    public Receiver equipedWeapon;
    //Starting Receiver of player/ first weapon
    public Receiver defaultWeapon;
    //Second Receiver player has equiped
    public Receiver secondWeapon;
    //Third Receiver player has equiped
    public Receiver thirdWeapon;

    // Text for use with UI. Not currently Used.
    public Text TimeComboUI;
    // Text for use with UI. Not currently Used.
    public Text TimeCancelUI;
    // Text for use with UI. Not currently Used.
    public Text attackStateUI;
    // Text for use with UI. Not currently Used.
    public Text WeaponTextUI;

    // Timer for time player is unable to be hurt after taking damage
    public int iFrames;

    // Crosshair for player to use for gun.
    public GameObject reticle;

    // Player HUD containing health bar and ammo counter.
    public GameObject playerHUD;

    // Player Health Bar on Player HUD.
    public GameObject playerHealth;

    // Player Health Bar on Player HUD.
    public GameObject playerAmmo;

    // UI Panel to pop up when player wants to pause the game.
    public GameObject PauseMenu;
    // Resume Game Button found under Pause Menu.
    public Button resumeButton;
    // Pause Game Flag.
    public Text pauseMenuText;
    // Pause Menu / Start Menu Flag.
    public bool paused;
    public bool menuEnabled;

    // UI Panel to pop up when Player health is below Zero.
    public GameObject DeathScreen;
    public Text GameOverText;

    // PlayerIsDead Flag.
    bool PlayerIsDead;

    // UI Panel to pop up when Player wins the game.
    public GameObject WinScreen;

    public Button restartButton;

    // Use this for initialization
    public override void Start()
    {
        WinScreen.SetActive(false);
        DeathScreen.SetActive(false);
        playerHUD.SetActive(false);
        reticle.SetActive(false);
        PauseMenu.SetActive(true);
        resumeButton.onClick.AddListener(PauseMenuController);
        menuEnabled = true;
        base.Start();
        base.Start();
        jumpsRemaining = maxJump;
        restartButton.interactable = true;
        rb = this.GetComponent("Rigidbody") as Rigidbody;
        tr = this.GetComponent("Transform") as Transform;
        //TimeComboUI.text = "ComboTime: " + timeCombo.ToString();
        //TimeCancelUI.text = "CancelTime: " + timeCancel.ToString();
        //attackStateUI.text = "AttackState: " + attackState.ToString();
        if (defaultWeapon != null)
        {
            equipedWeapon = defaultWeapon;
        }
        if (secondWeapon == null)
        {
            secondWeapon = defaultWeapon;
        }
        if (thirdWeapon == null)
        {
            thirdWeapon = defaultWeapon;
        }
        PlayerIsDead = false;

        playerAmmo.transform.localScale = new Vector3((float)equipedWeapon.loadedAmmoCount / (float)equipedWeapon.baseCapacity, 1, 1);
        playerAmmo.transform.localPosition = new Vector3(0 + ((float)equipedWeapon.loadedAmmoCount - (float)equipedWeapon.baseCapacity) / (((float)equipedWeapon.baseCapacity / 100) * 2), 0, 0);
    }

    /**
   * @pre: N/A.
   * @post: Player input should be parsed.
   * @param: None.
   * @return: None.
   */
    public override void Update()
    {
        HeldCheck();

        if (!menuEnabled && !PlayerIsDead)
        {   
            Attack();
            WeaponSelect();
            Invulnerability();
        }

        if (!defaultWeapon.readyForUse)
        {
            if (secondWeapon.readyForUse)
                defaultWeapon = secondWeapon;
            else if (thirdWeapon.readyForUse)
                defaultWeapon = thirdWeapon;
        }
        if (!secondWeapon.readyForUse)
        {
            secondWeapon = defaultWeapon;
        }
        if (!thirdWeapon.readyForUse)
        {
            thirdWeapon = defaultWeapon;
        }
        if (!equipedWeapon.readyForUse)
        {
            equipedWeapon = defaultWeapon;
        }

        if (Input.GetAxisRaw("Interact") == 1 && interactHeld == 0 && !paused)
        {
            Interact();
        }

        if (hoverTime == 0)
        {
            Hover(false, false, 0);
        }
        else
        {
            hoverTime--;
        }

        if (timeCancel > 0)
        {
            timeCancel--;
        }
        else
        {
            timeCancel = -1;
            cancelable = true;
        }


        if (timeCombo > 0)
        {
            timeCombo--;
        }
        else
        {
            timeCombo = -1f;
            attacking = false;
        }


        if (!attacking && !menuEnabled && !PlayerIsDead)
        {
            Jump();
            GravControl();
        }
        GunID();
    }

    /**
   * @pre: N/A.
   * @post: physics related requirements should be parsed.
   * @param: None.
   * @return: None.
   */
    public override void FixedUpdate()
    {
        if (!menuEnabled && !PlayerIsDead)
        {
            Look();
            Movement(Input.GetAxisRaw("ForwardBack") * speed, Input.GetAxisRaw("RightLeft") * speed);
            base.FixedUpdate();

        }



        // Check for movement and facing direction
        if (!grounded)
        {
            rb.AddForce(Physics.gravity * 2);

        }

        if (health > 0)
        {
            if (menuEnabled)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                ChangeHealth(1);
                if (equipedWeapon.loadedAmmoCount > 0)
                    playerAmmo.transform.localScale = new Vector3((float)equipedWeapon.loadedAmmoCount / (float)equipedWeapon.baseCapacity, 1, 1);
                else
                    playerAmmo.transform.localScale = new Vector3(0, 1, 1);

                if (equipedWeapon.capacity / 100 > 0)
                    playerAmmo.transform.localPosition = new Vector3(0 + ((float)equipedWeapon.loadedAmmoCount - (float)equipedWeapon.baseCapacity) / (((float)equipedWeapon.baseCapacity / 100) * 2), 0, 0);
                else
                    playerAmmo.transform.localPosition = new Vector3(0 + ((float)equipedWeapon.loadedAmmoCount - (float)equipedWeapon.baseCapacity) / 2, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                PauseMenuController();
            }
        }
        else
        {
            PlayerIsDead = true;
            playerAmmo.transform.localScale = new Vector3(0, 1, 1);
            playerAmmo.transform.localPosition = new Vector3(0 + ((float)equipedWeapon.loadedAmmoCount - (float)equipedWeapon.baseCapacity) / 2, 0, 0);
            playerHealth.transform.localScale = new Vector3(0, 1, 1);
            playerHealth.transform.localPosition = new Vector3(0 + (health - maxHealth) / 2, 0, 0);
            DeathScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            reticle.SetActive(false);
        }

        if(Victory)
        {
            PlayerIsDead = false;
            playerAmmo.transform.localScale = new Vector3(0, 1, 1);
            playerAmmo.transform.localPosition = new Vector3(0 + ((float)equipedWeapon.loadedAmmoCount - (float)equipedWeapon.baseCapacity) / 2, 0, 0);
            playerHealth.transform.localScale = new Vector3(0, 1, 1);
            playerHealth.transform.localPosition = new Vector3(0 + (health - maxHealth) / 2, 0, 0);
            WinScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            reticle.SetActive(false);
        }
    }

    /**
  * @pre: Either pause menu key is pressed or Resume Game button is pressed.
  * @post: PauseMenu/StartMenu is turned on and off.
  * @param: None.
  * @return: None.
  */
    public void PauseMenuController()
    {
        if (paused)
        {
            PauseMenu.SetActive(false);
            menuEnabled = false;
            paused = false;
            resumeButton.interactable = false;
            reticle.SetActive(true);
            playerHUD.SetActive(true);

            Debug.Log("Game Resumed");
        }
        else
        {
            pauseMenuText.text = "Game Paused";
            PauseMenu.SetActive(true);
            menuEnabled = true;
            paused = true;
            resumeButton.interactable = true;
            reticle.SetActive(false);
            playerHUD.SetActive(false);

            Debug.Log("Game Paused");
        }
    }

    /**
   * @pre: N/A.
   * @post: returns PlayerIsDead.
   * @param: None.
   * @return: None.
   */
    public bool IsPlayerDead()
    {
        return PlayerIsDead;
    }

    /**
   * @pre: All slots for the players Receiver's are filled.
   * @post: Player should swap to appropriate item if button to swap Receiver is pressed.
   * @param: None.
   * @return: None.
   */
    void WeaponSelect()
    {
        if (defaultWeapon != null)
        {


            if (Input.GetAxisRaw("SelectWeaponBack") == 1 && selectWeaponBackHeld == 0)
                {
                    if (equipedWeapon == defaultWeapon)
                    {
                        equipedWeapon = thirdWeapon;
                    }
                    
                    else if (equipedWeapon == secondWeapon)
                    {
                        equipedWeapon = defaultWeapon;
                    }
                    else
                    {
                        equipedWeapon = secondWeapon;
                    }
                    
                }
                
                else if (Input.GetAxisRaw("SelectWeaponForward") == 1 && selectWeaponForwardHeld == 0)
                {
                    if (equipedWeapon == defaultWeapon)
                    {
                        equipedWeapon = secondWeapon;
                    }
                    else if (equipedWeapon == secondWeapon)
                    {
                        equipedWeapon = thirdWeapon;
                    }
                    else
                    {
                        equipedWeapon = defaultWeapon;
                    }
                }
                
            //if (equipedWeapon.title != null)
            // WeaponTextUI.text = equipedWeapon.title;

        }
    }

    /**
   * @pre: N/A.
   * @post: Commands relating to equiped Receiver should be parsed.
   * @param: None.
   * @return: None.
   */
    void Attack()
    {
        if (defaultWeapon != null)
        {


            if (Input.GetAxisRaw("Fire") == 1 && fireHeld == 0)
            {
                Debug.Log(transform.rotation);
                // Quaternion derp = Quaternion.Euler(0, transform.rotation.y, 0);
                Quaternion derp = Quaternion.Euler(cam.transform.eulerAngles.x, transform.eulerAngles.y, 0);
                equipedWeapon.Fire(transform.position, derp);
            }
            else if (Input.GetAxisRaw("Fire") == 1 && fireHeld != 0)
            {
                Quaternion derp = Quaternion.Euler(cam.transform.eulerAngles.x, transform.eulerAngles.y, 0);
                equipedWeapon.HoldFire(transform.position, derp);
                holdFire = true;

            }
            else if (Input.GetAxisRaw("Fire") == 0 && holdFire)
            {
                equipedWeapon.ReleaseHoldFire();
                holdFire = false;
            }

            if (Input.GetAxisRaw("AltFire") == 1 && altFireHeld == 0)
            {

                equipedWeapon.AltFire();
            }

            if (Input.GetAxisRaw("ADS") == 1 && aimHeld == 0)
            {
                equipedWeapon.ADS();
            }

            if (Input.GetAxisRaw("Reload") == 1 && reloadHeld == 0)
            {
                equipedWeapon.ReloadMag();
            }


        }

        

    }

    /**
   * @pre: N/A.
   * @post: None currently. When implemented should allow for attacks to interupt eachother
   * @param: None.
   * @return: None.
   */
    public void Interupt()
    {
        if (defaultWeapon != null)
        {
            // defaultWeapon.Interupt();
            // secondWeapon.Interupt();
            //thirdWeapon.Interupt();
        }

    }

    /**
   * @pre: N/A.
   * @post: Resets players jumps when touching the ground or an enemy. Jump on enemies heads for style.
   * @param: None.
   * @return: None.
   */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Hostile")
        {
            jumpsRemaining = maxJump;
            grounded = true;
        }
    }

    /**
   * @pre: N/A.
   * @post: if player has jumps left, should be sent upwards.
   * @param: None.
   * @return: None.
   */
    void Jump()
    {
        if (rb != null)
        {
            if (Input.GetAxis("Jump") > 0 && jumpHeld == 0)
            {
                if (jumpsRemaining > 0)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                    rb.AddForce(new Vector3(0, jumpForce, 0));
                    grounded = false;
                    jumpsRemaining--;
                }
            }
        }
    }

    /**
   * @pre: N/A.
   * @post: Not currently implemented. After implementation should change player fall speed based on input
   * @param: None.
   * @return: None.
   */
    void GravControl()
    {
        if (Input.GetAxisRaw("Jump") < 0)
        {
            // rb.gravityScale = gravFast;
        }

        else if (Input.GetAxisRaw("Jump") > 0)
        {
            //rb.gravityScale = gravSlowed;
        }

        else
        {
            // rb.gravityScale = gravNormal;
        }
    }


    /**
   * @pre: N/A.
   * @post: Player's movement should be realitive to where they are looking.
   * @param: forwardBack and leftRight are how far forward and left the player should move.
   * @return: None.
   */
    public void Movement(float forwardBack, float leftRight)
    {
        if (rb != null)
            rb.velocity = new Quaternion(0, rb.rotation.y, 0, rb.rotation.w) * new Vector3(leftRight, rb.velocity.y, forwardBack);
    }

    /**
   * @pre: N/A.
   * @post: Player should look following the mouse.
   * @param: None.
   * @return: None.
   */
    public void Look()
    {
        if (cam != null)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
            lookpitch -= Input.GetAxis("Mouse Y");
            lookpitch = Mathf.Clamp(lookpitch, -90, 90);
            cam.transform.eulerAngles = new Vector3(lookpitch, transform.eulerAngles.y, 0);
        }
    }

    /**
   * @pre: N/A.
   * @post: Not yet implemented. Once implemented should teleport player to area described
   * @param: pos is area to teleport to.
   * @return: None.
   */
    public void Teleport(Vector3 pos)
    {

    }

    /**
   * @pre: N/A.
   * @post: Not yet implemented. Once implemented should let player hover in air for a second
   * @param: ground is if player is on the ground, onOrOff should control if you are currently hovering, time should be how long the hover lasts.
   * @return: None.
   */
    public void Hover(bool ground, bool onOrOff, int time)
    {
        /*
        if (onOrOff)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            hoverTime = time;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            hoverTime = 0;
        }
        */
    }

    /**
   * @pre: N/A.
   * @post: Variables for checking if a button is held should be updated
   * @param: None.
   * @return: None.
   */
    public void HeldCheck()
    {
        if (rightLeftPrior == Input.GetAxisRaw("RightLeft") && rightLeftPrior != 0)
        {
            rightLeftHeld = rightLeftHeld + 1;
        }
        else
        {
            rightLeftHeld = 0;
        }

        if (forwardBackPrior == Input.GetAxisRaw("ForwardBack") && forwardBackPrior != 0)
        {
            forwardBackHeld = forwardBackHeld + 1;
        }
        else
        {
            forwardBackHeld = 0;
        }

        if (jumpPrior == Input.GetAxisRaw("Jump") && jumpPrior != 0)
        {
            jumpHeld = jumpHeld + 1;
        }
        else
        {
            jumpHeld = 0;
        }

        if (firePrior == Input.GetAxisRaw("Fire") && firePrior != 0)
        {
            fireHeld = fireHeld + 1;
        }
        else
        {
            fireHeld = 0;
        }

        if (altFirePrior == Input.GetAxisRaw("AltFire") && altFirePrior != 0)
        {
            altFireHeld = altFireHeld + 1;
        }
        else
        {
            altFireHeld = 0;
        }

        if (reloadPrior == Input.GetAxisRaw("Reload") && reloadPrior != 0)
        {
            reloadHeld = reloadHeld + 1;
        }
        else
        {
            reloadHeld = 0;
        }

        if (aimPrior == Input.GetAxisRaw("ADS") && aimPrior != 0)
        {
            aimHeld = aimHeld + 1;
        }
        else
        {
            aimHeld = 0;
        }

        if (selectWeaponBackPrior == Input.GetAxisRaw("SelectWeaponBack") && selectWeaponBackPrior != 0)
        {
            selectWeaponBackHeld = selectWeaponBackHeld + 1;
        }
        else
        {
            selectWeaponBackHeld = 0;
        }

        if (selectWeaponForwardPrior == Input.GetAxisRaw("SelectWeaponForward") && selectWeaponForwardPrior != 0)
        {
            selectWeaponForwardHeld = selectWeaponForwardHeld + 1;
        }
        else
        {
            selectWeaponForwardHeld = 0;
        }

        if (selectPrior == Input.GetAxisRaw("Select") && selectPrior != 0)
        {
            selectHeld = selectHeld + 1;
        }
        else
        {
            selectHeld = 0;
        }

        if (submitPrior == Input.GetAxisRaw("Submit") && submitPrior != 0)
        {
            submitHeld = submitHeld + 1;
        }
        else
        {
            submitHeld = 0;
        }

        if (interactPrior == Input.GetAxisRaw("Interact") && interactPrior != 0)
        {
            interactHeld = interactHeld + 1;
        }
        else
        {
            interactHeld = 0;
        }

        rightLeftPrior = Input.GetAxisRaw("RightLeft");
        forwardBackPrior = Input.GetAxisRaw("ForwardBack");
        jumpPrior = Input.GetAxisRaw("Jump");
        firePrior = Input.GetAxisRaw("Fire");
        altFirePrior = Input.GetAxisRaw("AltFire");
        aimPrior = Input.GetAxisRaw("ADS");
        reloadPrior = Input.GetAxisRaw("Reload");
        selectWeaponBackPrior = Input.GetAxisRaw("SelectWeaponBack");
        selectWeaponForwardPrior = Input.GetAxisRaw("SelectWeaponForward");
        selectPrior = Input.GetAxisRaw("Select");
        submitPrior = Input.GetAxisRaw("Submit");
        interactPrior = Input.GetAxisRaw("Interact");

    }

    /**
   * @pre: N/A.
   * @post: Not yet implemented. Once implemented should pickup item collided with
   * @param: other object hit.
   * @return: None.
   */
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "AmmoType")
        {
            collision.gameObject.transform.parent = tr;
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            inventory.AddToInventory(collision.GetComponent<AmmoType>());
            collision.enabled = false;
        }
        else if (collision.gameObject.tag == "Barrel")
        {
            collision.gameObject.transform.parent = tr;
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            inventory.AddToInventory(collision.GetComponent<Barrel>());
            collision.enabled = false;
        }
        else if (collision.gameObject.tag == "Caliber")
        {
            collision.gameObject.transform.parent = tr;
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            inventory.AddToInventory(collision.GetComponent<Caliber>());
            collision.enabled = false;
        }
        else if (collision.gameObject.tag == "CyclicModifier")
        {
            collision.gameObject.transform.parent = tr;
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            inventory.AddToInventory(collision.GetComponent<CyclicModifier>());
            collision.enabled = false;
        }
        else if (collision.gameObject.tag == "Magazine")
        {
            collision.gameObject.transform.parent = tr;
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            inventory.AddToInventory(collision.GetComponent<Magazine>());
            collision.enabled = false;
        }
        else if (collision.gameObject.tag == "Receiver")
        {
            collision.gameObject.transform.parent = tr;
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            inventory.AddToInventory(collision.GetComponent<Receiver>());
            collision.enabled = false;
        }
        else if (collision.gameObject.tag == "Sight")
        {
            collision.gameObject.transform.parent = tr;
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            inventory.AddToInventory(collision.GetComponent<Sight>());
            collision.enabled = false;
        }
        else if (collision.gameObject.tag == "Stock")
        {
            collision.gameObject.transform.parent = tr;
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            inventory.AddToInventory(collision.GetComponent<Stock>());
            collision.enabled = false;
        }
        else if (collision.gameObject.tag == "UnderBarrel")
        {
            collision.gameObject.transform.parent = tr;
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            inventory.AddToInventory(collision.GetComponent<UnderBarrel>());
            collision.enabled = false;
        }

    }

    /**
   * @pre: N/A.
   * @post: Change current default Receiver to the input
   * @param: derp is new default Weapon.
   * @return: None.
   */
   

    /**
   * @pre: N/A.
   * @post: Adds input to player health value as long as the player is not invulnerable, healthbar is updated afterwards.
   * @param: change is value to be added to health.
   * @return: None.
   */
    public override void ChangeHealth(float change)
    {
        if (iFrames <= 0)
        {
            if (health + change < 0)
            {
                health = 0;
                iFrames = 50;
            }
            else if (health + change >= maxHealth)
            {
                health = maxHealth;
            }
            else
            {
                health = health + change;
                iFrames = 50;
            }
        }

        playerHealth.transform.localScale = new Vector3(health / maxHealth, 1, 1);
        playerHealth.transform.localPosition = new Vector3(0 + (health - maxHealth) / 2, 0, 0);
    }

    /**
   * @pre: N/A.
   * @post: Adds input to player health value as long as the player is not invulnerable, health bar is updated afterwards.
   * @param: change is value to be added to health, saving frames is time the player is invulnerable after health is changed.
   * @return: None.
   */
    public virtual void ChangeHealth(float change, int savingFrames)
    {
        if (iFrames <= 0)
        {
            if (health + change < 0)
            {
                health = 0;
                iFrames = savingFrames;
            }
            else if (health + change >= maxHealth)
            {
                health = maxHealth;
                iFrames = savingFrames;
            }
            else
            {
                health = health + change;
                iFrames = savingFrames;
            }
        }

        playerHealth.transform.localScale = new Vector3(health / maxHealth, 1, 1);
        playerHealth.transform.localPosition = new Vector3(0 + (health - maxHealth) / 2, 0, 0);
    }

    /**
   * @pre: N/A.
   * @post: Subtracts timer for player's invulnerable status
   * @param: None.
   * @return: None.
   */
    public virtual void Invulnerability()
    {
        if (iFrames > 0)
        {
            iFrames--;
        }
    }

    /**
   * @pre: defaultWeapon or eqippedWeapon is in use.
   * @post: Identifies Equipped gun based on gun parts.
   * @param: None.
   * @return: None.
   */
    public void GunID()
    {
        if (defaultWeapon != null)
        {
              WeaponTextUI.text = equipedWeapon.ID;
        }
    }

    public void Interact()
    {
        menuEnabled = !menuEnabled;
        /*
        Quaternion derpRot = Quaternion.Euler(cam.transform.eulerAngles.x, transform.eulerAngles.y, 0);
        Vector3 derp = new  Vector3 (cam.transform.eulerAngles.x, transform.eulerAngles.y, 0);
        RaycastHit Rayinfo;
        LayerMask mask = LayerMask.GetMask("Interactable");
        Debug.Log(mask.value);
        Debug.DrawRay(transform.position, transform.forward,Color.green,20);
        if (Physics.Raycast(transform.position, transform.forward, out Rayinfo, 6, mask))
        {
            
            if (Rayinfo.transform.CompareTag("Interactable"))
            {
                Rayinfo.transform.GetComponent<Interaction>().Test();
            }
        }
        
    }
    */
    }
}


/*
 * public void lockOn()
    {
       
        if (Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit2D hit;

            if (lockOnTarget != null)
            {
                lockOnTarget = null;
            }


            else if (facingRight)
            {
                Debug.Log("Fire Right");
                for (float x = -0.523599f; x < 0.523599f; x = x + 0.0174533f)
                {
                    hit = Physics2D.Raycast(transform.position, angleVector((x), 5f), 20f, lockOnAble);
                    if (hit.collider != null)
                    {
                        lockOnTarget = hit.transform.gameObject;
                        break;
                    }
                }
                
            }

            else if (!facingRight)
            {
                Debug.Log("Fire Left");
                for (float x = 2.61799f; x < 3.66519f; x = x + 0.0174533f)
                {
                    hit = Physics2D.Raycast(transform.position, angleVector((x), 5f), 20f, lockOnAble);
                    if (hit.collider != null)
                    {
                        lockOnTarget = hit.transform.gameObject;
                        break;
                    }
                }
            }

          
            else
            {

            }

           
        }

        if (lockOnTarget != null)
        {
            lockOnSign.transform.position = lockOnPos;
            lockOnSign.GetComponent<SpriteRenderer>().enabled = true;
            LockOnHealthUI.text = "HostileHealth: " + lockOnTarget.GetComponent<HostileController>().health;
        }
        else
        {
            lockOnSign.GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }

    //For lockon-facing
     {
                lockOnPos = lockOnTarget.GetComponent<Transform>().position;
                if (rb.transform.position.x < lockOnPos.x && !facingRight)
                {
                    changeFacingDirection();
                }
                else if (rb.transform.position.x > lockOnPos.x && facingRight)
                {
                    changeFacingDirection();
                }
            }
 */
