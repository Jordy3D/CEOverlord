using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenItem : MonoBehaviour
{

    int[] itemNums;
    int itemNumber;
    public ItemPickup roomItem;

    public bool isSpawned;

    private void Start()
    {
        isSpawned = false;
        itemNums = GameObject.FindGameObjectWithTag("ItemMaster").GetComponent<ItemArrayMaster>().itemNums;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" && isSpawned == false)
        {
            isSpawned = true;
            GenerateItem();
        }
    }

    void GenerateItem()
    {
        itemNumber = itemNums[Mathf.RoundToInt(Random.Range(0f, itemNums.Length - 1))];
        roomItem.UpdateItem(itemNumber);
    }
}
