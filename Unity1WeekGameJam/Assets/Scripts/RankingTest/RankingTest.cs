using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingTest : MonoBehaviour
{
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
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(100);
    }
}
