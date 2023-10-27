using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LiftViewMgr : MonoBehaviour
{
    public Transform tfLift;
    public Transform tfHuman;
    private GameData gameData;
    public void Init()
    {
        gameData = PublicTool.GetGameData();
        tfLift.position = new Vector2(tfLift.position.x, PublicTool.ConvertLevelToPosY(gameData.curLevel));
    }


    public void MoveToLevel(int Level)
    {
        tfLift.DOMoveY(PublicTool.ConvertLevelToPosY(Level),1f);
    }
    
    public void MoveToHeaven()
    {
        tfLift.DOMoveY(50f, 1f);
    }

    public void BackToLevel(int Level)
    {
        tfLift.DOMoveY(PublicTool.ConvertLevelToPosY(Level), 1f);

    }
}
