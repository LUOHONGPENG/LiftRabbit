using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HumanViewItem : MonoBehaviour
{
    public Text codeTargetLevel;

    private HumanData humanData;

    public void Init(HumanData humanData)
    {
        this.humanData = humanData;

        codeTargetLevel.text = humanData.targetPos.ToString();

        //Burn

        transform.position = new Vector2(10f, PublicTool.ConvertLevelToPosY(humanData.initialPos) + GameGlobal.posYHuman);
    }

    public void RefreshPosInQueue(int columnID)
    {
        transform.DOMove(new Vector2(PublicTool.ConvertColumnToPosX(columnID), PublicTool.ConvertLevelToPosY(humanData.initialPos) + GameGlobal.posYHuman),1f);
    }

    public void RefreshPosLift(Transform tf)
    {
        this.transform.parent = tf;
        this.transform.DOMove(tf.position + new Vector3(0,0.1f,0), 1f);
    }

    public void RefreshPosLeave()
    {
        transform.DOMove(new Vector2(10f, PublicTool.ConvertLevelToPosY(humanData.targetPos) + GameGlobal.posYHuman), 1f);
    }
}
