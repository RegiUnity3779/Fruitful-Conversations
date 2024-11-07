using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    public PlantCharacter plantCharacter;
    public Image characterImage;
    public Image[] heartGuage;
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
        characterImage.sprite = plantCharacter.data.plantSprite;
        
        for(int i = 0; i < plantCharacter.gameManager.plantCharactersList.Count; i++)
        {
            if(plantCharacter == plantCharacter.gameManager.plantCharactersList[i])
            {
                float a = plantCharacter.gameManager.plantCharacterFriendshipList[i];
                if( a > 100)
                {
                    a = 100;
                }

                for (int j = 0; j < heartGuage.Length; j++)
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
            }
        }
        
       
    }
}
