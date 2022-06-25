using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class Exit_Warning : MonoBehaviour
{
    public delegate void onTimerOut();
    public static event onTimerOut onTimerZero;
    public TextMeshProUGUI counter;
    public CanvasGroup panel;
    public int secondsLeft = 5;
    private float currentSecond = 1;
    bool active = false;
    bool startCounting = false;


    void Update()
    {
        if(startCounting)
        {
            if(secondsLeft > 0)
            {
                currentSecond -= Time.deltaTime;

                if(currentSecond <= 0)
                {
                    currentSecond = 1;
                    secondsLeft --;
                }
            }
            else
            {
                panel.DOFade(0,0.3f);
                onTimerZero?.Invoke();
                startCounting = false;
            }
            counter.text = secondsLeft.ToString();
        }
    }
    public void startCountine()
    {
        if(!active)
        {
            active = true;
            StartCoroutine(hideCoroutine());
        }
        
    }

    public IEnumerator hideCoroutine()
    {
        yield return panel.DOFade(1,0.3f).SetEase(Ease.InOutQuad).WaitForCompletion();
        startCounting = true;
    }

    void OnEnable()
    {
        Ship_Control.onReturned += cancelExplosion;
        Ship_Control.leftZone += startCountine;
    }

    public void cancelExplosion()
    {
        panel.DOFade(0,0.3f);
        secondsLeft = 5;
        StopCoroutine(hideCoroutine());
        startCounting = false;
        active = false;
    }
}

    
