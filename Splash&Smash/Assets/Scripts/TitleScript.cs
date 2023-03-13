using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DentedPixel;

public class TitleScript : MonoBehaviour
{
    public Image titleDude;
    public TMP_Text txtSplash;
    public TMP_Text txtN;
    public TMP_Text txtSmash;
    public Image white;
    public Image BG;
    public GameObject menuCont;
    public AudioSource aSource;

    void Start()
    {
        DoTitleAnim();
    }

    void DoTitleAnim()
    {
        //var seq = LeanTween.sequence();
        //seq.append(.4f); 
        white.color = new Color(1, 1, 1, .9f);

        StartCoroutine(SmoothImageFadeToColor(6.0f, BG, 1, new Color(1, 1, 1, 1)));

        StartCoroutine(SmoothImageFadeIn(2.2f, gameObject.GetComponent<Image>(), .9f));

        aSource.Play();

        LeanTween.delayedCall(white.gameObject, 1.5f, () =>
        {
            //StartCoroutine(SmoothImageFadeIn(.01f, white, 0));
            StartCoroutine(SmoothImageFadeOut(2.9f, white, 0));

            LeanTween.color(white.gameObject, new Color(1,1,1,1), .9f).setOnComplete(
                    () => {

                        LeanTween.scale(titleDude.gameObject, new Vector3(3, 3f, 3f), 2.5f).setEase(LeanTweenType.easeOutBounce);
                        LeanTween.rotateAround(titleDude.gameObject, Vector3.forward, 732f, 2.1f).setEase(LeanTweenType.easeInOutQuad);

                        LeanTween.delayedCall(txtN.gameObject, 1.1f, () =>
                        {

                            LeanTween.scale(txtSplash.gameObject, new Vector3(1, 1, 1), 2).setEase(LeanTweenType.easeOutBounce);
                        LeanTween.delayedCall(txtN.gameObject, .5f, () =>
                        {
                            LeanTween.scale(txtN.gameObject, new Vector3(1, 1, 1), 2).setEase(LeanTweenType.easeOutBounce);
                            LeanTween.delayedCall(txtN.gameObject, .5f, () =>
                            {
                                LeanTween.move(titleDude.gameObject, new Vector3(310, 200, 0), 3).setEase(LeanTweenType.easeInOutQuad); // move dude left and down
                                LeanTween.scale(txtSmash.gameObject, new Vector3(1, 1, 1), 2).setEase(LeanTweenType.easeOutBounce);
                                LeanTween.delayedCall(txtN.gameObject, 1.5f, () =>
                                {

                                    LeanTween.scale(gameObject, new Vector3(1, 1, 1), 2f).setEase(LeanTweenType.easeOutBounce);
                                    LeanTween.scale(menuCont, new Vector3(1, 1, 1), 2f).setEase(LeanTweenType.easeOutBounce);
                                });
                            });
                        });
                        });
                    });


        });

    }

    public IEnumerator SmoothImageFadeToColor(float seconds, Image ObjectToFade, float delay , Color newColor)
    {
        yield return new WaitForSeconds(delay);
        Color startColor = ObjectToFade.color;
        float t = 0.0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            ObjectToFade.GetComponent<Image>().color = new Color(Mathf.Lerp(startColor.r, newColor.r, t), Mathf.Lerp(startColor.g, newColor.g, t), Mathf.Lerp(startColor.b, newColor.b, t), Mathf.Lerp(startColor.a, newColor.a, t));
            
            yield return null;
        }
    }
    public IEnumerator SmoothImageFadeIn(float seconds, Image ObjectToFade, float delay)
    {
        yield return new WaitForSeconds(delay);
        float t = 0.0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            ObjectToFade.GetComponent<Image>().color = new Color(ObjectToFade.GetComponent<Image>().color.r, ObjectToFade.GetComponent<Image>().color.g, ObjectToFade.GetComponent<Image>().color.b, t);
            yield return null;
        }
    }

    public IEnumerator SmoothImageFadeOut(float seconds, Image ObjectToFade, float delay)
    {
        yield return new WaitForSeconds(delay);
        float t = 0.0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            ObjectToFade.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1 - t);
            yield return null;
        }
    }

}
