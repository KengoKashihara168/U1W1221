using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetTest : MonoBehaviour
{
    private readonly string gameID = "u1w-shyojikyousou";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        naichilab.UnityRoomTweet.Tweet(gameID, "ツイートサンプルです。", "unityroom", "unity1week","shoji");
    }
}
