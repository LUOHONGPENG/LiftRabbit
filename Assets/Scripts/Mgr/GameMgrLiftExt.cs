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
        float moveTime = PublicTool.CalculateLiftMoveTime(gameData.curLevel, level);
        liftViewMgr.MoveToLevel(level, moveTime);
        yield return new WaitForSeconds(moveTime);
        gameData.curLevel = level;
        gameData.HumanArrive(level);
        gameData.HumanEnter(level);
        RefreshHumanPosArrive();
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
        if (!isPageOn)
        {
            TimeGo(Time.deltaTime);
        }
    }

    public void TimeGo(float time)
    {
        //Generate Human
        timerGenerateHuman -= time * gameData.curSpeedGenerateHuman;
        if (timerGenerateHuman < 0)
        {
            timerGenerateHuman = timeGenerateHuman;
            GenerateHuman();
        }

        //Check All Human
        for(int i = gameData.listAllHuman.Count-1; i >= 0; i--)
        {
            HumanData humanData = gameData.listAllHuman[i];
            switch (humanData.humanState)
            {
                case HumanState.InQueue:
                    humanData.TimeGoWait(time);
                    RefreshHumanWaitUI(humanData);
                    if (humanData.CheckWhetherWaitOut())
                    {
                        RemoveHumanFromQueue(humanData);
                    }
                    break;
                case HumanState.InLift:
                    RefreshHumanWaitUI(humanData);
                    break;
                case HumanState.Arrive:
                    RefreshHumanWaitUI(humanData);
                    gameData.listAllHuman.Remove(humanData);
                    break;
                case HumanState.Eaten:
                    gameData.listAllHuman.Remove(humanData);
                    break;
                case HumanState.Escape:
                    gameData.listAllHuman.Remove(humanData);
                    break;
            }
        }

    }

    private void RemoveHumanFromQueue(HumanData humanData)
    {
        humanData.humanState = HumanState.Escape;
        List<HumanData> queue = gameData.dicLevelHumanQueue[humanData.initialPos];
        queue.Remove(humanData);
        gameData.listHumanEscape.Add(humanData);
        RefreshHumanPosInQueue(humanData.initialPos);
        RefreshHumanPosEscape(humanData);
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
        List<HumanData> queue = new List<HumanData>(gameData.dicLevelHumanQueue[level]);
        int count = queue.Count;
        for (int i = 0; i < count; i++)
        {
            HumanData tempData = queue[0];
            queue.RemoveAt(0);
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

    public void RefreshHumanPosArrive()
    {
        for (int i = 0; i < gameData.listHumanArrive.Count; i++)
        {
            HumanData tempData = gameData.listHumanArrive[i];
            StartCoroutine(humanViewMgr.IE_RefreshHumanPosArrive(tempData.keyID));
        }
        gameData.listHumanArrive.Clear();
    }

    public void RefreshHumanPosEscape(HumanData humanData)
    {
        StartCoroutine(humanViewMgr.IE_RefreshHumanPosEscape(humanData.keyID));
        gameData.listHumanEscape.Remove(humanData);
    }

    private void RefreshHumanWaitUI(HumanData humanData)
    {
        humanViewMgr.RefreshWaitTime(humanData.keyID);

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

    public bool isPageOn
    {
        get
        {
            bool temp = false;
            if (isInit)
            {
                if (uiMgr.skillNodeUIMgr.objPopup.activeSelf)
                {
                    temp = true;
                }

                if (uiMgr.levelUpMgr.objPopup.activeSelf)
                {
                    temp = true;
                }
            }
            return temp;
        }
    }
}
