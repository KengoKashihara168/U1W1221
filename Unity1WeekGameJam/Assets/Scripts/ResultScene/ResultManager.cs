using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private float sceneTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

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
