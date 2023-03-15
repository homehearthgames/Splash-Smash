using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishlineScript : MonoBehaviour
{
    public Transform BL;
    public Transform BR;
    public Transform TL;
    public Transform TR;
    public WaveBGScript wBGS1;
    public WaveBGScript wBGS2;
    private GameObject player;
    float finX;
    public bool finished = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Time.timeScale = .001f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.isFinished == false)
        {
            BL.transform.position = new Vector3(BL.transform.position.x - wBGS1.waveSpeed, BL.transform.position.y, BL.transform.position.z);
            BR.transform.position = new Vector3(BR.transform.position.x - wBGS1.waveSpeed, BR.transform.position.y, BR.transform.position.z);
            TL.transform.position = new Vector3(TL.transform.position.x - wBGS2.waveSpeed, TL.transform.position.y, TL.transform.position.z);
            TR.transform.position = new Vector3(TR.transform.position.x - wBGS2.waveSpeed, TR.transform.position.y, TR.transform.position.z);

            // check for player crossing
            finX = (TR.transform.position.x + BR.transform.position.x) / 2;
            if (player.transform.position.x > finX)
            {
                if (GameManager.gameManager.isFinished == false)
                    GetComponent<AudioSource>().Play();

                GameManager.gameManager.isFinished = true;
                StartCoroutine(FadeOutMusic(GameManager.aSource, 2.1f));
            }
        }

    }

    public IEnumerator FadeOutMusic(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;

        // ********** Finished ***********
        //SceneManager.LoadScene("HighScore");        

        GameStateManager.Instance.SwitchState(GameStateManager.Instance.WonState);

    }


}
