using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CEOverlord
{
    public class GlovePickup : MonoBehaviour
    {
        public int itemID = 0;

        GameObject playerObject;
        GameObject gloveContainer;
        CharacterMovement player;
        Inventory playerInv;
        PlayerAttack playerGlove;

        GloveHolder holder;
        Glove[] gloves;
        //PlayerStats stats;

        //TextMesh text;

        //[SerializeField] private string itemName;
        //[SerializeField] private string itemDesc;

        void Start()
        {
            playerObject = GameObject.FindGameObjectWithTag("Player");
            gloveContainer = playerObject.transform.GetChild(0).gameObject;

            player = playerObject.GetComponent<CharacterMovement>();
            playerInv = playerObject.GetComponent<Inventory>();
            playerGlove = playerObject.GetComponent<PlayerAttack>();

            holder = gloveContainer.GetComponent<GloveHolder>();

            //stats = playerObject.GetComponent<PlayerStats>();

            //text = GetComponentInChildren<TextMesh>();

            //itemName = ItemData.CreateItem(itemID).Name;
            //itemDesc = ItemData.CreateItem(itemID).Description;

            //text.text = itemName;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                playerInv.inv.Add(ItemData.CreateGlove(itemID));

                gloves = holder.gloves;
                //holder.gloves = gloves[itemID];

                playerGlove.playerGlove = holder.gloves[itemID];

                Destroy(gloveContainer.GetComponent<Glove>());
                //gloveContainer.AddComponent<Glove>();

                Destroy(gameObject);
            }
        }
    } 
}
