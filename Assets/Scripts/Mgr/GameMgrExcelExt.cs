using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr
{
    [HideInInspector]
    public HumanExcelData humanExcelData;
    [HideInInspector]
    public ComboExcelData comboExcelData;
    [HideInInspector]
    public SkillNodeExcelData skillNodeExcelData;
    [HideInInspector]
    public TutorialExcelData tutorialExcelData;


    public void InitExcelData()
    {
        humanExcelData = ExcelManager.Instance.GetExcelData<HumanExcelData, HumanExcelItem>();
        comboExcelData = ExcelManager.Instance.GetExcelData<ComboExcelData, ComboExcelItem>();
        skillNodeExcelData = ExcelManager.Instance.GetExcelData<SkillNodeExcelData, SkillNodeExcelItem>();
        tutorialExcelData = ExcelManager.Instance.GetExcelData<TutorialExcelData, TutorialExcelItem>();

        tutorialExcelData.Init();
    }

}
