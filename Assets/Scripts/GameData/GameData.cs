using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    //Data
    public int numLevel = 3;
    public int keyIDCharacter = -1;
    public int curLevel = 1;
    //List
    public List<CharacterData> listAllCharacter = new List<CharacterData>();
    public List<CharacterData> listCharacterInLift = new List<CharacterData>();

    public Dictionary<int, Queue<CharacterData>> dicLevelCharacter = new Dictionary<int, Queue<CharacterData>>();

    public GameData()
    {
        numLevel = 3;
        curLevel = 1;
        keyIDCharacter = -1;

        listAllCharacter.Clear();
        listCharacterInLift.Clear();
        dicLevelCharacter.Clear();

        for (int i = 1;i <= numLevel; i++)
        {
            Queue<CharacterData> ququeCharacter = new Queue<CharacterData>();
            dicLevelCharacter.Add(i, ququeCharacter);
        }
    }

    #region Level
    public void AddLevel()
    {
        numLevel++;
        Queue<CharacterData> ququeCharacter = new Queue<CharacterData>();
        dicLevelCharacter.Add(numLevel, ququeCharacter);
        //Refresh View
    }

    #endregion

    public void GenerateCharacter()
    {
        keyIDCharacter++;

        CharacterData newCharacter = new CharacterData(keyIDCharacter);
        //Random initial Level
        int ran = Random.Range(1, numLevel + 1);
        newCharacter.initialPos = ran;
        listAllCharacter.Add(newCharacter);
        
        
        //dicLevelCharacter.Add(ran, newCharacter);
        
        //Random target level
        List<int> listLevel = new List<int>();
        for(int i = 1;i <= numLevel; i++)
        {
            listLevel.Add(i);
        }
        List<int> listDelete = new List<int> { ran };
        newCharacter.targetPos = PublicTool.DrawNum(1, listLevel, listDelete)[0];
        //Refresh view

    }
}


public class CharacterData
{
    public int keyID = -1;
    public int initialPos;
    public int targetPos;

    public CharacterData(int keyID)
    {
        this.keyID = keyID;
    }

    
}