using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class LevelUpUIMgr : MonoBehaviour
{
    public GameObject objPopup;

    public Button btnOK;

    public List<StarUIItem> listStar;

    private GameData gameData;

    public void Init()
    {
        gameData = PublicTool.GetGameData();

        btnOK.onClick.RemoveAllListeners();
        btnOK.onClick.AddListener(delegate ()
        {
            objPopup.SetActive(false);
            switch (gameData.curStarLevel)
            {
                case StarLevel.Star1:
                    EventCenter.Instance.EventTrigger("TutorialStart", TutorialGroup.Star1);
                    break;
                case StarLevel.Star2:
                    EventCenter.Instance.EventTrigger("TutorialStart", TutorialGroup.Star2);
                    break;
                case StarLevel.Star3:
                    EventCenter.Instance.EventTrigger("TutorialStart", TutorialGroup.Star3);
                    break;
                case StarLevel.Star4:
                    EventCenter.Instance.EventTrigger("TutorialStart", TutorialGroup.Star4);
                    break;
            }
                    
        });

    }

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener("LevelUpPage", LevelUpEvent);
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener("LevelUpPage", LevelUpEvent);

    }

    private void LevelUpEvent(object arg0)
    {

        RefreshStar();

        objPopup.SetActive(true);

    }

    public void RefreshStar()
    {
        int StarLevel = (int)gameData.curStarLevel;

        for (int i = 0; i < 5; i++)
        {
            if (i < StarLevel)
            {
                listStar[i].RefreshStarView(true);
            }
            else
            {
                listStar[i].RefreshStarView(false);
            }
        }
    }

}
