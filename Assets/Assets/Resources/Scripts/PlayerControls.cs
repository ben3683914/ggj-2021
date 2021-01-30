using UnityEngine;
using System.Collections;

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

    // Update is called once per frame
    void Update()
    {
        Move();
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
    }
}
