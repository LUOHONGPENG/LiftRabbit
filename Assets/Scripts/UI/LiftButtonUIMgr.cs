using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class LiftButtonUIMgr : MonoBehaviour
{
    public Transform tfLiftButton;
    public GameObject pfLiftButton;

    private Dictionary<int, LiftButtonUIItem> dicLiftButton = new Dictionary<int, LiftButtonUIItem>();

    public Button btnEat;

    private GameData gameData;
    private bool isInit = false;

    private void Update()
    {
        if (isInit)
        {
            if (gameData.canEat)
            {
                btnEat.gameObject.SetActive(true);
                if (GameMgr.Instance.isMoving)
                {
                    btnEat.interactable = false;
                }
                else
                {
                    btnEat.interactable = true;
                }
            }
            else
            {
                btnEat.gameObject.SetActive(false);
            }
        }
    }

    public void Init()
    {
        gameData = PublicTool.GetGameData();

        PublicTool.ClearChildItem(tfLiftButton);
        dicLiftButton.Clear();

        for(int i = 1;i <= gameData.numLevel; i++)
        {
            GameObject objLiftButton = GameObject.Instantiate(pfLiftButton, tfLiftButton);
            LiftButtonUIItem itemLiftButton = objLiftButton.GetComponent<LiftButtonUIItem>();
            itemLiftButton.Init(i);
            dicLiftButton.Add(i, itemLiftButton);
        }

        btnEat.onClick.RemoveAllListeners();
        btnEat.onClick.AddListener(delegate ()
        {
            EventCenter.Instance.EventTrigger("SelectLevel", -99);
        });
        isInit = true;
    }

    public void RefreshLiftButton()
    {
        for (int i = 1; i <= gameData.numLevel; i++)
        {
            if (!dicLiftButton.ContainsKey(i))
            {
                GameObject objLiftButton = GameObject.Instantiate(pfLiftButton, tfLiftButton);
                LiftButtonUIItem itemLiftButton = objLiftButton.GetComponent<LiftButtonUIItem>();
                itemLiftButton.Init(i);
                dicLiftButton.Add(i, itemLiftButton);
            }
        }
    }
}
