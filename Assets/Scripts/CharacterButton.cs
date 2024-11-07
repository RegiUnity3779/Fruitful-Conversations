using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    public GameManager gameManager;
    public PlantData plantData;
    public Image characterImage;
    public Image[] heartGuage;
    public Button button;
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
        characterImage.sprite = plantData.plantSprite;
        
        for(int i = 0; i < gameManager.plantCharactersList.Count; i++)
        {
            if(plantData == gameManager.plantCharactersList[i])
            {
                float a = gameManager.plantCharacterFriendshipList[i];
                if( a > 100)
                {
                    a = 100;
                }

                if (a < -100)
                {
                    a = -100;
                }
                for (int j = 0; j < heartGuage.Length; j++)
                {
                    if (a >= 0)
                    {
                        if (a > 20)
                        {
                            a -= 20;
                            heartGuage[j].fillAmount = 1;
                        }
                        else
                        {
                            heartGuage[j].fillAmount = a / 20;
                        }
                    }

                    else
                    {
                        if (a < -20)
                        {
                            a += 20;
                            heartGuage[j].fillAmount = 1;
                        }
                        else
                        {
                            heartGuage[j].fillAmount = -(a / 20);
                        }
                    }
        }
            }
        }
        
       
    }
}
