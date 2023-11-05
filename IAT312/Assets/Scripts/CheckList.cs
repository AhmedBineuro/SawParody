using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class CheckList : MonoBehaviour
{
    //The list of text object and their names (will be used to add and remove text from the checklist)
    private Dictionary<string, GameObject> listDictionary;
    public GameObject checkListCanvas;
    private void Awake()
    {
        listDictionary = new Dictionary<string, GameObject>(0); // Initialize the dictionary
    }
    public void addCheckListItem(string name,string content)
    {
        if(!checkListCanvas.activeInHierarchy)
            checkListCanvas.SetActive(true);
        if (listDictionary.ContainsKey(name))
        {
            Debug.LogError("An item with the name '" + name + "' already exists in the dictionary.");
            return; // Exit the method if the key already exists
        }
        GameObject checklistItem= new GameObject("checkListItem");
        TextMeshProUGUI text= checklistItem.AddComponent<TextMeshProUGUI>();
        text.text = "-"+content;
        text.color = Color.black;
        text.alignment = TextAlignmentOptions.Left;
        text.enableAutoSizing = true;
        text.fontSizeMin = 4;
        text.fontSizeMax= 12;
        checklistItem.transform.SetParent(this.transform, false);
        
        listDictionary.Add(name,checklistItem);
    }
    void Update()
    {
        if (listDictionary.Count==0)
            checkListCanvas.SetActive(false);
        Debug.Log("Count: " + listDictionary.Count);
    }

    //Function to remove the checklist item from the list
    public void removeCheckListItem(string name)
    {
        if (listDictionary.TryGetValue(name, out GameObject gameObjectToRemove))
        {
            listDictionary.Remove(name);
            Destroy(gameObjectToRemove); // Destroy the GameObject, not just the component
        }
        else Debug.Log("Couldn't find " + name);
    }
}
