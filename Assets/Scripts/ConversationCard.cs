using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConversationCard : MonoBehaviour
{
    public ConversationType type;
    public Image conversationImage;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        conversationImage.sprite = type.sprite;
        text.text = "Talk about " + $"{type.name}";

    }
}
