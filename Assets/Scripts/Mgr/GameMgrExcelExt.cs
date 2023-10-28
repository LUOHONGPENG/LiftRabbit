using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr
{
    [HideInInspector]
    public HumanExcelData humanExcelData;
    [HideInInspector]
    public ComboExcelData comboExcelData;

    public void InitExcelData()
    {
        humanExcelData = ExcelManager.Instance.GetExcelData<HumanExcelData, HumanExcelItem>();
        comboExcelData = ExcelManager.Instance.GetExcelData<ComboExcelData, ComboExcelItem>();
    }

}
