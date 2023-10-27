using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr
{
    #region Select Level
    [HideInInspector]
    public bool isMoving = false;

    public void SelectLevelEvent(object arg0)
    {
        int tarLevel = (int)arg0;

        if (gameData.curLevel == tarLevel)
        {
            //Oh I am here
        }
        else
        {
            if (tarLevel >= 1)
            {
                StartCoroutine(IE_MoveToTargetLevel(tarLevel));
            }
            else
            {
                StartCoroutine(IE_EatHuman());
            }
        }
    }

    public IEnumerator IE_MoveToTargetLevel(int level)
    {
        isMoving = true;
        mapMgr.MoveToLevel(level);
        yield return new WaitForSeconds(1f);
        gameData.curLevel = level;
        isMoving = false;
        yield break;
    }

    public IEnumerator IE_EatHuman()
    {
        isMoving = true;
        gameData.curLevel = -1;
        mapMgr.MoveToHeaven();
        yield return new WaitForSeconds(5f);
        isMoving = false;
        yield break;
    }
    #endregion

    #region Generate Human

    public float timerGenerateHuman = 0;
    public float timeGenerateHuman = 5f;

    private void Update()
    {
        TimeGo(Time.deltaTime);
    }

    public void TimeGo(float time)
    {
        timerGenerateHuman -= time;
        if (timerGenerateHuman < 0)
        {
            timerGenerateHuman = timeGenerateHuman;
            GenerateHuman();
        }
    }


    public void GenerateHuman()
    {
        HumanData humanData = gameData.GenerateCharacter();
        mapMgr.AddHuman(humanData);
    }




    #endregion
}
