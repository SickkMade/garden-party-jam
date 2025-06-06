using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerData {
    public float health;
    public Vector3 position;
    public int coins;
    public int batteries;
    public float maxHealth;
    public float currentAmmo;
    public float maxAmmo;
    public float NormalizedHealth => health / maxHealth;
}


public class PlayerManager : MonoBehaviour
{
    // Static instance of GameManager
    public static PlayerManager Instance { get; private set; }
    public int currentIndex = 0;
    public PlayerData playerData = new();


    public BasicCharacterController PlayerController => _playerController;
    BasicCharacterController _playerController;


    // why is this so well commented it looks ai :sob: I SWEAR I WROTE THIS LOL
    private void Awake()
    {
        // Check if Instance already exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else
        {
            Destroy(gameObject); // Enforce singleton pattern
        }

    }
}