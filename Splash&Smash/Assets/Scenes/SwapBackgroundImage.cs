using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SwapBackgroundImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
[SerializeField] private Sprite swapSprite;
[SerializeField] private Image backgroundImage;
[SerializeField] private float fadeDuration = 0.5f;
private Coroutine fadeCoroutine;

SwitchState switchState;

private void Start()
{
    switchState = GetComponent<SwitchState>();
}

public void OnPointerEnter(PointerEventData eventData)
{
    if (fadeCoroutine != null)
    {
        StopCoroutine(fadeCoroutine);
    }

    fadeCoroutine = StartCoroutine(FadeImage(0f, 1f, fadeDuration));
    backgroundImage.sprite = swapSprite;
}

public void OnPointerExit(PointerEventData eventData)
{
    if (fadeCoroutine != null)
    {
        // StopCoroutine(fadeCoroutine);
    }

    // fadeCoroutine = StartCoroutine(FadeImage(1f, 0f, fadeDuration));
    // backgroundImage.sprite = null;
}

private IEnumerator FadeImage(float startAlpha, float endAlpha, float duration)
{
    float timeElapsed = 0f;
    Color color = backgroundImage.color;

    while (timeElapsed < duration)
    {
        timeElapsed += Time.deltaTime;
        float alpha = Mathf.Lerp(startAlpha, endAlpha, timeElapsed / duration);
        color.a = alpha;
        backgroundImage.color = color;

        yield return null;
    }

    color.a = endAlpha;
    backgroundImage.color = color;
}
}