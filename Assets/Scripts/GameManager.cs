using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public List<PlantData> plantCharactersList = new List<PlantData>();
    public List<float> plantCharacterFriendshipList = new List<float>();
    public List<bool> plantCharacterUnlockedList = new List<bool>();
    public List<CharacterButton> characterButtonList = new List<CharacterButton>();
    public GameObject characterMenu;
    public Color[] characterMood;

    public Color[] heartColour;
    public PlantData currentCharacter;
    public Image[] heartGuage;
    public TextMeshProUGUI characterConversationText;

    public List<ConversationType> conversationTypesList = new List<ConversationType>();
    private List<ConversationType> randomConversationList = new List<ConversationType>();
    public List<ConversationCard> currentConversationCardsList = new List<ConversationCard>();
    public List<ConversationType> currentConversationTypesList = new List<ConversationType>();
    public Image characterImage;
    public ParticleSystem[] conversationPart;
    
    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup()
    {
        if(plantCharacterFriendshipList.Count > 0)
        {
            plantCharacterFriendshipList.Clear();
        }
        for(int i = 0; i < characterButtonList.Count; i++)
        {

            characterButtonList[i].plantData = plantCharactersList[i];
            plantCharacterFriendshipList.Add(0);
            plantCharacterUnlockedList.Add(plantCharactersList[i].isUnlocked);
            characterButtonList[i].UpdateUI();
            characterButtonList[i].button.interactable = plantCharactersList[i].isUnlocked;
        }
    }

    public void StartCharacterConversation(CharacterButton button)
    {
        currentCharacter = button.plantData;
        RefreshCards();
    }

    public void LeaveCharacterConversation()
    {
        for(int i =0; i< characterButtonList.Count; i++)
        {
         characterButtonList[i].UpdateUI();

        }

        currentCharacter = null;
    }

    public void HaveConversation(ConversationCard card)
    {
        for (int i = 0; i < plantCharactersList.Count; i++)
        {
            if (currentCharacter == plantCharactersList[i])
            {
                plantCharacterFriendshipList[i] += Conversation(card);

                switch (Conversation(card))
                {
                    case 5f:
                        if (conversationPart[0].isPlaying)
                        {
                            conversationPart[0].Stop();
                        }
                        conversationPart[0].Play();
                        break;

                    case 2f:
                        if (conversationPart[1].isPlaying)
                        {
                            conversationPart[1].Stop();
                        }
                        conversationPart[1].Play();
                        break;

                    case -2f:
                        if (conversationPart[2].isPlaying)
                        {
                            conversationPart[2].Stop();
                        }
                        conversationPart[2].Play();
                        break;
                    
                    case -5f:
                        if (conversationPart[3].isPlaying)
                        {
                            conversationPart[3].Stop();
                        }
                        conversationPart[3].Play();
                        break;
                }

                for (int j = 0; j < currentCharacter.unlockPlant.Length; j++)
                {

                  if (PlantCharacterUnlocked(currentCharacter.unlockPlant[j] ) == false)
                  {

                            if (currentCharacter.unlockFriendshipAmount[j] >= 0)
                            {
                                if (PositiveFriendshipCheck(plantCharacterFriendshipList[i], currentCharacter.unlockFriendshipAmount[j]) == true)
                                {
                                    plantCharacterUnlockedList[i] = true;
                                UpdatePlantUnlocked(currentCharacter.unlockPlant[j]);
                                }
                            }

                            else
                            {
                                if (NegativeFriendshipCheck(plantCharacterFriendshipList[i], currentCharacter.unlockFriendshipAmount[j]) == true)
                                {
                                    plantCharacterUnlockedList[i] = true;
                                UpdatePlantUnlocked(currentCharacter.unlockPlant[j]);
                            }
                            }
                        }
                    
                }

        }

    }
       
        RefreshCards();
}
    

    public float Conversation(ConversationCard card)
    {
        for (int i = 0; i < currentCharacter.loveConversation.Count; i++)
        {
            if (currentCharacter.loveConversation[i] == card.type)
            {
                return 5f;
            }
        }

        for (int j = 0; j < currentCharacter.likeConversation.Count; j++)
        {
            if (currentCharacter.likeConversation[j] == card.type)
            {
                return 2f;
            }
        }

        for (int k = 0; k < currentCharacter.dislikeConversation.Count; k++)
        {
            if (currentCharacter.dislikeConversation[k] == card.type)
            {
                return -2f;
            }
        }

        for (int l = 0; l < currentCharacter.hateConversation.Count; l++)
        {
            if (currentCharacter.hateConversation[l] == card.type)
            {
                return -5f;
            }

        }

        return 0f;
    }

    public void RefreshCards()
    {
        currentConversationTypesList.Clear();
        randomConversationList.Clear();

        foreach (ConversationType type in conversationTypesList)
        {
            randomConversationList.Add(type);
        }


        for (int i = 0; i < (currentConversationCardsList.Count); i++)
        {
            ConversationType cT = randomConversationList[Random.Range((int)0, (int)randomConversationList.Count)];

            currentConversationCardsList[i].type = cT;

            randomConversationList.Remove(cT);
            currentConversationTypesList.Add(cT);

            currentConversationCardsList[i].UpdateUI();
        }
        UpdateConversationUI();
    }

    public void UpdateConversationUI()
    {
        characterImage.sprite = currentCharacter.plantSprite;
        characterConversationText.text = currentCharacter.name;

        for (int i = 0; i < plantCharactersList.Count; i++)
        {
            if (currentCharacter == plantCharactersList[i])
            {
                float a = plantCharacterFriendshipList[i];

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

                        heartGuage[j].color = new Color(heartColour[0].r, heartColour[0].g, heartColour[0].b);

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
                            heartGuage[j].color = new Color(heartColour[1].r, heartColour[1].g, heartColour[1].b);
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

    public bool PlantCharacterUnlocked(PlantData data)
    {
        for(int i =0; i < plantCharactersList.Count; i++)
        {
            if(plantCharactersList[i] == data)
            {
                return plantCharacterUnlockedList[i];
            }
        }
        return true;
    }
    public bool PositiveFriendshipCheck(float f, float p)
    {
        if(f > p)
        {
            return true;
        }

        return false;
    }

    public bool NegativeFriendshipCheck(float f, float p)
    {
        if (f < p)
        {
            return true;
        }

        return false;
    }

    public void UpdatePlantUnlocked(PlantData data)
    {
        for (int i = 0; i < plantCharactersList.Count; i++)
        {
            if (plantCharactersList[i] == data)
            {
                plantCharacterUnlockedList[i] = true;
            }
        }
    }

}

