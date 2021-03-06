﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class BoardManager : MonoBehaviour
{
    public Quest Quest1;
    public Quest Quest2;
    public Quest Quest3;
    private BoardPost[] posts;
    public Canvas Instructions;
    public Canvas Win;
    public Canvas Inventory;

    private void Start()
    {
        GameManager.Instance.QuestUpdatedEvent.AddListener(UpdateQuests);
        posts = GetComponentsInChildren<BoardPost>();

        Quest1 = QuestManager.Instance.GetNewQuest();
        Quest1.ReturnLocation = ReturnLocation.ReturnLocations.One;
        QuestManager.Instance.PlaceQuestItem(Quest1);

        Quest2 = QuestManager.Instance.GetNewQuest();
        Quest2.ReturnLocation = ReturnLocation.ReturnLocations.Two;
        QuestManager.Instance.PlaceQuestItem(Quest2);

        Quest3 = QuestManager.Instance.GetNewQuest();
        Quest3.ReturnLocation = ReturnLocation.ReturnLocations.Three;
        QuestManager.Instance.PlaceQuestItem(Quest3);

        // post 1
        (posts[0]).Image.sprite = GameManager.Instance.SpriteLibrary.GetSpriteDetails(Quest1.MissingItem).Sprite;
        (posts[0]).Description.text = Quest1.Description;
        (posts[0]).Done.enabled = false;

        // post 2
        (posts[1]).Image.sprite = GameManager.Instance.SpriteLibrary.GetSpriteDetails(Quest2.MissingItem).Sprite;
        (posts[1]).Description.text = Quest2.Description;
        (posts[1]).Done.enabled = false;

        // post 3
        (posts[2]).Image.sprite = GameManager.Instance.SpriteLibrary.GetSpriteDetails(Quest3.MissingItem).Sprite;
        (posts[2]).Description.text = Quest3.Description;
        (posts[2]).Done.enabled = false;

        QuestManager.Instance.PlaceRandomItems();
    }

    private void UpdateQuests()
    {
        Debug.Log("BoardManager--In UpdateQuests");
        (posts[0]).Done.enabled = Quest1.Completed;
        (posts[1]).Done.enabled = Quest2.Completed;
        (posts[2]).Done.enabled = Quest3.Completed;

        WinCheck();
    }

    public void WinCheck()
    {
        if(Quest1.Completed && Quest2.Completed && Quest3.Completed)
        {
            GameManager.Instance.DidWin = true;
            Instructions.enabled = false;
            Inventory.enabled = false;
            Win.enabled = true;
        }
    }
}
