using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAttack : MonoBehaviour
{
    [SerializeField] private float timeLimit = 0.0f;
    [SerializeField] private Text timeText = null;

    private float time = 0.0f;
    private bool isStop = true;

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
        if (isStop) return;
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
        isStop = false;
        time = 0.0f;
        SetText();
    }

    /// <summary>
    /// 終了
    /// </summary>
    /// <returns>経過時間</returns>
    public float StopTime()
    {
        isStop = true;
        return time;
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
        if (time > timeLimit)
        {
            Debug.Log("TimeAttack:Time Over");
            isStop = true;
        }
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
