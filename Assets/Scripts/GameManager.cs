using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<PlantData> plantCharactersList = new List<PlantData>();
    public List<float> plantCharacterFriendshipList = new List<float>();
    public List<bool> plantCharacterUnlockedList = new List<bool>();
    public List<CharacterButton> characterButtonList = new List<CharacterButton>();
    public GameObject characterMenu;
    public Color[] characterMood;

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
        Debug.Log("Start Conversation with " + $"{button.plantData.name}");
    }
}
