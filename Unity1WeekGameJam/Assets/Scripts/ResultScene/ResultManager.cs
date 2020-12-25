using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private float sceneTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        SceneChange.ChangeScene(this, SceneType.TitleScene, sceneTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
