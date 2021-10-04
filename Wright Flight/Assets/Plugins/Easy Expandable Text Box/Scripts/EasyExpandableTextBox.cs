using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EasyExpandableTextBox : MonoBehaviour
{
    public TextMeshProUGUI textTMP;
    public Sprite boxSprite;
    public TMP_FontAsset font;
    [TextArea]
    public string text;

    public int fontSize = 72;
    public bool autoSize = false;
    public Color color = Color.black;
    public TextAlignmentOptions alignment;
    public int autoSizeMin = 12, autoSizeMax = 72; 
    [SerializeField]
    public FontStyles style = FontStyles.Normal;
    public bool settings;

    //Vertical Layout Group
    public int left;
    public int right;
    public int top;
    public int bottom;
    public TextAnchor boxAlignment;

    
    public void Awake()
    {
        textTMP = GetComponentInChildren<TextMeshProUGUI>();
    }

  
    public float EasyMessage(string message, float timeBetweenCharacters = 0.125f)
    {
        StartCoroutine(EasyMessageCoroutine(message, timeBetweenCharacters));
        return message.Length * 0.125f;
    }


    private IEnumerator EasyMessageCoroutine(string message, float timeBetweenCharacters)
    {
        text = "";
        textTMP.text = text;
        if (timeBetweenCharacters != 0)
        {
            foreach (char character in message)
            {
                text += character;
                textTMP.text = text;
                yield return new WaitForSeconds(timeBetweenCharacters);
            }
        }
        else
        {
            text = message;
            textTMP.text = text;
        }
      
    }
    
}
