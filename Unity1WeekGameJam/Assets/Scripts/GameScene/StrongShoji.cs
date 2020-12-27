using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongShoji : Shoji
{
    [SerializeField] private AudioClip damageSE = null;

    public override void Initialize()
    {
        base.Initialize();
        breakCount = 3;
    }

    protected override void BreakShoji()
    {
        AudioClip se = damageSE;
        breakCount--;
        if (breakCount <= 0)
        {
            image.sprite = breakSprite;
            SetShojiEnabled(false);
            isBreak = true;
            se = breakSE;
        }
        audioSource.PlayOneShot(se);
    }
}
