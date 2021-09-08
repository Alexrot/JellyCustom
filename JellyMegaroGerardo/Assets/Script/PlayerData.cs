using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    
    public static int coin;
    public Material[] skins;
    public static bool changeSkin=false;
    public static Material skin;
    public static int skinBuff;

    private void Start()
    {
        skin = skins[0];
    }
    public void Buy(int price)
    {
        coin -= price;
    }

    public void ChangeSkin(int selectedSkin)
    {
        switch (selectedSkin)
        {
            case 3:
                if (BumpAndCollision.point == 1)
                {
                    SummonBuff(selectedSkin);
                }
                    break;
            case 4:
                if (BumpAndCollision.point == 5)
                {
                    SummonBuff(selectedSkin);
                }
                break;
            case 5:
                if (BumpAndCollision.point == 10)
                {
                    SummonBuff(selectedSkin);
                }
                break;
            default:
                SummonBuff(selectedSkin);
                break;
        }
    }

    void SummonBuff(int buff)
    {
        skin = skins[buff];
        skinBuff = buff;
        BumpAndCollision.ChangeSkin();
    }

}
