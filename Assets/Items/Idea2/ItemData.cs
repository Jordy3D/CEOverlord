﻿using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int ItemID)
    {
        int id = ItemID;
        string name = "";
        string description = "";

        ItemType type = ItemType.Miscellaneous;

        int damage = 0;
        float moveSpeed = 0;
        int health = 0;

        string icon = "";
        string mesh = "";


        switch (ItemID)
        {
            #region Consumables 0-99
            case 0:
                #region Apple
                name = "Apple";
                description = "Doesn't like its consumers";

                type = ItemType.Consumable;

                damage = 0;
                moveSpeed = 0;
                health = 1;

                icon = "Apple_Icon";
                mesh = "Apple_Mesh";
                break;
            #endregion
            case 1:
                #region Paopu
                name = "Paopu";
                description = "For that special someone";

                type = ItemType.Consumable;

                damage = 0;
                moveSpeed = 0;
                health = 2;

                icon = "Paopu_Icon";
                mesh = "Paopu_Mesh";
                break; 
            #endregion
            case 2:
                #region Gummi
                name = "Questionable Gummi Worm";
                description = "Not the most convincing fake";

                type = ItemType.Consumable;

                damage = 0;
                moveSpeed = 0;
                health = 3;

                icon = "Gummi_Icon";
                mesh = "Gummi_Mesh";
                break;
            #endregion
            #endregion

            #region Weapons 200-299
            case 200:
                #region WoodenSword
                name = "Wooden Sword";
                description = "Is that a sword in your pocket or are you happy to see me?";

                type = ItemType.Weapon;

                damage = 5;
                moveSpeed = 0;
                health = 0;

                icon = "Sword_Wood_Icon";
                mesh = "Sword_Wood_Mesh";
                break;
            #endregion

            case 201:
                #region IronSword
                name = "Iron Sword";
                description = "Doubtful this was pulled from a stone";

                type = ItemType.Weapon;

                damage = 25;
                moveSpeed = 0;
                health = 0;

                icon = "Sword_Iron_Icon";
                mesh = "Sword_Iron_Icon";
                break;
            #endregion

            case 202:
                #region Stick
                name = "Stick";
                description = "It's a stick.";

                type = ItemType.Weapon;

                damage = 0;
                moveSpeed = 0;
                health = 0;

                icon = "Stick_Icon";
                mesh = "Stick_Mesh";
                break;
            #endregion
            #endregion

            #region Miscellaneous 400-499
            case 400:
                #region Money
                name = "Money";
                description = "Not capped to 10000.";

                type = ItemType.Miscellaneous;

                damage = 0;
                moveSpeed = 0;
                health = 0;

                icon = "Money_Icon";
                mesh = "Money_Mesh";
                break;
            #endregion

            case 401:
                #region Loss
                name = "Loss Fragment";
                description = " | |I \n|| |_";

                type = ItemType.Quest;

                damage = 0;
                moveSpeed = 0;
                health = 0;

                icon = "Loss_Icon";
                mesh = "Loss_Icon";
                break;
            #endregion

            case 402:
                #region Content
                name = "Content";
                description = "On-disc content? Well I never!";

                type = ItemType.Miscellaneous;

                damage = 0;
                moveSpeed = 0;
                health = 0;

                icon = "Content_Icon";
                mesh = "Content_Mesh";
                break;
            #endregion

            case 403:
                #region Content
                name = "Tie";
                description = "Every budding businessman needs one.";

                type = ItemType.Miscellaneous;

                damage = 0;
                moveSpeed = 0;
                health = 0;

                icon = "Tie_Icon";
                mesh = "Tie_Mesh";
                break;
            #endregion

            #endregion

            default:
                #region Default
                name = "Bad Egg";
                description = "The 'Bad' describes the person with it, not the egg itself.";

                type = ItemType.Miscellaneous;

                damage = 0;
                moveSpeed = 0;
                health = 0;

                icon = "Angery_Icon";
                mesh = "Angery_Mesh";
                break;
                #endregion
        }

        //Item temp = new Item();
        Item temp = new Item
        {
            ID = ItemID,
            Name = name,
            Description = description,

            Type = type,

            Damage = damage,
            MoveSpeed = moveSpeed,

            Health = health,

            Icon = Resources.Load("Icons/" + icon) as Texture2D,
            Mesh = mesh
        };

        return temp;
    }
}
