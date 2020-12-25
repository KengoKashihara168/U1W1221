using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    TitleScene,
    GameScene,
    ResultScene,
}

public class SceneChange : MonoBehaviour
{
    /// <summary>
    /// シーン遷移
    /// </summary>
    /// <param name="mono">コルーチンを呼び出すためのMonoBehaviour</param>
    /// <param name="target">遷移するシーン</param>
    /// <param name="waitTime">遷移までの待機時間</param>
    public static void ChangeScene(MonoBehaviour mono, SceneType target,float waitTime)
    {
        string sceneName = target.ToString();

        mono.StartCoroutine(ChangeSceneCoroutine(sceneName, waitTime));
    }

    /// <summary>
    /// シーン遷移コルーチン
    /// </summary>
    /// <param name="name">遷移するシーン名</param>
    /// <param name="time">遷移までの待機時間</param>
    /// <returns></returns>
    private static IEnumerator ChangeSceneCoroutine(string name,float time)
    {
        Debug.Log(time + "秒後に" + name + "へ遷移するコルーチンを開始");

        // (time)秒待機
        yield return new WaitForSeconds(time);

        // シーン遷移
        SceneManager.LoadScene(name);
    }

}
