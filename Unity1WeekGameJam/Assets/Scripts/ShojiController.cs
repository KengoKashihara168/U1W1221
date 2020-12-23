using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShojiController : MonoBehaviour
{
    [SerializeField] private Transform row = null;

    private List<Shoji> shojis = null;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("ShojiController:Initialize");
        shojis = new List<Shoji>();
        SetShojis();
        foreach (var shoji in shojis)
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
            if (!shoji.IsBreak()) remaind++;
        }

        Debug.Log("ShojiController:remaind = " + remaind);
        return remaind;
    }

    /// <summary>
    /// 障子配列の設定
    /// </summary>
    private void SetShojis()
    {
        for(var i = 0;i < row.childCount;i++)
        {
            var column = row.GetChild(i);
            for(var j = 0;j < column.childCount;j++)
            {
                var shoji = column.GetChild(j);
                shojis.Add(shoji.GetComponent<Shoji>());
            }
        }
    }
}
