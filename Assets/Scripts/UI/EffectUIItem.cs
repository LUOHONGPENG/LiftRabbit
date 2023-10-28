using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EffectUIItem : MonoBehaviour
{
    public Transform tfEffect;
    public CanvasGroup canvasGroup;
    public Text codeTip;

    public void Init(string strTip)
    {
        codeTip.text = strTip;

        Sequence seq = DOTween.Sequence();
        seq.Append(tfEffect.DOScale(0, 0));
        //
        seq.Append(tfEffect.DOScale(1.5f, 0.5f));
        seq.Join(canvasGroup.DOFade(1f, 0.5f));
        seq.Join(tfEffect.DOLocalMoveY(60f, 0.5f));
        //0.5f
        seq.Append(tfEffect.DOScale(1f, 0.5f));
        //1F
        seq.Append(tfEffect.DOLocalMoveY(150f, 1.5f));
        seq.Insert(1.25F, canvasGroup.DOFade(0, 1.5f));

        Destroy(this.gameObject, 5f);

    }
}
