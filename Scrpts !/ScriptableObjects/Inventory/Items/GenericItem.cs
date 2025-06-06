using UnityEngine;

[CreateAssetMenu(menuName = "Items/Generic Item")]
public class GenericItem : ScriptableObject
{
    public string itemName = "Generic Item";
    public Sprite itemIcon = null;
    public int price = 0;

    [Header("Item Type")]
    public ItemType itemType = ItemType.None;
    
    [Tooltip("Only fill ONE of these! This item should be either a weapon OR a placeable.")]
    public WeaponItem weaponItem;
    public PlaceableItem placeableItem;
}

public enum ItemType
{
    None,
    Weapon,
    Placeable,
}
