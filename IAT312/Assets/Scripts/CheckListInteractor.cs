using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecListInteractor : MonoBehaviour
{
    public CheckList targetChecklist;
    [SerializeField] public string listItemName;
    [SerializeField] public string listItemContent;

    public void submitItem()
    {
        targetChecklist.addCheckListItem(listItemName, listItemContent);
    }
}
