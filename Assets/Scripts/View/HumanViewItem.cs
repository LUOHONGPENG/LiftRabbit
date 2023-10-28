using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor.U2D.Animation;

public class HumanViewItem : MonoBehaviour
{
    public SpriteRenderer spHuman;
    public Text codeTargetLevel;

    private HumanData humanData;

    public void Init(HumanData humanData)
    {
        this.humanData = humanData;

        codeTargetLevel.text = humanData.targetPos.ToString();
        spHuman.sprite = Resources.Load("Sprites/" + humanData.GetItem().spriteUrl, typeof(Sprite)) as Sprite;

        //Burn

        transform.position = new Vector2(10f, PublicTool.ConvertLevelToPosY(humanData.initialPos) + GameGlobal.posYHuman);
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

    public void RefreshPosLeave()
    {
        transform.DOMove(new Vector2(10f, PublicTool.ConvertLevelToPosY(humanData.targetPos) + GameGlobal.posYHuman), 1f);
    }
}
