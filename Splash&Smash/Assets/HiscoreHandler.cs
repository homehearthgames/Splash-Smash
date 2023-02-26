using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HiscoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hiscoreText;   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Set hiscore to player prefs score
        // hiscoreText.text = PlayerPrefs.thisLevel.score???
    }
}
