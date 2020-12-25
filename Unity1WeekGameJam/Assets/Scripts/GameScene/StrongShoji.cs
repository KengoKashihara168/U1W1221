﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongShoji : Shoji
{
    public override void Initialize()
    {
        base.Initialize();
        text.text = "ダンボール";
        breakCount = 3;
    }
}