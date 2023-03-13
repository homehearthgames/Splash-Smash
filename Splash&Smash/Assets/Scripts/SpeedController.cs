using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{
    [SerializeField] WaveBGScript waveBGScript;
    TextMeshProUGUI speedText;
    [SerializeField] Image speedImage;
    // Start is called before the first frame update
    void Start()
    {
        speedText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float minSpeed = 1000f;
        float maxSpeed = 5000f;
        float formattedSpeed = Mathf.RoundToInt(Mathf.Lerp(minSpeed, maxSpeed, Mathf.Clamp01(waveBGScript.waveSpeed / 0.5f)) / 1000f) * 1000f;
        speedText.text = formattedSpeed.ToString();
        // Calculate fill amount based on current speed
        float fillAmount = (formattedSpeed - minSpeed) / (maxSpeed - minSpeed);

        // Set fill amount of Image component
        speedImage.fillAmount = fillAmount;
    }
}
