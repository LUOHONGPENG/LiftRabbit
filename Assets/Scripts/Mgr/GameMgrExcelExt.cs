using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr
{
    [HideInInspector]
    public HumanDataExcelData humanExcelData;

    public void InitExcelData()
    {
        humanExcelData = ExcelManager.Instance.GetExcelData<HumanDataExcelData, HumanDataExcelItem>();
    }

}
