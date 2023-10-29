using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameData
{
    //List
    public List<HumanData> listAllHuman = new List<HumanData>();
    public List<HumanData> listHumanInLift = new List<HumanData>();
    public List<HumanData> listHumanArrive = new List<HumanData>();
    public List<HumanData> listHumanEscape = new List<HumanData>();
    public Dictionary<int, List<HumanData>> dicLevelHumanQueue = new Dictionary<int, List<HumanData>>();

    public HumanData GenerateHuman()
    {
        //Random initial Level
        int ran = Random.Range(1, numLevel + 1);
        int typeID = PublicTool.DrawNum(1, listUnlockHuman, null)[0];
        if (dicLevelHumanQueue.ContainsKey(ran))
        {
            if (dicLevelHumanQueue[ran].Count < curQueueLimit)
            {
                keyIDHuman++;
                HumanData newHuman = new HumanData(keyIDHuman, typeID);

                newHuman.humanState = HumanState.InQueue;
                newHuman.initialPos = ran;
                listAllHuman.Add(newHuman);
                dicLevelHumanQueue[ran].Add(newHuman);

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

    public bool HumanEnter(int level)
    {
        List<HumanData> queueHuman = dicLevelHumanQueue[level];
        bool humanEnter = false;
        while (curLiftLoad < curCapacity && queueHuman.Count > 0)
        {
            HumanData tempHuman = queueHuman[0];
            queueHuman.RemoveAt(0);
            tempHuman.humanState = HumanState.InLift;
            tempHuman.waitTime = 0;
            listHumanInLift.Add(tempHuman);
            humanEnter = true;
        }

        return humanEnter;
    }

    public int HumanArrive(int level)
    {
        int tempPopular = 0;

        for (int i = listHumanInLift.Count - 1; i >= 0; i--)
        {
            HumanData humanData = listHumanInLift[i];
            if (level == humanData.targetPos)
            {
                listHumanArrive.Add(humanData);
                humanData.humanState = HumanState.Arrive;
                if (Popularity > 50)
                {
                    tempPopular++;
                }
                else
                {
                    tempPopular += 2;
                }
                listHumanInLift.Remove(humanData);
            }
        }

        return tempPopular;

    }

    public void HumanEat()
    {
        int moneyTemp = 0;
        int moneyPanalty = 0;
        PublicTool.PlaySound(SoundType.Eat);
        Dictionary<int, int> dicTypeNum = new Dictionary<int, int>();
        for (int i = 0; i < listHumanInLift.Count; i++)
        {
            HumanData humanData = listHumanInLift[i];
            humanData.humanState = HumanState.Eaten;
            if (dicTypeNum.ContainsKey(humanData.typeID))
            {
                dicTypeNum[humanData.typeID]++;
            }
            else
            {
                dicTypeNum.Add(humanData.typeID, 1);
            }
            //Eat
            if (humanData.GetMoney() > 0)
            {
                moneyTemp += humanData.GetMoney();
            }
            else
            {
                moneyPanalty += humanData.GetMoney();
            }
        }
        Money += moneyTemp;
        EventCenter.Instance.EventTrigger("EffectMoneyText", new EffectMoneyTextInfo("Œ¸ ’+" + moneyTemp, Vector2.zero));
        Money += moneyPanalty;
        if (moneyPanalty < 0)
        {
            EventCenter.Instance.EventTrigger("EffectMoneyText", new EffectMoneyTextInfo("¿±À¿¡À " + moneyPanalty, Vector2.zero));
            int ran = Random.Range(0, 2);
            if (ran == 0)
            {
                PublicTool.PlaySound(SoundType.Spicy1);
            }
            else
            {
                PublicTool.PlaySound(SoundType.Spicy2);
            }
        }


        //Combo
        List<Vector2Int> listEatTypeNum = new List<Vector2Int>();
        foreach (var info in dicTypeNum)
        {
            Vector2Int infoVec2 = new Vector2Int(info.Key, info.Value);
            listEatTypeNum.Add(infoVec2);
        }
        List<int> listCombo = PublicTool.CheckCombo(listEatTypeNum);
        int moneyExtra = 0;
        for (int i = 0; i < listCombo.Count; i++)
        {
            int comboID = listCombo[i];
            ComboExcelItem comboItem = PublicTool.GetComboItem(comboID);

            moneyExtra += comboItem.bonus;

            EventCenter.Instance.EventTrigger("EffectMoneyText", new EffectMoneyTextInfo(comboItem.name + "+" + comboItem.bonus, Vector2.zero));
        }
        Money += moneyExtra;

    }

    private void CheckCombo(List<int> listType)
    {
        Dictionary<int, int> dicHumanTypeNum = new Dictionary<int, int>();
        for (int i = 0; i < listType.Count; i++)
        {
            int typeID = listType[i];
            if (dicHumanTypeNum.ContainsKey(typeID))
            {
                dicHumanTypeNum[typeID]++;
            }
            else
            {
                dicHumanTypeNum.Add(typeID, 1);
            }
        }
    }

}


public class HumanData
{
    public int keyID = -1;
    public int typeID = -1;
    public int initialPos;
    public int targetPos;

    public float waitTimeLimit = 100f;
    public float waitTime = 0;

    public HumanState humanState = HumanState.InQueue;

    public HumanExcelItem GetItem()
    {
        return PublicTool.GetHumanItem(typeID);
    }

    public int GetMoney()
    {
        return GetItem().money;
    }

    public HumanData(int keyID, int typeID)
    {
        this.keyID = keyID;
        this.typeID = typeID;

        this.waitTimeLimit = GetItem().waitTime;
    }

    public void TimeGoWait(float time)
    {
        waitTime += time;
    }

    public bool CheckWhetherWaitOut()
    {
        if(waitTime > waitTimeLimit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

public enum HumanState
{
    InQueue,
    InLift,
    Arrive,
    Eaten,
    Escape
}