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

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Phone,
            Description = "Little suzie lost her phone again. I swear this is the last phone she's getting. She should probably fine it."
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Phone,
            Description = "I'm Suzie, I lost my phone and my parents refuse to buy me a new one. If you see it could you return it"
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Phone,
            Description = "I can't afford another phone, I'll give you a peanut if you find mine"
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Basketball,
            Description = "Dude bro, I need my basketball back"
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Basketball,
            Description = "If someone finds a basketball, it's Johnnie's. He's not going to get into college with his grades, so this is kind of needed..."
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Baseball,
            Description = "Roger is going to be a STAR!11! He needs his baseball to shine though. Damn kid would lose his ass if it wasn't attached."
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Hammer,
            Description = "It's hammer time..seriously though. I need my hammer...STEVE!"
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Baseball,
            Description = "I lost my signed Babe Ruth baseball. Please don't steal it and return it."
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Phone,
            Description = "Cracked my phone, need my old one, but I threw it somewhere"
        });

        Quests.Add(new Quest()
        {
            MissingItem = Item.ItemType.Keys,
            Description = "locked out of my house, can you look around my keys"
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
