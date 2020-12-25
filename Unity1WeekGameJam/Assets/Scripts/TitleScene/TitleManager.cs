using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private float sceneTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        SceneChange.ChangeScene(this, SceneType.GameScene, sceneTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
