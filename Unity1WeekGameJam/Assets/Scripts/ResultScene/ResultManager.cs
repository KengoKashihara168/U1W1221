using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private float sceneTime = 0.0f;

    private float finishTime = 0.0f;
    private int remaindCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        finishTime = GameManager.finishTime;
        remaindCount = GameManager.shojiRemaind;

        Debug.Log("ResultManager:finishTime = " + finishTime + ",remaindCount = " + remaindCount);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
