using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoji : MonoBehaviour
{
    [SerializeField] protected Sprite breakSprite = null;
    protected Button button;
    protected int breakCount;
    private Image image;
    private bool isBreak;

    /// <summary>
    /// 初期化
    /// </summary>
    public virtual void Initialize()
    {
        InitializeButton();
        breakCount = 1;
        image = GetComponent<Image>();
        isBreak = false;
    }

    /// <summary>
    /// ボタンの初期化
    /// </summary>
    private void InitializeButton()
    {
        button = GetComponent<Button>();
        button.enabled = false;
        button.onClick.AddListener(OnClickShoji);
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
            image.sprite = breakSprite;
            SetShojiEnabled(false);
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

    /// <summary>
    /// 障子の有効設定
    /// </summary>
    /// <param name="enabled">true:有効 / false:無効</param>
    public virtual void SetShojiEnabled(bool enabled)
    {
        button.enabled = enabled;
    }

}
