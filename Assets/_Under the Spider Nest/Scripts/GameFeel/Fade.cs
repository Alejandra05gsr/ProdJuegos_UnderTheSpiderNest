using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Fade : MonoBehaviour
{
    public Image image;
    public float tweenTime;
    public UnityEvent onEndFadeEvent;
    public bool fadeOutOnStart;
    //public TextMeshProUGUI levelTxt;

    void Start()
    {
        if (fadeOutOnStart)
        {
            Fading(false);
        }
    }

    public void Fading(bool fadeIn)
    {
        float targetValue = fadeIn ? 1f : 0f;

        if (image.type == Image.Type.Filled)
        {
            image.DOFillAmount(targetValue, tweenTime).OnComplete(onEndFadeEvent.Invoke).SetDelay(2);
            return;
        }

        image.DOFade(targetValue, tweenTime).OnComplete(onEndFadeEvent.Invoke);
    }
}
