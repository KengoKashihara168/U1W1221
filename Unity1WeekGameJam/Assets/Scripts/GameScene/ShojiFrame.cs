using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShojiFrame : MonoBehaviour
{
    private List<Shoji> shojis = null;

    /// <summary>
    /// 障子の設定
    /// </summary>
    /// <param name="shojis">障子リスト</param>
    public void SetShojis(List<Shoji> shojis)
    {
        this.shojis = shojis;
        foreach(var shoji in this.shojis)
        {
            shoji.Initialize();
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
            if (!shoji.IsBreak())
            {
                remaind++;
            }
        }
        return remaind;
    }

    /// <summary>
    /// 全障子の有効を切り替える
    /// </summary>
    /// <param name="enabled">true:有効 / false:無効</param>
    public void SetFrameEnabled(bool enabled)
    {
        foreach (var shoji in shojis)
        {
            shoji.SetShojiEnabled(enabled);
        }
    }
}
