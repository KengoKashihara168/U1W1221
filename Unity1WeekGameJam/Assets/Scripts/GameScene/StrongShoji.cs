using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongShoji : Shoji
{
    public override void Initialize()
    {
        base.Initialize();
        breakCount = 3;
    }
}
