using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class catLable
{
    public catLable(string[] cats, GameObject root)
    {
        GameObject axisNames = new GameObject();
        axisNames.name = " axisName";
        axisNames.transform.parent = root.transform;
        axisNames.transform.localPosition = new Vector3(0, 0, 0);

        TextMeshPro text;
        GameObject newText = new GameObject(cats[0]);
        newText.AddComponent<TextMeshPro>();
        text = newText.GetComponent<TextMeshPro>();
        RectTransform rect = newText.GetComponent<RectTransform>();

        text.text = cats[0];
        text.enableAutoSizing = true;
        text.fontSizeMin = 1;
        text.fontSizeMax = 5;

        text.alignment = TextAlignmentOptions.Center;// text setup

        newText.transform.parent = root.transform;
        newText.transform.localPosition = new Vector3(0, 1f, -1);//text alinement
    }
    
}
