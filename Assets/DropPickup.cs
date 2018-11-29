using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPickup : MonoBehaviour
{
    public int itemID = 0;

    GameObject playerObject;
    PlayerManager player;
    Inventory playerInv;
    PlayerStats stats;

    TextMesh text;

    [SerializeField] private string itemName;
    [SerializeField] private string itemDesc;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<PlayerManager>();

        text = GetComponentInChildren<TextMesh>();

        itemName = ItemData.CreateDrop(itemID).Name;
        itemDesc = ItemData.CreateDrop(itemID).Description;

        text.text = itemName;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerManager>().ChangeHealth(ItemData.CreateDrop(itemID).HealAmount);

            Destroy(gameObject);
        }
    }

    public void UpdateItem(int itemNum)
    {
        itemID = itemNum;
        itemName = ItemData.CreateDrop(itemID).Name;
        itemDesc = ItemData.CreateDrop(itemID).Description;

        text.text = itemName;
    }
}
