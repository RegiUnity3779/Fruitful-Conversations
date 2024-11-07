using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<PlantCharacter> plantCharactersList = new List<PlantCharacter>();
    public List<float> plantCharacterFriendshipList = new List<float>();
    public List<bool> plantCharacterUnlockedList = new List<bool>();
    public CharacterButton characterButtonTemplate;
    public List<CharacterButton> characterButtonList = new List<CharacterButton>();
    public GameObject characterMenu;

    // Start is called before the first frame update
    void Start()
    {
        
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
        for(int i = 0; i < plantCharactersList.Count; i++)
        {
           CharacterButton a = Instantiate(characterButtonTemplate, characterMenu.transform);
            a.UpdateUI();
        }
    }

    public void StartCharacterConversation(CharacterButton button)
    {
        Debug.Log("Start Conversation with " + $"{button.plantCharacter}");
    }
}
