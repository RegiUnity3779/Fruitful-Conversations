using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    public Button button;

    public float increaseFactor;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();


    }

   public void IncreaseSize()
    {
        if (button.interactable)
        {
            button.transform.localScale *= increaseFactor;
        }
       
    }

    public void DecreaseSize()
    {
        if (button.interactable)
        {
            button.transform.localScale /= increaseFactor;
        }
    }
}
