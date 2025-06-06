using UnityEngine;

[System.Serializable]
public class WeaponItem
{
    public int clipSize;
    public int currentAmmo;
    public GameObject weaponPrefab;
    public float damage;
    public float attackSpeed;
    public AudioClip attackSound;
}
