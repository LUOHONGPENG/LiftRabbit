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
        liftViewMgr.MoveToLevel(level);
        yield return new WaitForSeconds(1f);
        gameData.curLevel = level;
        gameData.HumanEnter(level);
        RefreshHumanPosInLift();
        RefreshHumanPosInQueue(level);
        isMoving = false;
        yield break;
    }

    public IEnumerator IE_EatHuman()
    {
        isMoving = true;
        gameData.curLevel = -1;
        liftViewMgr.MoveToHeaven();
        yield return new WaitForSeconds(5f);
        isMoving = false;
        yield break;
    }
    #endregion

    #region Human

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
        if (humanData != null)
        {
            humanViewMgr.AddHumanView(humanData);

            int level = humanData.initialPos;
            RefreshHumanPosInQueue(level);
        }


    }

    public void RefreshHumanPosInQueue(int level)
    {
        Queue<HumanData> queue = new Queue<HumanData>(gameData.dicLevelHuman[level]);
        int count = queue.Count;
        for (int i = 0; i < count; i++)
        {
            HumanData tempData = queue.Dequeue();
            humanViewMgr.RefreshHumanPosInQueue(tempData.keyID, i);
        }
    }

    public void RefreshHumanPosInLift()
    {
        for(int i = 0; i < gameData.listHumanInLift.Count; i++)
        {
            HumanData tempData = gameData.listHumanInLift[i];
            humanViewMgr.RefreshHumanPosInLift(tempData.keyID, liftViewMgr.tfHuman);
        }
    }


    #endregion
}
