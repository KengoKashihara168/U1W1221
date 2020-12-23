﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoji : MonoBehaviour
{
    protected Button button;
    protected Text text;
    protected int breakCount;
    private bool isBreak;

    /// <summary>
    /// 初期化
    /// </summary>
    public virtual void Initialize()
    {
        InitializeButton();
        InitializeText();
        breakCount = 1;
        isBreak = false;
    }

    /// <summary>
    /// ボタンの初期化
    /// </summary>
    private void InitializeButton()
    {
        button = GetComponent<Button>();
        button.enabled = true;
        button.onClick.AddListener(OnClickShoji);
    }

    /// <summary>
    /// テキストの初期化
    /// </summary>
    private void InitializeText()
    {
        var child = transform.GetChild(0);
        if(child.gameObject.name == "Text")
        {
            text = child.GetComponent<Text>();
            text.text = "障子";
        }
        else
        {
            text = null;
            Debug.LogError("ボタンのテキストが見つかりませんでした");
        }
    }

    /// <summary>
    /// クリック時のイベントハンドラー
    /// </summary>
    private void OnClickShoji()
    {
        Debug.Log("Shoji:クリックされた");
        BreakShoji();
    }

    /// <summary>
    /// 障子が破れる処理
    /// </summary>
    protected virtual void BreakShoji()
    {
        breakCount--;
        if (breakCount <= 0)
        {
            text.text = "破れた";
            isBreak = true;
        }
    }

    /// <summary>
    /// 障子が破れているか
    /// </summary>
    /// <returns>障子破れフラグ</returns>
    public bool IsBreak()
    {
        return isBreak;
    }


}
