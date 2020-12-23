using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float TimeLimit = 0.0f;
    [SerializeField] private ShojiController shojiController = null;
    [SerializeField] private Text resultText = null;
    [SerializeField] private Text timeText = null;

    private float time = 0.0f;
    private bool isStop = false;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        Debug.Log("GameManager:Initialize");
        shojiController.Initialize();
        resultText.text = "";
        timeText.text = (TimeLimit - time).ToString();
        isStop = true;
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStop)
        {
            if (shojiController.GetRemaindShoji() > 0)
            {
                if (time <= TimeLimit)
                {
                    time += Time.deltaTime;
                    timeText.text = (TimeLimit - time).ToString();
                }
                else
                {
                    Debug.Log("GameManager:time = " + time);
                    Debug.Log("GameManager:残り障子枚数 = " + shojiController.GetRemaindShoji());
                    resultText.text = "残り障子枚数 = " + shojiController.GetRemaindShoji();
                    shojiController.SetAllShojiEnabled(false);
                    isStop = true;
                }
            }
            else
            {
                Debug.Log("GameManager:クリアタイム = " + time);
                resultText.text = "クリアタイム = " + time;
                isStop = true;
            }
        }
    }

    public void OnClickByStart()
    {
        Initialize();
        shojiController.SetAllShojiEnabled(true);
        isStop = false;
    }
}
