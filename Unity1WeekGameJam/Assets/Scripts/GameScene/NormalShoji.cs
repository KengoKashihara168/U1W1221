using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShoji : Shoji
{
    /// <summary>
    /// 初期化
    /// </summary>
    public override void Initialize()
    {
        base.Initialize();
        text.text = "和紙";
    }
}
