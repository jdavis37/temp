﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AmmoType : GunPart
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Fire(Vector3 newVelocity, Vector3 Pos, Quaternion angle, float spread, float newDamage);
}
