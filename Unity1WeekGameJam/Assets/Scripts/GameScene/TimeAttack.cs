using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAttack : MonoBehaviour
{
    [SerializeField] private float timeLimit = 0.0f;

    [SerializeField] private Text timeText = null;

    private float time = 0.0f;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        timeText.text = "";
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void UpdateTimeAttack()
    {
        // 時間経過
        CountTime();
        // テキストの更新
        SetText();
    }

    /// <summary>
    /// 開始
    /// </summary>
    public void StartTime()
    {
        Debug.Log("TimeAttack:game start");
        time = 0.0f;
        SetText();
    }

    /// <summary>
    /// 時間の取得
    /// </summary>
    /// <returns>時間</returns>
    public float GetTime()
    {
        float t = timeLimit - time;
        return t;
    }

    /// <summary>
    /// タイムアップか
    /// </summary>
    /// <returns>true:タイムアップ / false:継続中</returns>
    public bool IsTimeUp()
    {
        if (time < timeLimit) return false;
        return true;
    }

    /// <summary>
    /// 時間経過
    /// </summary>
    private void CountTime()
    {
        time += Time.deltaTime;
    }

    /// <summary>
    /// 制限時間テキストの更新
    /// </summary>
    private void SetText()
    {
        int t = Mathf.CeilToInt(timeLimit - time);
        timeText.text = t.ToString();
    }
}
