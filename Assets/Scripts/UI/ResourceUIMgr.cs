using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUIMgr : MonoBehaviour
{
    public Text codeMoney;
    public Text codePopularity;
    public List<StarUIItem> listStar;

    public Button btnSkillTree;

    private bool isInit = false;
    public void Init()
    {
        btnSkillTree.onClick.RemoveAllListeners();
        btnSkillTree.onClick.AddListener(delegate ()
        {
            EventCenter.Instance.EventTrigger("SkillNodePage",null);
        });


        isInit = true;
    }

    private void Update()
    {
        if (isInit)
        {
            RefreshResource();
        }   
    }


    public void RefreshResource()
    {
        codeMoney.text = PublicTool.GetGameData().Money.ToString();

        codePopularity.text = PublicTool.GetGameData().Popularity.ToString();

        int StarLevel = (int)PublicTool.GetGameData().curStarLevel;

        for(int i = 0; i < 5; i++)
        {
            if(i < StarLevel)
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
