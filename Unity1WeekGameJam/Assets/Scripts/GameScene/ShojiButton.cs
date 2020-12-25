using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShojiButton : MonoBehaviour
{
    public bool isBreak { get; private set; }

    private Button button = null;
    private Text text = null;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        Debug.Log("ShojiButton:initialize");
        button = GetComponent<Button>();
        button.onClick.AddListener(OnShojiClick);

        var child = transform.GetChild(0);
        if(child.gameObject.name == "Text")
        {
            text = child.GetComponent<Text>();
        }

        isBreak = false;
        button.enabled = true;
        text.text = "";
    }

    public void Enabled()
    {
        button.enabled = false;
    }

    /// <summary>
    /// ボタンがクリックされたときの処理
    /// </summary>
    private void OnShojiClick()
    {
        Debug.Log("ShojiButton:OnShojiClick");
        button.enabled = false;
        text.text = "破られた";
        isBreak = true;
    }

}
