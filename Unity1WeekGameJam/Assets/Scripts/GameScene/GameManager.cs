using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ShojiController shojiController   = null;
    [SerializeField] private Text            resultText        = null;
    [SerializeField] private float           changeSceneSecond = 0.0f;

    private StartCount  startCount  = null;
    private TimeAttack  timeAttack  = null;
    private bool        isStop      = false;
    private AudioSource audioSource = null;
    private float       bgmValume   = 0.0f;

    // リザルト用変数
    public static int   shojiRemaind { get; private set; } // 障子の残り枚数
    public static float timeRemaind  { get; private set; } // 終了時間

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        Debug.Log("GameManager:Initialize");
        // メンバ変数の初期化
        startCount      = GetComponent<StartCount>();
        timeAttack      = GetComponent<TimeAttack>();
        resultText.text = "";
        shojiRemaind    = 0;
        isStop          = true;
        audioSource     = GetComponent<AudioSource>();
        bgmValume       = audioSource.volume;

        // オブジェクトの初期化
        shojiController.Initialize();  
        startCount.Initialize();
        timeAttack.Initialize();

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
        audioSource.Play();
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
        timeRemaind = timeAttack.GetTime();
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
        //audio.Stop();
        // シーン遷移
        Debug.Log("TimeOver");
        this.StartCoroutine(FadeOutBGM());
        SceneChange.ChangeScene(this, SceneType.ResultScene, changeSceneSecond);
    }

    /// <summary>
    /// ゲームクリア
    /// </summary>
    private void GameClear()
    {
        Debug.Log("GameManager:クリアタイム = " + timeRemaind);
        resultText.text = "クリアタイム = " + timeRemaind;
        isStop = true;
        // シーン遷移
        this.StartCoroutine(FadeOutBGM());
        SceneChange.ChangeScene(this, SceneType.ResultScene, changeSceneSecond);
    }

    /// <summary>
    /// BGMのフェードアウトコルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeOutBGM()
    {
        Debug.Log("FadeOut");
        float fadeoutCount = 0.0f;
        while(fadeoutCount <= changeSceneSecond)
        {
            fadeoutCount += Time.deltaTime;
            audioSource.volume -= bgmValume / (changeSceneSecond / Time.deltaTime);
            yield return null;
        }
    }
}
