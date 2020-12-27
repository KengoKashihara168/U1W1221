using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public bool isEnd { get; private set; }

    public void Initialize()
    {
        isEnd = false;
    }

    public void OnEndAnimation()
    {
        Debug.Log("アニメーション終了");
        isEnd = true;
    }
}
