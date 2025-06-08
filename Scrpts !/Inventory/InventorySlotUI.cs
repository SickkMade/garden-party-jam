

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countText;
    [SerializeField]
    private Image spriteImage;
    [SerializeField]
    private GameObject countParent;
    [SerializeField]
    private Image selectedBackground;
    public void SetSlotData(Sprite sprite, int quantity)
    {
        UpdateSprite(sprite);
        UpdateText(quantity.ToString());
    }

    public void SetSelectedBackgroundActive(bool isActive)
    {
        selectedBackground.enabled = isActive;
    }

    private void UpdateSprite(Sprite sprite)
    {
        if (sprite == null)
        {
            spriteImage.enabled = false;
        }
        else
        {
            spriteImage.enabled = true;
            spriteImage.sprite = sprite;
        }
    }
    private void UpdateText(string text)
    {
        if (text == "0" || !spriteImage.enabled) //if sprite is off (ie no item)
        {
            countParent.SetActive(false);
        }
        else
        {
            countParent.SetActive(true);
            countText.text = text;
        }
    }
}
