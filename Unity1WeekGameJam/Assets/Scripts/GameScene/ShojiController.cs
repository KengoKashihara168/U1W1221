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
    [SerializeField] private float waitTime = 0.0f;

    private ShojiGenerater  shojiGenerater = null;
    private float waitCount = 0.0f;
    private int activeFrame = 0;

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

        foreach(var frame in frames)
        {
            ShojiComposition comp = GetComposition(strongRange, shutterRange);
            frame.SetShojis(shojiGenerater.GenerateShoji(frame, comp));
        }

        waitCount = 0.0f;

        foreach (var frame in frames)
        {
            frame.gameObject.SetActive(false);
        }
        activeFrame = 0;
    }

    /// <summary>
    /// ゲーム開始
    /// </summary>
    public void StartGame()
    {
        frames[0].gameObject.SetActive(true);
        frames[0].SetFrameEnabled(true);
    }

    /// <summary>
    /// ゲーム終了
    /// </summary>
    public void EndGame()
    {
        foreach (var frame in frames)
        {
            frame.SetFrameEnabled(false);
        }
    }

    /// <summary>
    /// 障子が切替か確認
    /// </summary>
    public void CheckChangeShoji()
    {
        if (activeFrame >= frames.Length - 1) return;
        if (frames[activeFrame].GetRemaindShoji() != 0) return;

        if(waitCount >= waitTime)
        {
            ChangeShoji();
            waitCount = 0.0f;
        }
        else
        {
            waitCount += Time.deltaTime;
        }

    }

    /// <summary>
    /// 残り障子枚数の取得
    /// </summary>
    /// <returns></returns>
    public int GetRemaindShojis()
    {
        int total = 0;
        for(var i = 0;i < frames.Length;i++)
        {
            int remaind = frames[i].GetRemaindShoji();
            total += remaind;
        }
        return total;
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

    /// <summary>
    /// 障子の切り替え
    /// </summary>
    private void ChangeShoji()
    {
        frames[activeFrame].gameObject.SetActive(false);
        activeFrame++;
        frames[activeFrame].gameObject.SetActive(true);
        frames[activeFrame].SetFrameEnabled(true);
    }
}
