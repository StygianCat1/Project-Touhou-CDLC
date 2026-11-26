using Script.Player;
using Script.Player.Capacity.Enum;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterKitChoice : MonoBehaviour
{

    public void chooseFirstKitToGame(string levelName)
    {
        Save.kitChoosed = KitChoosed.FirstKit;
        Save.activeCapacityName = CapacityName.FasterShoot;
        Save.equipmentCapacity1Name = CapacityName.LongerInvulnerability;
        Save.equipmentCapacity2Name = CapacityName.ArmorProtection;
        Save.passiveCapacity1Name = CapacityName.PowerGain;
        Save.passiveCapacity2Name = CapacityName.None;
        SceneManager.LoadScene(levelName);
    }

    public void chooseSecondKitToGame(string levelName)
    {
        Save.kitChoosed = KitChoosed.SecondKit;
        Save.activeCapacityName = CapacityName.MegaProjectile;
        Save.equipmentCapacity1Name = CapacityName.FasterMovementSpeed;
        Save.equipmentCapacity2Name = CapacityName.None;
        Save.passiveCapacity1Name = CapacityName.Gain3Heart;
        Save.passiveCapacity2Name = CapacityName.RepetitiveBombGain;
        SceneManager.LoadScene(levelName);
    }
    
    
    
    
}
