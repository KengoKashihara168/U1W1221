using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ShojiController shojiController = null;
    [SerializeField] private Text resultText = null;

    private StartCount startCount = null;
    private TimeAttack timeAttack = null;
    private static int shojiRemaind = 0;
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
        startCount = GetComponent<StartCount>();
        startCount.Initialize();
        timeAttack = GetComponent<TimeAttack>();
        timeAttack.Initialize();
        shojiRemaind = 0;
        isStop = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 開始前のカウントダウンを更新
        startCount.UpdateTime();
        if (startCount.startFlag) StartGame();

        // 障子の残り枚数を取得
        CheckRemaindShoji();

        // 経過時間の更新
        CheckTime();
    }

    /// <summary>
    /// ゲーム開始
    /// </summary>
    private void StartGame()
    {
        Debug.Log("GameManager:start game");
        isStop = false;
        startCount.StartGame();
        timeAttack.StartTime();
        shojiController.StartGame();
    }

    /// <summary>
    /// 障子の残り枚数をチェック
    /// </summary>
    private void CheckRemaindShoji()
    {
        if (isStop) return;
        shojiController.CheckChangeShoji();
        shojiRemaind = shojiController.GetRemaindShojis();
        if (shojiRemaind == 0) GameClear();
    }

    /// <summary>
    /// 時間のチェック
    /// </summary>
    private void CheckTime()
    {
        if (isStop) return;
        timeAttack.UpdateTimeAttack();
        if (timeAttack.IsTimeUp()) TimeOver();
    }

    /// <summary>
    /// 時間切れ
    /// </summary>
    /// <param name="remaind">残った障子枚数</param>
    private void TimeOver()
    {
        resultText.text = "のこり = " + shojiRemaind;
        shojiController.EndGame();
        isStop = true;
        // シーン遷移
        SceneChange.ChangeScene(this, SceneType.ResultScene, 2.0f);
    }

    /// <summary>
    /// ゲームクリア
    /// </summary>
    private void GameClear()
    {
        float time = timeAttack.StopTime();
        Debug.Log("GameManager:クリアタイム = " + time);
        resultText.text = "クリアタイム = " + time;
        isStop = true;
        // シーン遷移
        SceneChange.ChangeScene(this, SceneType.ResultScene, 2.0f);
    }
}
