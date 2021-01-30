using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraFollow : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        GameManager.Instance.InventoryChangedEvent.AddListener(SwagMoney);
    }

    private void Update()
    {
        var playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, -1f);
    }

    void SwagMoney()
    {
        Debug.Log("dope dawg");
    }
}
