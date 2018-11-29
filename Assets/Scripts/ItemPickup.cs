using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
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
        playerInv = playerObject.GetComponent<Inventory>();
        stats = playerObject.GetComponent<PlayerStats>();

        text = GetComponentInChildren<TextMesh>();

        itemName = ItemData.CreateItem(itemID).Name;
        itemDesc = ItemData.CreateItem(itemID).Description;

        text.text = itemName;

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInv.inv.Add(ItemData.CreateItem(itemID));
            stats.health += ItemData.CreateItem(itemID).Health;
            
            stats.damage += ItemData.CreateItem(itemID).Damage;
            stats.attackRange += ItemData.CreateItem(itemID).Range;

            if (ItemData.CreateDrop(itemID).Type == ItemType.Consumable)
            {
                other.GetComponent<PlayerManager>().ChangeHealth(ItemData.CreateDrop(itemID).HealAmount);
            }

            player.UpdateStats();

            other.GetComponent<PlayerManager>().ChangeHealth(ItemData.CreateItem(itemID).Health);

            Destroy(gameObject);
        }
    }

    public void UpdateItem(int itemNum)
    {
        itemID = itemNum;
        itemName = ItemData.CreateItem(itemID).Name;
        itemDesc = ItemData.CreateItem(itemID).Description;

        text.text = itemName;
    }
}
