using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterShoji : Shoji
{
    private Animator animator;

    /// <summary>
    /// 初期化
    /// </summary>
    public override void Initialize()
    {
        base.Initialize();
        animator = GetComponent<Animator>();
        animator.speed = 0.0f;
    }

    /// <summary>
    /// 障子の有効設定
    /// </summary>
    /// <param name="enabled">true:有効 / false:無効</param>
    public override void SetShojiEnabled(bool enabled)
    {
        Debug.Log("ボタンの有効設定");
        base.SetShojiEnabled(enabled);
        if (enabled)
        {
            animator.speed = 1.0f;
        }
        else
        {
            Debug.Log("停止");
            animator.speed = 0.0f;
        }
    }

    public void OnShut()
    {
        button.enabled = false;
    }

    public void OnOpen()
    {
        button.enabled = true;
    }

    protected override void BreakShoji()
    {
        base.BreakShoji();
        animator.speed = 0.0f;
    }
}
