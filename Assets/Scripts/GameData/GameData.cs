using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    //Data
    public int curLevel = 1;
    public int numLevel = 3;
    //Lift
    public int capacity = 4;
    public int curLiftLoad
    {
        get
        {
            if (listHumanInLift != null)
            {
                return listHumanInLift.Count;
            }
            else
            {
                return 0;
            }
        }
    }
    //Human
    public int keyIDHuman = -1;
    public List<int> listUnlockHuman = new List<int>();
    //Score
    public int money = 0;
    public int popularity = 0;

    //List
    public List<HumanData> listAllHuman = new List<HumanData>();
    public List<HumanData> listHumanInLift = new List<HumanData>();
    public List<HumanData> listHumanLeave = new List<HumanData>();
    public Dictionary<int, Queue<HumanData>> dicLevelHuman = new Dictionary<int, Queue<HumanData>>();

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
        dicLevelHuman.Clear();

        for (int i = 1;i <= numLevel; i++)
        {
            Queue<HumanData> queueHuman = new Queue<HumanData>();
            dicLevelHuman.Add(i, queueHuman);
        }
    }

    #region Level
    public void AddLevel()
    {
        numLevel++;
        Queue<HumanData> ququeHuman = new Queue<HumanData>();
        dicLevelHuman.Add(numLevel, ququeHuman);
        //Refresh View
    }

    #endregion

    public HumanData GenerateHuman()
    {
        //Random initial Level
        int ran = Random.Range(1, numLevel + 1);
        int typeID = PublicTool.DrawNum(1, listUnlockHuman, null)[0];
        if (dicLevelHuman.ContainsKey(ran))
        {
            if (dicLevelHuman[ran].Count <= 4)
            {
                keyIDHuman++;
                HumanData newHuman = new HumanData(keyIDHuman, typeID);
                
                newHuman.humanState = HumanState.InQueue;
                newHuman.initialPos = ran;
                listAllHuman.Add(newHuman);
                dicLevelHuman[ran].Enqueue(newHuman);

                //Random target level
                List<int> listLevel = new List<int>();
                for (int i = 1; i <= numLevel; i++)
                {
                    listLevel.Add(i);
                }
                List<int> listDelete = new List<int> { ran };
                newHuman.targetPos = PublicTool.DrawNum(1, listLevel, listDelete)[0];

                return newHuman;
            }
        }
        return null;
    }

    public void HumanEnter(int level)
    {
        Queue<HumanData> queueHuman = dicLevelHuman[level];
        bool humanEnter = false;
        while(curLiftLoad < capacity && queueHuman.Count > 0)
        {
            listHumanInLift.Add(queueHuman.Dequeue());
            humanEnter = true;
        }

        if (humanEnter)
        {
            int ran = Random.Range(0, 2);
            switch (ran)
            {
                case 0:
                    PublicTool.PlaySound(SoundType.Hello1);
                    break;
                case 1:
                    PublicTool.PlaySound(SoundType.Hello2);
                    break;
            }
        }
    }

    public void HumanArrive(int level)
    {
        bool humanArrive = false;

        for (int i = listHumanInLift.Count-1; i >= 0; i--)
        {
            HumanData humanData = listHumanInLift[i];
            if(level == humanData.targetPos)
            {
                listHumanLeave.Add(humanData);
                popularity++;
                listHumanInLift.Remove(humanData);
                humanArrive = true;
            }
        }

        if (humanArrive)
        {
            PublicTool.PlaySound(SoundType.DaDa);

        }
    }

    public void HumanEat()
    {
        int moneyTemp = 0;
        PublicTool.PlaySound(SoundType.Eat);
        for (int i = 0; i < listHumanInLift.Count; i++)
        {
            HumanData humanData = listHumanInLift[i];
            //Eat
            moneyTemp += humanData.GetMoney();
        }
        money += moneyTemp;
        EventCenter.Instance.EventTrigger("EffectMoneyText", new EffectMoneyTextInfo("+" + moneyTemp, Vector2.zero));
    }
}


public class HumanData
{
    public int keyID = -1;
    public int typeID = -1;
    public int initialPos;
    public int targetPos;

    public HumanState humanState = HumanState.InQueue;

    public HumanDataExcelItem GetItem()
    {
        return PublicTool.GetHumanItem(typeID);
    }

    public int GetMoney()
    {
        return GetItem().money;
    }

    public HumanData(int keyID,int typeID)
    {
        this.keyID = keyID;
        this.typeID = typeID;
    }

    
}

public enum HumanState
{
    InQueue,
    InLift,
    Leave,
    Eaten
}