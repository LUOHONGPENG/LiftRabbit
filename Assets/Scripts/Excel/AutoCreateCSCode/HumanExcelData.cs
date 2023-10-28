/*Auto Create, Don't Edit !!!*/

using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

[Serializable]
public partial class HumanExcelItem : ExcelItemBase
{
	public string name;
	public int money;
	public int waitTime;
	public string spriteUrl;
}

[CreateAssetMenu(fileName = "HumanExcelData", menuName = "Excel To ScriptableObject/Create HumanExcelData", order = 1)]
public partial class HumanExcelData : ExcelDataBase<HumanExcelItem>
{
}

#if UNITY_EDITOR
public class HumanAssetAssignment
{
	public static bool CreateAsset(List<Dictionary<string, string>> allItemValueRowList, string excelAssetPath)
	{
		if (allItemValueRowList == null || allItemValueRowList.Count == 0)
			return false;
		int rowCount = allItemValueRowList.Count;
		HumanExcelItem[] items = new HumanExcelItem[rowCount];
		for (int i = 0; i < items.Length; i++)
		{
			items[i] = new HumanExcelItem();
			items[i].id = Convert.ToInt32(allItemValueRowList[i]["id"]);
			items[i].name = allItemValueRowList[i]["name"];
			items[i].money = Convert.ToInt32(allItemValueRowList[i]["money"]);
			items[i].waitTime = Convert.ToInt32(allItemValueRowList[i]["waitTime"]);
			items[i].spriteUrl = allItemValueRowList[i]["spriteUrl"];
		}
		HumanExcelData excelDataAsset = ScriptableObject.CreateInstance<HumanExcelData>();
		excelDataAsset.items = items;
		if (!Directory.Exists(excelAssetPath))
			Directory.CreateDirectory(excelAssetPath);
		string pullPath = excelAssetPath + "/" + typeof(HumanExcelData).Name + ".asset";
		UnityEditor.AssetDatabase.DeleteAsset(pullPath);
		UnityEditor.AssetDatabase.CreateAsset(excelDataAsset, pullPath);
		UnityEditor.AssetDatabase.Refresh();
		return true;
	}
}
#endif


