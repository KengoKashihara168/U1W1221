using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ShojiComposition
{
    public int normal;
    public int strong;
    public int shutter;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="normal">和紙</param>
    /// <param name="strong">段ボール</param>
    /// <param name="shutter">開閉式</param>
    public ShojiComposition(int normal, int strong, int shutter)
    {
        this.normal = normal;
        this.strong = strong;
        this.shutter = shutter;
    }
}

public class ShojiGenerater : MonoBehaviour
{
    private readonly int ShojiHeight = 5; // 障子の高さ
    private readonly int ShojiWidth = 4; // 障子の幅
    private readonly float StartPosX = -135.0f; // 開始するX座標
    private readonly float StartPosY = -180.0f; // 開始するY座標

    [SerializeField] private NormalShoji  normalPrefab  = null;
    [SerializeField] private StrongShoji  strongPrefab  = null;
    [SerializeField] private ShutterShoji shutterPrefab = null;

    private List<Vector3> positionList = null;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        positionList = new List<Vector3>();
        SetPositionList();
    }

    /// <summary>
    /// 障子の生成
    /// </summary>
    /// <param name="rect">障子の親</param>
    /// <param name="comp">障子の構成</param>
    /// <returns>障子リスト</returns>
    public List<Shoji> GenerateShoji(RectTransform rect,ShojiComposition comp)
    {
        var shojis = new List<Shoji>();
        shojis.AddRange(InstantiateShoji(normalPrefab, rect, comp.normal));
        shojis.AddRange(InstantiateShoji(strongPrefab, rect, comp.strong));
        shojis.AddRange(InstantiateShoji(shutterPrefab, rect, comp.shutter));
        SetShojisPosition(shojis);

        return shojis;
    }

    /// <summary>
    /// 座標リストの設定
    /// </summary>
    private void SetPositionList()
    {
        for (var i = 0; i < ShojiHeight; i++)
        {
            for (var j = 0; j < ShojiWidth; j++)
            {
                float x = StartPosX + (90.0f * j);
                float y = StartPosY + (90.0f * i);
                positionList.Add(new Vector3(x, y, 0.0f));
            }
        }
    }

    /// <summary>
    /// 障子の生成
    /// </summary>
    /// <param name="shojiPrefab">生成する障子のプレハブ</param>
    /// <param name="rect">障子の親</param>
    /// <param name="comp">生成数</param>
    private List<Shoji> InstantiateShoji(Shoji shojiPrefab,RectTransform rect,int comp)
    {
        var list = new List<Shoji>();
        for (var i = 0;i < comp;i++)
        {
            var obj = Instantiate(shojiPrefab, rect);
            list.Add(obj.GetComponent<Shoji>());
        }

        return list;
    }

    /// <summary>
    /// 障子の座標を設定
    /// </summary>
    /// <param name="shojis">障子リスト</param>
    private void SetShojisPosition(List<Shoji> shojis)
    {
        int length = shojis.Count;
        var posList = positionList;
        for(var i = 0;i < shojis.Count;i++)
        {
            int rand = Random.Range(0, length);
            // 座標の設定
            var rect = shojis[i].GetComponent<RectTransform>();
            rect.localPosition = posList[rand];
            // 配列の要素を削除
            posList.RemoveAt(rand);
            length--;
        }
    }
}
