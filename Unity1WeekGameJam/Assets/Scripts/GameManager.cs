using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float TimeLimit = 0.0f;
    [SerializeField] private ShojiController shojiController = null;
    [SerializeField] private Text resultText = null;
    [SerializeField] private Text timeText = null;

    private float time = 0.0f;
    private bool isStop = false;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        Debug.Log("GameManager:Initialize");
        shojiController.Initialize();
        resultText.text = "";
        timeText.text = (TimeLimit - time).ToString();
        isStop = true;
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStop)
        {
            var remaindShojis = shojiController.GetRemaindShoji();
            if (time <= TimeLimit)
            {
                CheckRemaindShojis(remaindShojis);
            }
            else
            {
                TimeOver(remaindShojis);
            }
        }
    }

    public void OnClickByStart()
    {
        if (!isStop) return;
        Initialize();
        shojiController.SetAllShojiEnabled(true);
        isStop = false;
    }

    /// <summary>
    /// 障子の残り枚数確認
    /// </summary>
    /// <param name="remaind">障子の残り枚数</param>
    private void CheckRemaindShojis(int remaind)
    {
        if (remaind == 0)
        {
            GameClear();
        }
        else
        {
            CountTime();
        }
    }

    /// <summary>
    /// 時間経過
    /// </summary>
    private void CountTime()
    {
        time += Time.deltaTime;
        timeText.text = (TimeLimit - time).ToString();
    }

    /// <summary>
    /// 時間切れ
    /// </summary>
    /// <param name="remaind">残った障子枚数</param>
    private void TimeOver(int remaind)
    {
        time += 1.0f * remaind;
        shojiController.SetAllShojiEnabled(false);
        isStop = true;
        // シーン遷移
        Debug.Log("GameManager:シーン遷移");
    }

    /// <summary>
    /// ゲームクリア
    /// </summary>
    private void GameClear()
    {
        Debug.Log("GameManager:クリアタイム = " + time);
        resultText.text = "クリアタイム = " + time;
        isStop = true;
    }
}
