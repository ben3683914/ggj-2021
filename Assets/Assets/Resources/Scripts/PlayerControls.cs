using UnityEngine;
using System.Collections;
using static ReturnLocation;

public class PlayerControls : MonoBehaviour
{
    public float Speed;
    private Inventory inventory;
    private Player player;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (GameManager.Instance.DidWin)
        {
            if (Input.GetButton("Action"))
            {
                Debug.Log("Quitting...you quitter");
                Application.Quit();
            }
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");
        player.Movement = new Vector2(Speed * inputX, Speed * inputY);
        player.Movement *= Time.deltaTime;
        transform.Translate(player.Movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.DidWin)
            return;

        if (collision.tag == "Item")
        {
            var item = collision.GetComponent<Item>();
            if (item.Type == Item.ItemType.None || item.NextAllowedPickTime > Time.time)
                return;

            Debug.Log("got item");
            if (inventory.AddItem(item.Type))
            {
                Destroy(collision.gameObject);
            }
        }
        else if(collision.tag == "ReturnLocation")
        {
            var location = collision.GetComponent<ReturnLocation>();
            foreach(var quest in QuestManager.Instance.CurrentQuests)
            {
                bool isFound = false;
                if (!isFound && player.Inventory.Slot1 == quest.MissingItem && location.Location == quest.ReturnLocation)
                {
                    isFound = true;
                    QuestManager.Instance.CompleteQuest(quest);
                    player.Inventory.DestroySlot(1);
                }

                if (!isFound && player.Inventory.Slot2 == quest.MissingItem && location.Location == quest.ReturnLocation)
                {
                    isFound = true;
                    QuestManager.Instance.CompleteQuest(quest);
                    player.Inventory.DestroySlot(2);
                }
            }
        }
    }
}
