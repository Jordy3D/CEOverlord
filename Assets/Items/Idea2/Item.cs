using UnityEngine;

public class Item
{
    private int _id;
    private string _name;
    private string _description;

    private ItemType _type;

    private int _damage;
    private float _moveSpeed;
    private int _health;

    private Texture2D _icon;
    private string _mesh;

    public Item()
    {
        _id = 0;
        _name = "A Secret";
        _description = "It's a secret to everyone";

        _type = ItemType.Miscellaneous;

        _mesh = "MeshName";
    }

    public Item(int iD, string name, string description, ItemType type, int damage, int moveSpeed, int health, Texture2D icon, string mesh)
    {
        _id = iD;
        _name = name;
        _description = description;
        _type = type;
        _damage = damage;
        _moveSpeed = moveSpeed;
        _health = health;
        _icon = icon;
        _mesh = mesh;
    }

    #region Properties
    public int ID
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }

    public ItemType Type
    {
        get
        {
            return _type;
        }
        set
        {
            _type = value;
        }
    }

    
    public int Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }
    public float MoveSpeed
    {
        get
        {
            return _moveSpeed;
        }
        set
        {
            _moveSpeed = value;
        }
    }

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }

    public Texture2D Icon
    {
        get
        {
            return _icon;
        }
        set
        {
            _icon = value;
        }
    }
    public string Mesh
    {
        get
        {
            return _mesh;
        }
        set
        {
            _mesh = value;
        }
    }

    #endregion
}

public enum ItemType
{
    Consumable,
    Weapon,
    Money,
    Quest,
    Miscellaneous
}