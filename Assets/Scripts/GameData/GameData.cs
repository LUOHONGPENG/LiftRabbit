using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StarLevel
{
    Star0,
    Star1,//2
    Star2,//3 Hungry
    Star3,//Spicy
    Star4,//Shit
    Star5
}


public partial class GameData
{
    //Data
    public StarLevel curStarLevel = StarLevel.Star0;
    public bool canEat = false;
    public int curLevel = 1;
    public int numLevel = 3;

    //Human
    public int keyIDHuman = -1;
    public List<int> listUnlockHuman = new List<int>();
    //Score
    private int money = 0;
    private int popularity = 0;

    public int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
            if (value < 0)
            {
                money = 0;
            }
            GameMgr.Instance.CheckStarLevelUp();
        }
    }

    public int Popularity
    {
        get
        {
            return popularity;
        }
        set
        {
            popularity = value;
            if (value < 0)
            {
                popularity = 0;
            }
            else if(value > 100)
            {
                popularity = 100;
            }
            GameMgr.Instance.CheckStarLevelUp();
        }
    }



    public GameData()
    {
        //Level
        curStarLevel = StarLevel.Star0;
        numLevel = 2;
        curLevel = 1;
        canEat = false;
        //Lift
        capacity = 4;
        //Human
        keyIDHuman = -1;
        listUnlockHuman.Clear();
        listUnlockHuman.Add(1001);

        listAllHuman.Clear();
        listHumanInLift.Clear();
        dicLevelHumanQueue.Clear();

        for (int i = 1;i <= numLevel; i++)
        {
            List<HumanData> queueHuman = new List<HumanData>();
            dicLevelHumanQueue.Add(i, queueHuman);
        }
    }

    #region Level
    public void AddLevel()
    {
        numLevel++;
        List<HumanData> ququeHuman = new List<HumanData>();
        dicLevelHumanQueue.Add(numLevel, ququeHuman);
    }

    #endregion

 
}


