using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HumanViewItem : MonoBehaviour
{
    public SpriteRenderer spHuman;
    public Text codeTargetLevel;


    public Image imgTarget;
    public Image imgFill;

    private HumanData humanData;

    public void Init(HumanData humanData)
    {
        this.humanData = humanData;

        codeTargetLevel.text = humanData.targetPos.ToString();
        spHuman.sprite = Resources.Load("Sprites/" + humanData.GetItem().spriteUrl, typeof(Sprite)) as Sprite;

        //Burn

        transform.position = new Vector2(8f, PublicTool.ConvertLevelToPosY(humanData.initialPos) + GameGlobal.posYHuman);
    }

    public void RefreshPosInQueue(int columnID)
    {
        transform.DOMove(new Vector2(PublicTool.ConvertColumnToPosX(columnID), PublicTool.ConvertLevelToPosY(humanData.initialPos) + GameGlobal.posYHuman),1f);
    }

    public void RefreshPosLift(Transform tf,int posID)
    {
        this.transform.parent = tf;
        this.transform.DOLocalMove(GameGlobal.listLiftPos[posID], 1f);
    }

    public void RefreshPosArrive()
    {
        transform.DOMove(new Vector2(10f, PublicTool.ConvertLevelToPosY(humanData.targetPos) + GameGlobal.posYHuman), 1f);
    }

    public void RefreshPosEscape()
    {
        transform.DOMove(new Vector2(11f, PublicTool.ConvertLevelToPosY(humanData.targetPos) + GameGlobal.posYHuman + 3f), 1f).SetEase(Ease.OutQuad);
    }

    public void RefreshWaitUI()
    {
        switch (humanData.humanState)
        {
            case HumanState.InQueue:
            case HumanState.Escape:
            case HumanState.InLift:
                imgFill.fillAmount = humanData.waitTime / humanData.waitTimeLimit;
                break;
            case HumanState.Arrive:
                imgTarget.gameObject.SetActive(false);
                break;
        }
    }
}
