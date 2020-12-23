using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShojiSample : MonoBehaviour
{
    [SerializeField] private ShojiButton[] buttons = null;

    public bool isAllBreak { get; private set; }

    public void Initialize()
    {
        Debug.Log("Shoji:Initialize");
        for(var i = 0; i < buttons.Length;i++)
        {
            buttons[i].Initialize();
        }

        isAllBreak = false;
    }

    public void UpdateShoji()
    {
        bool isNotBreak = false;
        for (var i = 0; i < buttons.Length; i++)
        {
            if (!buttons[i].isBreak)
            {
                isNotBreak = true;
            }
        }

        if(!isNotBreak)
        {
            isAllBreak = true;
            Debug.Log("Shoji:すべて破られた");
        }
    }

    public int GetRemaindShoji()
    {
        int remaind = 0;
        for (var i = 0; i < buttons.Length; i++)
        {
            if (!buttons[i].isBreak)
            {
                remaind++;
            }
            buttons[i].Enabled();
        }

        return remaind;
    }
}
