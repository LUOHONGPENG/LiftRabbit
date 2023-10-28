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
        }
        else if(gameData.curStarLevel == StarLevel.Star1 && gameData.Money >= 150)
        {
            gameData.curStarLevel++;
            gameData.AddLevel();
            levelViewMgr.RefreshLevel();
            uiMgr.AddLevelRefresh();
            gameData.listUnlockHuman.Add(1003);

        }
        else if (gameData.curStarLevel == StarLevel.Star2 && gameData.Money >= 500)
        {
            gameData.curStarLevel++;
            gameData.AddLevel();
            levelViewMgr.RefreshLevel();
            uiMgr.AddLevelRefresh();
            gameData.listUnlockHuman.Add(2001);

        }
        else if (gameData.curStarLevel == StarLevel.Star3 && gameData.Money >= 1000)
        {
            gameData.curStarLevel++;
            gameData.AddLevel();
            levelViewMgr.RefreshLevel();
            uiMgr.AddLevelRefresh();
            gameData.listUnlockHuman.Add(9999);

        }
        else if (gameData.curStarLevel == StarLevel.Star4 && gameData.Money >= 1600)
        {
            gameData.curStarLevel++;


        }
    }


}
