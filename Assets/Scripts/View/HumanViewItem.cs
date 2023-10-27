using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanViewItem : MonoBehaviour
{
    public Text codeTargetLevel;

    private HumanData humanData;

    public void Init(HumanData humanData)
    {
        this.humanData = humanData;

        codeTargetLevel.text = humanData.targetPos.ToString();

        //Burn

        transform.position = new Vector2(3f, PublicTool.ConvertLevelToPosY(humanData.initialPos));
    }
}
