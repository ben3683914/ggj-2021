using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public List<Quest> Quests;
    public List<Quest> CurrentQuests;
    public int RandomItemCount = 1;

    private void Awake()
    {
        Instance = this;
        Quests = new List<Quest>();
        CurrentQuests = new List<Quest>();

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Dildo,
            Description = "I uh, lost my..back massager. I would really like it returned so I can relieve my stress"
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Hammer,
            Description = "Joe stole my hammer. I want it back!"
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Hammer,
            Description = "This is definitely my hammer, I swear. Get it for me and don't ask questions"
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Dildo,
            Description = "That son of a bitch Chris. He borrowed my wifes back massager and lost it. She keeps yelling at me about how it's very personal to her. I guess I need it found."
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Screwdriver,
            Description = "I dropped my screwdriver around here somewhere. I need it to fix things."
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Battery,
            Description = "I need one more battery for my RC cars. I don't want to go to the store so you could just steal one or something..."
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Keys,
            Description = "Oh shucks, I can't get to work without my keys. WHATEVER WILL I DO."
        });
    }

    public Quest GetNewQuest()
    {
        Quest quest = null;
        bool loop = true;
        while (loop)
        {
            quest = Quests[Random.Range(0, Quests.Count)];

            if (!QuestItemCheck(quest.MissingItem))
                loop = false;
        }

        Quests.Remove(quest);
        CurrentQuests.Add(quest);
        
        return quest;
    }

    private bool QuestItemCheck(Item.ItemType item)
    {
        foreach(var questItem in CurrentQuests)
        {
            if (questItem.MissingItem == item)
                return true;
        }

        return false;
    }

    public void PlaceRandomItems()
    {
        for(int i = 0; i < RandomItemCount; i++)
        {
            Debug.Log($"RandomItem: { i }");
            bool loop = true;
            Quest quest = null;

            while (loop)
            {
                quest = Quests[Random.Range(0, Quests.Count)];
                if (!QuestItemCheck(quest.MissingItem))
                    loop = false;
            }

            PlaceQuestItem(quest);
        }
    }

    public void PlaceQuestItem(Quest quest)
    {
        var point = SpawnPointManager.Instance.GetSpawn();
        var item = Instantiate(Resources.Load(GameManager.Instance.SpriteLibrary.GetSpriteDetails(quest.MissingItem).PrefabPath), point);
    }

    public void CompleteQuest(Quest quest)
    {
        quest.Complete();
        GameManager.Instance.QuestUpdatedEvent.Invoke();
    }
}
