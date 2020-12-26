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
        isStop = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 開始前のカウントダウンを更新
        startCount.UpdateTime();
        if (startCount.startFlag) StartGame();

        // 障子の残り枚数を取得
        var remaindShojis = shojiController.GetRemaindShoji();
        if (remaindShojis == 0) GameClear();

        // 経過時間の更新
        timeAttack.UpdateTimeAttack();
        if (timeAttack.IsTimeUp()) TimeOver(remaindShojis);
    }

    public void OnClickByStart()
    {
        if (!isStop) return;
        Initialize();
        shojiController.SetAllShojiEnabled(true);
        isStop = false;
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
        shojiController.SetAllShojiEnabled(true);
    }

    /// <summary>
    /// 時間切れ
    /// </summary>
    /// <param name="remaind">残った障子枚数</param>
    private void TimeOver(int remaind)
    {
        resultText.text = "のこり = " + remaind;
        shojiController.SetAllShojiEnabled(false);
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
