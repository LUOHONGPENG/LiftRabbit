using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SkillNodeUIItem : MonoBehaviour
{
    public Button btnNode;
    public Image imgIconBg;
    public Image imgIcon;

    public Text codeName;
    public Image imgName;
    public Image imgCost;
    public Text codeCost;

    public List<Color> listColorIcon = new List<Color>();
    public List<Color> listColorBg = new List<Color>();

    public List<Color> listTextBg = new List<Color>();
    public List<Color> listTextContent = new List<Color>();


    private int ID = -1;
    private SkillNodeExcelItem thisItem;
    private GameData gameData;

    public void Init(int id, SkillNodeUIMgr parent)
    {
        gameData = PublicTool.GetGameData();
        thisItem = PublicTool.GetSkillNodeItem(id);
        ID = thisItem.id;
        imgIcon.sprite = Resources.Load("Sprites/" + thisItem.iconUrl, typeof(Sprite)) as Sprite;
        codeName.text = thisItem.name;
        codeCost.text = thisItem.costPopular.ToString();

        btnNode.onClick.RemoveAllListeners();
        btnNode.onClick.AddListener(delegate ()
        {
            if(gameData.Popularity < thisItem.costPopular)
            {
                //Not Enough
                PublicTool.PlaySound(SoundType.NoPopular);

            }
            else
            {
                gameData.UnlockSkillNode(ID);
                gameData.Popularity -= thisItem.costPopular;
                //Refresh
                parent.RefreshAllNode();

                PublicTool.PlaySound(SoundType.LevelUp);
            }

        });
        
    }

    public void RefreshNode()
    {
        imgIcon.sprite = Resources.Load("Sprites/" + thisItem.iconUrl, typeof(Sprite)) as Sprite;

        if (gameData.listUnlockSkillNode.Contains(ID))
        {
            btnNode.interactable = false;

            imgIconBg.color = listColorBg[0];
            imgIcon.color = listColorIcon[0];
            imgName.color = listTextBg[0];
            codeName.color = listTextContent[0];
            imgCost.gameObject.SetActive(false);

        }
        else
        {
            if (gameData.listUnlockSkillNode.Contains(thisItem.conditionPreNode))
            {
                btnNode.interactable = true;

                imgIconBg.color = listColorBg[1];
                imgIcon.color = listColorIcon[1];
                imgName.color = listTextBg[1];
                codeName.color = listTextContent[1];
                imgCost.gameObject.SetActive(true);
                imgCost.color = listTextBg[1];
                codeCost.color = listTextContent[1];
            }
            else
            {
                btnNode.interactable = false;

                imgIconBg.color = listColorBg[2];
                imgIcon.color = listColorIcon[2];
                imgName.color = listTextBg[2];
                codeName.color = listTextContent[2];
                imgCost.gameObject.SetActive(true);
                imgCost.color = listTextBg[2];
                codeCost.color = listTextContent[2];
            }
        }
    }




}
