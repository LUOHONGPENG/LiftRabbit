using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameData
{
    //Data
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
        }
    }



    public GameData()
    {
        //Level
        numLevel = 3;
        curLevel = 1;
        //Lift
        capacity = 4;
        //Human
        keyIDHuman = -1;
        listUnlockHuman.Clear();
        listUnlockHuman.Add(1001);
        listUnlockHuman.Add(1002);

        listAllHuman.Clear();
        listHumanInLift.Clear();
        dicLevelHumanQueue.Clear();

        for (int i = 1;i <= numLevel; i++)
        {
            Queue<HumanData> queueHuman = new Queue<HumanData>();
            dicLevelHumanQueue.Add(i, queueHuman);
        }
    }

    #region Level
    public void AddLevel()
    {
        numLevel++;
        Queue<HumanData> ququeHuman = new Queue<HumanData>();
        dicLevelHumanQueue.Add(numLevel, ququeHuman);
        //Refresh View
    }

    #endregion

 
}


