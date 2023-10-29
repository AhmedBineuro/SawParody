using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public string passcode;
    public string current_Values;
    private TextMeshPro display;

    public void addValue(string value)
    {
        if(display==null)
            display = GetComponent<TextMeshPro>();
        if (current_Values.Length == passcode.Length)
        {
            if (passcode.Equals(current_Values))
                Debug.Log("Correct");
            else
                Debug.Log("Wrong");
            current_Values = "";
            display.SetText("");
        }
        else
        {
            current_Values+= value;
            display.text = current_Values;
        }
    }

}
