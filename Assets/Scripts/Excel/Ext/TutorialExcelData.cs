using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TutorialExcelData
{
    public Dictionary<TutorialGroup, List<TutorialExcelItem>> dicTutorial = new Dictionary<TutorialGroup, List<TutorialExcelItem>>();

    public void Init()
    {
        dicTutorial.Clear();

        for(int i = 0; i < items.Length; i++)
        {
            TutorialExcelItem tutorial = items[i];

            if (dicTutorial.ContainsKey(tutorial.group))
            {
                dicTutorial[tutorial.group].Add(tutorial);
            }
            else
            {
                List<TutorialExcelItem> listTutorial = new List<TutorialExcelItem>();
                listTutorial.Add(tutorial);
                dicTutorial.Add(tutorial.group, listTutorial);
            }
        }
    }

}
