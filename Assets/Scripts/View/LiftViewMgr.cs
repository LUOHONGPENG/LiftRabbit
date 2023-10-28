using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LiftViewMgr : MonoBehaviour
{
    public Transform tfLift;
    public Transform tfHuman;
    public Text codeCapacity;
    private GameData gameData;
    private bool isInit = false;
    public void Init()
    {
        gameData = PublicTool.GetGameData();
        tfLift.position = new Vector2(tfLift.position.x, PublicTool.ConvertLevelToPosY(gameData.curLevel) + GameGlobal.posYLift);

        isInit = true;
    }


    public void MoveToLevel(int Level)
    {
        tfLift.DOMoveY(PublicTool.ConvertLevelToPosY(Level) + GameGlobal.posYLift, 1f);
    }
    
    public void MoveToHeaven()
    {
        tfLift.DOMoveY(1f, 0.5f);
    }
    private void Update()
    {
        if (isInit)
        {
            codeCapacity.text = string.Format("Îü¹ÜÈÝÁ¿{0}/{1}", gameData.curLiftLoad, gameData.curCapacity);
        }
    }
}
