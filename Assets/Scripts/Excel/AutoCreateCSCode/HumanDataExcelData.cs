/*Auto Create, Don't Edit !!!*/

using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

[Serializable]
public partial class HumanDataExcelItem : ExcelItemBase
{
	public string name;
	public int money;
	public int waitTime;
}

[CreateAssetMenu(fileName = "HumanDataExcelData", menuName = "Excel To ScriptableObject/Create HumanDataExcelData", order = 1)]
public partial class HumanDataExcelData : ExcelDataBase<HumanDataExcelItem>
{
}

#if UNITY_EDITOR
public class HumanDataAssetAssignment
{
	public static bool CreateAsset(List<Dictionary<string, string>> allItemValueRowList, string excelAssetPath)
	{
		if (allItemValueRowList == null || allItemValueRowList.Count == 0)
			return false;
		int rowCount = allItemValueRowList.Count;
		HumanDataExcelItem[] items = new HumanDataExcelItem[rowCount];
		for (int i = 0; i < items.Length; i++)
		{
			items[i] = new HumanDataExcelItem();
			items[i].id = Convert.ToInt32(allItemValueRowList[i]["id"]);
			items[i].name = allItemValueRowList[i]["name"];
			items[i].money = Convert.ToInt32(allItemValueRowList[i]["money"]);
			items[i].waitTime = Convert.ToInt32(allItemValueRowList[i]["waitTime"]);
		}
		HumanDataExcelData excelDataAsset = ScriptableObject.CreateInstance<HumanDataExcelData>();
		excelDataAsset.items = items;
		if (!Directory.Exists(excelAssetPath))
			Directory.CreateDirectory(excelAssetPath);
		string pullPath = excelAssetPath + "/" + typeof(HumanDataExcelData).Name + ".asset";
		UnityEditor.AssetDatabase.DeleteAsset(pullPath);
		UnityEditor.AssetDatabase.CreateAsset(excelDataAsset, pullPath);
		UnityEditor.AssetDatabase.Refresh();
		return true;
	}
}
#endif


