using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    //Data
    public int numLevel = 3;
    public int keyIDHuman = -1;
    public int curLevel = 1;
    //List
    public List<HumanData> listAllHuman = new List<HumanData>();
    public List<HumanData> listHumanInLift = new List<HumanData>();

    public Dictionary<int, Queue<HumanData>> dicLevelHuman = new Dictionary<int, Queue<HumanData>>();

    public GameData()
    {
        numLevel = 3;
        curLevel = 1;
        keyIDHuman = -1;

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

    public HumanData GenerateCharacter()
    {
        keyIDHuman++;

        HumanData newHuman = new HumanData(keyIDHuman);
        //Random initial Level
        int ran = Random.Range(1, numLevel + 1);
        newHuman.initialPos = ran;
        listAllHuman.Add(newHuman);
                
        //Random target level
        List<int> listLevel = new List<int>();
        for(int i = 1;i <= numLevel; i++)
        {
            listLevel.Add(i);
        }
        List<int> listDelete = new List<int> { ran };
        newHuman.targetPos = PublicTool.DrawNum(1, listLevel, listDelete)[0];
        //Refresh view

        return newHuman;
    }
}


public class HumanData
{
    public int keyID = -1;
    public int initialPos;
    public int targetPos;

    public HumanData(int keyID)
    {
        this.keyID = keyID;
    }

    
}