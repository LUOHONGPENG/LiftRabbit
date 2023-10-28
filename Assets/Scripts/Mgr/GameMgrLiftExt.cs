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
        gameData.HumanArrive(level);
        gameData.HumanEnter(level);
        RefreshHumanPosLeave();
        RefreshHumanPosInLift();
        RefreshHumanPosInQueue(level);
        isMoving = false;
        yield break;
    }

    public IEnumerator IE_EatHuman()
    {
        if (gameData.curLiftLoad <= 0)
        {
            PublicTool.PlaySound(SoundType.NoConsumer);
        }
        else
        {
            isMoving = true;
            gameData.curLevel = -1;
            liftViewMgr.MoveToHeaven();
            yield return new WaitForSeconds(0.5f);
            gameData.HumanEat();
            yield return new WaitForSeconds(3f);
            ClearHumanLift();
            gameData.listHumanInLift.Clear();
            yield return new WaitForEndOfFrame();
            isMoving = false;
            yield break;
        }



    }
    #endregion

    #region Human
    [HideInInspector]
    public float timerGenerateHuman = 5f;
    [HideInInspector]
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
        HumanData humanData = gameData.GenerateHuman();
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
            humanViewMgr.RefreshHumanPosInLift(tempData.keyID, liftViewMgr.tfHuman,i);
        }
    }

    public void RefreshHumanPosLeave()
    {
        for (int i = 0; i < gameData.listHumanLeave.Count; i++)
        {
            HumanData tempData = gameData.listHumanLeave[i];
            StartCoroutine(humanViewMgr.IE_RefreshHumanPosLeave(tempData.keyID));
        }
        gameData.listHumanLeave.Clear();
    }

    public void ClearHumanLift()
    {
        for (int i = 0; i < gameData.listHumanInLift.Count; i++)
        {
            HumanData tempData = gameData.listHumanInLift[i];
            humanViewMgr.RemoveHumanView(tempData.keyID);
        }
    }

    #endregion
}
