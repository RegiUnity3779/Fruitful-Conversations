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
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        if (plantData != null)
        {
            characterImage.sprite = plantData.plantSprite;

            for (int i = 0; i < gameManager.plantCharactersList.Count; i++)
            {
                if (plantData == gameManager.plantCharactersList[i])
                {
                    button.interactable = gameManager.plantCharacterUnlockedList[i];

                    float a = gameManager.plantCharacterFriendshipList[i];

                    if (a > 100)
                    {
                        a = 100;
                    }

                    else if (a < -100)
                    {
                        a = -100;
                    }

                    if (a >= 0)
                    {
                        for (int j = 0; j < heartGuage.Length; j++)
                        {

                            heartGuage[j].color = new Color(gameManager.heartColour[0].r, gameManager.heartColour[0].g, gameManager.heartColour[0].b);

                            if (a > 0f)
                            {
                                if (a > 20f)
                                {

                                    heartGuage[j].fillAmount = 1f;
                                }
                                else
                                {
                                    heartGuage[j].fillAmount = a / 20;
                                }

                                a -= 20f;
                            }

                            else
                            {
                                heartGuage[j].fillAmount = 0f;
                            }
                        }

                    }

                    else
                    {


                        if (a < 0f)
                        {
                            for (int j = 0; j < heartGuage.Length; j++)
                            {
                                heartGuage[j].color = new Color(gameManager.heartColour[1].r, gameManager.heartColour[1].g, gameManager.heartColour[1].b);
                                if (a < 0f)
                                {
                                    if (a < -20f)
                                    {

                                        heartGuage[j].fillAmount = 1f;
                                    }
                                    else
                                    {
                                        heartGuage[j].fillAmount = a / -20;
                                    }
                                }

                                else
                                {
                                    heartGuage[j].fillAmount = 0f;
                                }
                                a += 20f;
                            }

                        }
                    }
                }


            }
        }

        else
        {
            button.interactable = false;
            characterImage.sprite = null;

            for (int j = 0; j < heartGuage.Length; j++)
            {

                heartGuage[j].color = new Color(gameManager.heartColour[0].r, gameManager.heartColour[0].g, gameManager.heartColour[0].b);
                heartGuage[j].fillAmount = 0;
            }
        }

    }
    }

