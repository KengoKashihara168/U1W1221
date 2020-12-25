using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShojiController : MonoBehaviour
{
    [SerializeField] private RectTransform frame = null;

    private ShojiGenerater shojiGenerater = null;
    private List<Shoji> shojis = null;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("ShojiController:Initialize");
        // 障子ジェネレータの初期化
        shojiGenerater = GetComponent<ShojiGenerater>();
        shojiGenerater.Initialize();
        // 障子の生成
        shojis = new List<Shoji>();
        ShojiComposition comp = new ShojiComposition(12,4,4);
        shojis = shojiGenerater.GenerateShoji(frame, comp);
        // 障子の初期化
        foreach (var shoji in shojis)
        {
            shoji.Initialize();
        }
    }

    /// <summary>
    /// 全障子の有効を切り替える
    /// </summary>
    /// <param name="enabled">true:有効 / false:無効</param>
    public void SetAllShojiEnabled(bool enabled)
    {
        foreach (var shoji in shojis)
        {
            shoji.SetShojiEnabled(enabled);
        }
    }

    /// <summary>
    /// 残り障子枚数の取得
    /// </summary>
    /// <returns></returns>
    public int GetRemaindShoji()
    {
        int remaind = 0;
        foreach (var shoji in shojis)
        {
            if (!shoji.IsBreak()) remaind++;
        }

        Debug.Log("ShojiController:remaind = " + remaind);
        return remaind;
    }
}
