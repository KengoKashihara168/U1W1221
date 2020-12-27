using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private float sceneTime = 0.0f;
    [SerializeField] private int timeBonus = 0;
    [SerializeField] private int shojiPenalty = 0;
    [SerializeField] private Text timeText = null;
    [SerializeField] private Text penaltyText = null;
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Button[] buttons = null;

    private float timeRemaind = 0.0f;
    private int shojiRemaind = 0;
    private Animator timeAnimator = null;
    private Animator penaltyAnimator = null;
    private AnimationController timeAnimation = null;
    private AnimationController penaltyAnimation = null;
    private int score = 0;
    private int scoreCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaind = GameManager.timeRemaind;
        shojiRemaind = GameManager.shojiRemaind;

        score = CalculateScore();
        scoreText.text = "0";

        timeAnimator = timeText.GetComponent<Animator>();
        penaltyAnimator = penaltyText.GetComponent<Animator>();

        timeAnimation = timeText.GetComponent<AnimationController>();
        penaltyAnimation = penaltyText.GetComponent<AnimationController>();
        timeAnimation.Initialize();
        penaltyAnimation.Initialize();

        penaltyAnimator.speed = 0.0f;

        Debug.Log("ResultManager:finishTime = " + timeRemaind + ",remaindCount = " + shojiRemaind);
        scoreCount = 0;

        foreach(var button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timeAnimation.isEnd)
        {
            penaltyAnimator.speed = 1.0f;
        }

        if(penaltyAnimation.isEnd)
        {
            if(scoreCount < score)
            {
                scoreCount += 100;
                scoreText.text = ScoreToText(scoreCount);
            }
            else
            {
                scoreText.text = ScoreToText(score);
                foreach (var button in buttons)
                {
                    button.gameObject.SetActive(true);
                }
            }
        }
    }

    /// <summary>
    /// タイトルシーン遷移ボタン用イベントハンドラー
    /// </summary>
    public void OnChangeTitleScene()
    {
        SceneChange.ChangeScene(this, SceneType.TitleScene, sceneTime);
    }

    /// <summary>
    /// ゲームシーン遷移ボタン用イベントハンドラー
    /// </summary>
    public void OnChangeGameScene()
    {
        SceneChange.ChangeScene(this, SceneType.GameScene, sceneTime);
    }

    /// <summary>
    /// スコアの計算
    /// </summary>
    private int CalculateScore()
    {
        int time = Mathf.CeilToInt(1000.0f + timeRemaind * timeBonus);
        int penalty = shojiRemaind * shojiPenalty;
        int score = time - penalty;

        timeText.text = string.Format("{0:#,0}", time);
        penaltyText.text = string.Format("-{0:#,0}", penalty);
        
        Debug.Log("ResultManager:score = " + score);
        return score;
    }

    private string ScoreToText(int score)
    {
        string text = "";
        text = string.Format("{0:#,0}", score);

        Debug.Log("text = " + text);

        return text;
    }
}
