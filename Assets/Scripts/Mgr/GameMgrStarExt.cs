using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr
{
    public void CheckStarLevelUp()
    {
        if(gameData.curStarLevel == StarLevel.Star0 && gameData.Popularity > 1)
        {
            gameData.curStarLevel++;
            gameData.AddLevel();
            levelViewMgr.RefreshLevel();
            uiMgr.AddLevelRefresh();
            gameData.listUnlockHuman.Add(1002);
            gameData.canEat = true;
            EventCenter.Instance.EventTrigger("LevelUpPage", null);
        }
        else if(gameData.curStarLevel == StarLevel.Star1 && gameData.Money >= GameGlobal.listLevelUp[1])
        {
            gameData.curStarLevel++;
            gameData.AddLevel();
            levelViewMgr.RefreshLevel();
            uiMgr.AddLevelRefresh();
            gameData.listUnlockHuman.Add(1003);
            gameData.canRun = true;
            EventCenter.Instance.EventTrigger("LevelUpPage", null);
        }
        else if (gameData.curStarLevel == StarLevel.Star2 && gameData.Money >= GameGlobal.listLevelUp[2])
        {
            gameData.curStarLevel++;
            gameData.AddLevel();
            levelViewMgr.RefreshLevel();
            uiMgr.AddLevelRefresh();
            gameData.listUnlockHuman.Add(2001);
            EventCenter.Instance.EventTrigger("LevelUpPage", null);

        }
        else if (gameData.curStarLevel == StarLevel.Star3 && gameData.Money >= GameGlobal.listLevelUp[3])
        {
            gameData.curStarLevel++;
            gameData.AddLevel();
            levelViewMgr.RefreshLevel();
            uiMgr.AddLevelRefresh();
            gameData.listUnlockHuman.Add(9999);
            EventCenter.Instance.EventTrigger("LevelUpPage", null);
        }
        else if (gameData.curStarLevel == StarLevel.Star4 && gameData.Money >= GameGlobal.listLevelUp[4])
        {
            gameData.curStarLevel++;

            EventCenter.Instance.EventTrigger("EndEvent", EndType.GoodEnd);

        }
    }


}
