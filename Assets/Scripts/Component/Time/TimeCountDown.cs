using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TimeCountDown : MonoBehaviour
{
    [SerializeField] Image timeBar;

    [SerializeField] float countDownTime = 20;

    Tween tween;
    void Start()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        float countDown = 1;
        tween = DOTween.To(x => countDown = x, 1, 0, countDownTime).SetEase(Ease.Linear)
               .OnUpdate(() =>
               {
                   timeBar.fillAmount = countDown;
               })
               .OnComplete(OnFinishCountDown);
    }


    void OnFinishCountDown()
    {
        // call event spawn more block
        ResetTimeBar();


    }

    void ResetTimeBar()
    {
        timeBar.fillAmount = 1;
        UpdateTime();
    }
}
