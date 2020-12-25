using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCount : MonoBehaviour
{
    public bool startFlag { get; private set; }      // 開始フラグ

    [SerializeField] private float startTime = 0.0f; // 開始時間
    [SerializeField] private Text startText = null;  // 開始時間テキスト

    private bool isStart = false;                    // 開始フラグ

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("StartCount:Initialize");
        startFlag = false;
        isStart = false;
        SetText();
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void UpdateTime()
    {
        if (startFlag) return;
        if (isStart)   return;

        startTime -= Time.deltaTime;
        SetText();

        if (startTime <= 0.0f)
        {
            startFlag = true;
        }
    }

    /// <summary>
    /// ゲーム開始
    /// </summary>
    public void StartGame()
    {
        Debug.Log("StartCount:Game Start");
        isStart = true;
        startFlag = false;
    }

    /// <summary>
    /// テキストの設定
    /// </summary>
    private void SetText()
    {
        startText.text = startTime.ToString();
    }
}
