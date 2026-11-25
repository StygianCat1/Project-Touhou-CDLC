using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo_GUI : MonoBehaviour
{
    //Ref to an array of image
    [SerializeField] public Image[] healthImages;
    //Sprite of a full heart
    [SerializeField] public Sprite heartFull;
    //sprite of an empty heart
    [SerializeField] public Sprite heartEmpty;
    
    //Ref to an array of image
    [SerializeField] public Image[] bombImages;
    //Sprite of a full bomb
    [SerializeField] public Sprite bombFull;
    //sprite of a full bomb
    [SerializeField] public Sprite bombEmpty;

    
    //Update all infos (called by Stats)
    public void UpdateAllInfos(int health, int bombNbr)
    {
        UpdateHealth(health);
        UpdateBomb(bombNbr);
    }

    //Update the health
    public void UpdateHealth(int health)
    {
        //For how much health the character has
        for (int i = 0; i < healthImages.Length; i++)
        {
            //If the index is inferior or equal
            if (i <= health - 1)
            {
                //Set full image
                healthImages[i].sprite = heartFull;
            }
            else
            {
                //Set empty image
                healthImages[i].sprite = heartEmpty;
            }
        }
    }

    //update the bombs
    public void UpdateBomb(int bombNbr)
    {
        //For how much bomb the character has
        for (int i = 0; i < bombImages.Length; i++)
        {
            //If the index is inferior or equal
            if (i <= bombNbr - 1)
            {
                //Set full image
                bombImages[i].sprite = bombFull;
            }
            else
            {
                //Set empty image
                bombImages[i].sprite = bombEmpty;
            }
        }
    }
}
