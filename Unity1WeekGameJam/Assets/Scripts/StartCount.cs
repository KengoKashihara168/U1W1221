using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCount : MonoBehaviour
{
    public bool startFlag { get; private set; }      // 開始フラグ

    [SerializeField] private float startTime = 0.0f; // 開始時間

    private float timeCount = 0.0f;                  // 経過時間

    private bool isStart = false;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("StartCount:Initialize");
        timeCount = 0.0f;
        startFlag = false;
        isStart = false;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void UpdateTime()
    {
        if (startFlag) return;
        if (isStart)   return;
        Debug.Log("StartCount:time = " + timeCount);
        timeCount += Time.deltaTime;

        if(timeCount >= startTime)
        {
            Debug.Log("StartCount:start");
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
}
