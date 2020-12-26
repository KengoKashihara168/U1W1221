using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct RandomRange
{
    public int min;
    public int max;
}

public class ShojiController : MonoBehaviour
{
    [SerializeField] private ShojiFrame[]   frames        = null;
    [SerializeField] private RandomRange    strongRange  = new RandomRange();
    [SerializeField] private RandomRange    shutterRange = new RandomRange();

    private ShojiGenerater  shojiGenerater = null;
    //private List<Shoji>     shojis         = null;

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
        //shojis = new List<Shoji>();
        for(var i = 0;i < frames.Length;i++)
        {
            ShojiComposition comp = GetComposition(strongRange, shutterRange);
            frames[i].SetShojis(shojiGenerater.GenerateShoji(frames[i], comp));
        }
        
        
        //shojis.AddRange(shojiGenerater.GenerateShoji(frames, comp));

        //GetComposition(strongRange, shutterRange);
        //// 障子の初期化
        //foreach (var shoji in shojis)
        //{
        //    shoji.Initialize();
        //}
    }

    /// <summary>
    /// 全障子の有効を切り替える
    /// </summary>
    /// <param name="enabled">true:有効 / false:無効</param>
    public void SetAllShojisEnabled(bool enabled)
    {
        foreach (var frame in frames)
        {
            frame.SetFrameEnabled(enabled);
        }
    }

    /// <summary>
    /// 残り障子枚数の取得
    /// </summary>
    /// <returns></returns>
    public int GetRemaindShojis()
    {
        int remaind = 0;
        foreach (var frame in frames)
        {
            remaind += frame.GetRemaindShoji();
        }
        return remaind;
    }

    /// <summary>
    /// 障子の構成を取得
    /// </summary>
    /// <param name="strong">段ボールの範囲</param>
    /// <param name="shutter">開閉式の範囲</param>
    /// <returns></returns>
    private ShojiComposition GetComposition(RandomRange strong, RandomRange shutter)
    {
        ShojiComposition comp;
        int max      = shojiGenerater.ShojiHeight * shojiGenerater.ShojiWidth;  // 障子の最大枚数
        comp.strong  = Random.Range(strong.min, strong.max + 1);                // 段ボール
        comp.shutter = Random.Range(shutter.min, shutter.max + 1);              // 開閉式
        comp.normal  = max - comp.strong - comp.shutter;                        // 和紙

        Debug.Log("ShojiController:comp (normal,strong,shutter) = (" + comp.normal + "," + comp.strong + "," + comp.shutter + ")");

        return comp;
    }
}
