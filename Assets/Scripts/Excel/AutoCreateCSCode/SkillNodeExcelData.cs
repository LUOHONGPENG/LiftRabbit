/*Auto Create, Don't Edit !!!*/

using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

[Serializable]
public partial class SkillNodeExcelItem : ExcelItemBase
{
	public string name;
	public bool isInitUnlock;
	public int costPopular;
	public int conditionPreNode;
	public int rowID;
	public int columnID;
	public string iconUrl;
}

[CreateAssetMenu(fileName = "SkillNodeExcelData", menuName = "Excel To ScriptableObject/Create SkillNodeExcelData", order = 1)]
public partial class SkillNodeExcelData : ExcelDataBase<SkillNodeExcelItem>
{
}

#if UNITY_EDITOR
public class SkillNodeAssetAssignment
{
	public static bool CreateAsset(List<Dictionary<string, string>> allItemValueRowList, string excelAssetPath)
	{
		if (allItemValueRowList == null || allItemValueRowList.Count == 0)
			return false;
		int rowCount = allItemValueRowList.Count;
		SkillNodeExcelItem[] items = new SkillNodeExcelItem[rowCount];
		for (int i = 0; i < items.Length; i++)
		{
			items[i] = new SkillNodeExcelItem();
			items[i].id = Convert.ToInt32(allItemValueRowList[i]["id"]);
			items[i].name = allItemValueRowList[i]["name"];
			items[i].isInitUnlock = Convert.ToBoolean(allItemValueRowList[i]["isInitUnlock"]);
			items[i].costPopular = Convert.ToInt32(allItemValueRowList[i]["costPopular"]);
			items[i].conditionPreNode = Convert.ToInt32(allItemValueRowList[i]["conditionPreNode"]);
			items[i].rowID = Convert.ToInt32(allItemValueRowList[i]["rowID"]);
			items[i].columnID = Convert.ToInt32(allItemValueRowList[i]["columnID"]);
			items[i].iconUrl = allItemValueRowList[i]["iconUrl"];
		}
		SkillNodeExcelData excelDataAsset = ScriptableObject.CreateInstance<SkillNodeExcelData>();
		excelDataAsset.items = items;
		if (!Directory.Exists(excelAssetPath))
			Directory.CreateDirectory(excelAssetPath);
		string pullPath = excelAssetPath + "/" + typeof(SkillNodeExcelData).Name + ".asset";
		UnityEditor.AssetDatabase.DeleteAsset(pullPath);
		UnityEditor.AssetDatabase.CreateAsset(excelDataAsset, pullPath);
		UnityEditor.AssetDatabase.Refresh();
		return true;
	}
}
#endif


