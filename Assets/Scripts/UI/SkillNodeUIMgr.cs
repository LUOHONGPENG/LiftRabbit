using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillNodeUIMgr : MonoBehaviour
{
    public GameObject objPopup;

    [Header("SkillNode")]
    public Transform tfNode;
    public GameObject pfNode;

    private List<SkillNodeUIItem> listSkillNode = new List<SkillNodeUIItem>();
    public Dictionary<int, SkillNodeUIItem> dicNodeUI = new Dictionary<int, SkillNodeUIItem>();

    //public List<SkillNodeUIItem> listNodeUI = new List<SkillNodeUIItem>();
    //public Dictionary<int, SkillNodeUIItem> dicNodeUI = new Dictionary<int, SkillNodeUIItem>();

    [Header("SkillLine")]
    public Transform tfLine;
    public GameObject pfLine;

    public Button btnClose;


    public void Init()
    {
        PublicTool.ClearChildItem(tfNode);
        PublicTool.ClearChildItem(tfLine);
        listSkillNode.Clear();
        dicNodeUI.Clear();

        for (int i = 0; i < GameMgr.Instance.skillNodeExcelData.items.Length; i++)
        {
            SkillNodeExcelItem skillItem = GameMgr.Instance.skillNodeExcelData.items[i];
            GameObject objNode = GameObject.Instantiate(pfNode, tfNode);
            objNode.transform.localPosition = new Vector2(skillItem.columnID * GameGlobal.skillNodeSpacingX, 250f - skillItem.rowID * GameGlobal.skillNodeSpacingY);
            SkillNodeUIItem itemNode = objNode.GetComponent<SkillNodeUIItem>();
            itemNode.Init(skillItem.id,this);
            listSkillNode.Add(itemNode);
            dicNodeUI.Add(skillItem.id, itemNode);

            if (skillItem.conditionPreNode > 0)
            {
                if (dicNodeUI.ContainsKey(skillItem.conditionPreNode))
                {
                    GameObject objLine = GameObject.Instantiate(pfLine, tfLine);
                    SkillLineUIItem itemLine = objLine.GetComponent<SkillLineUIItem>();
                    itemLine.Init(itemNode.transform.localPosition, dicNodeUI[skillItem.conditionPreNode].transform.localPosition);
                }
            }

        }

        btnClose.onClick.RemoveAllListeners();
        btnClose.onClick.AddListener(delegate ()
        {
            objPopup.SetActive(false);
        });
    }

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener("SkillNodePage", SkillNodePageEvent);
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener("SkillNodePage", SkillNodePageEvent);

    }

    private void SkillNodePageEvent(object arg0)
    {
        RefreshAllNode();
        objPopup.SetActive(true);
    }


    public void RefreshAllNode()
    {
        for(int i = 0; i < listSkillNode.Count; i++)
        {
            listSkillNode[i].RefreshNode();
        }
    }

}
