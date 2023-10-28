/*Auto Create, Don't Edit !!!*/

using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

[Serializable]
public partial class CharacterDataExcelItem : ExcelItemBase
{
	public string name;
	public int score;
	public int waitTime;
}

[CreateAssetMenu(fileName = "CharacterDataExcelData", menuName = "Excel To ScriptableObject/Create CharacterDataExcelData", order = 1)]
public partial class CharacterDataExcelData : ExcelDataBase<CharacterDataExcelItem>
{
}

#if UNITY_EDITOR
public class CharacterDataAssetAssignment
{
	public static bool CreateAsset(List<Dictionary<string, string>> allItemValueRowList, string excelAssetPath)
	{
		if (allItemValueRowList == null || allItemValueRowList.Count == 0)
			return false;
		int rowCount = allItemValueRowList.Count;
		CharacterDataExcelItem[] items = new CharacterDataExcelItem[rowCount];
		for (int i = 0; i < items.Length; i++)
		{
			items[i] = new CharacterDataExcelItem();
			items[i].id = Convert.ToInt32(allItemValueRowList[i]["id"]);
			items[i].name = allItemValueRowList[i]["name"];
			items[i].score = Convert.ToInt32(allItemValueRowList[i]["score"]);
			items[i].waitTime = Convert.ToInt32(allItemValueRowList[i]["waitTime"]);
		}
		CharacterDataExcelData excelDataAsset = ScriptableObject.CreateInstance<CharacterDataExcelData>();
		excelDataAsset.items = items;
		if (!Directory.Exists(excelAssetPath))
			Directory.CreateDirectory(excelAssetPath);
		string pullPath = excelAssetPath + "/" + typeof(CharacterDataExcelData).Name + ".asset";
		UnityEditor.AssetDatabase.DeleteAsset(pullPath);
		UnityEditor.AssetDatabase.CreateAsset(excelDataAsset, pullPath);
		UnityEditor.AssetDatabase.Refresh();
		return true;
	}
}
#endif


