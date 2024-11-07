using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant Data", menuName = ("New Plant Data"))]
public class PlantData : ScriptableObject
{
    public Sprite plantSprite;
    public List<ConversationType> loveConversation = new List<ConversationType>();
    public List<ConversationType> likeConversation = new List<ConversationType>();
    public List<ConversationType> dislikeConversation = new List<ConversationType>();
    public List<ConversationType> hateConversation = new List<ConversationType>();

    public bool isUnlocked;
    public PlantData unlockPlant;
   
}

