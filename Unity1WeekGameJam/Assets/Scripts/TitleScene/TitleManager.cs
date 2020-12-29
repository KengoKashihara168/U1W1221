using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private float sceneTime = 0.0f;
    [SerializeField] private AudioClip buttonSE = null;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStartButton()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(buttonSE);
        SceneChange.ChangeScene(this, SceneType.GameScene, sceneTime);
    }
}
