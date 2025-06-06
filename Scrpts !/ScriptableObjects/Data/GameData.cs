using UnityEngine;

[CreateAssetMenu(menuName = "Data/Game Data")]
public class GameData : ScriptableObject
{
    public int currentSunlight = 0;
    public int currentCoins = 0;
    public int currentRound = 0;
    public bool isInRound = false;
}
