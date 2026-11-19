using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo_GUI : MonoBehaviour
{
    [SerializeField] public Image[] healthImages;
    [SerializeField] public Sprite heartFull;
    [SerializeField] public Sprite heartEmpty;
    
    [SerializeField] public Image[] bombImages;
    [SerializeField] public Sprite bombFull;
    [SerializeField] public Sprite bombEmpty;

    public void UpdateAllInfos(int health, int bombNbr)
    {
        UpdateHealth(health);
        UpdateBomb(bombNbr);
    }

    public void UpdateHealth(int health)
    {
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i <= health - 1)
            {
                healthImages[i].sprite = heartFull;
            }
            else
            {
                healthImages[i].sprite = heartEmpty;
            }
        }
    }

    public void UpdateBomb(int bombNbr)
    {
        for (int i = 0; i < bombImages.Length; i++)
        {
            if (i <= bombNbr - 1)
            {
                bombImages[i].sprite = bombFull;
            }
            else
            {
                bombImages[i].sprite = bombEmpty;
            }
        }
    }
}
