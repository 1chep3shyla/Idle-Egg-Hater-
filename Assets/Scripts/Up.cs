using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Up : MonoBehaviour
{
    public long Damage;
    public long BaseDamage;
    public int Level;
    public long DPS;
    public long Cost;
    public long BaseCost;
    public string Name;
    public int fiver;
    public Stats player;
    public Text[] textAll; // 0 - name, 1 - cost, 2 - damage,3 - level, 4 - dps
    public Image icon;
    public Sprite[] allSprites;
    public Sprite[] allUpSprites;
    public bool DPSIs;
    public bool buyIs;

    void Update()
    {
        if (DPSIs == true)
        {
            if (Level < 50)
            {
                int[] nullIs = new int[1];
                for (int i = 0; i < nullIs.Length; i++)
                {
                    if (player.upperRare[i].Damage == 0)
                    {
                        nullIs[i] = 1;
                    }
                    else
                    {
                        nullIs[i] = player.upperRare[i].Damage;
                    }
                }
                DPS = Damage / 10 * nullIs[0];
            }
            else if (Level >= 50 && Level < 100)
            {
                int[] nullIs = new int[2];
                for (int i = 0; i < nullIs.Length; i++)
                {
                    if (player.upperRare[i].Damage == 0)
                    {
                        nullIs[i] = 1;
                    }
                    else
                    {
                        nullIs[i] = player.upperRare[i].Damage;
                    }
                }
                DPS = Damage / 10 * nullIs[0] * nullIs[1];
            }
            else if (Level >= 100 && Level < 150)
            {
                int[] nullIs = new int[3];
                for (int i = 0; i < nullIs.Length; i++)
                {
                    if (player.upperRare[i].Damage == 0)
                    {
                        nullIs[i] = 1;
                    }
                    else
                    {
                        nullIs[i] = player.upperRare[i].Damage;
                    }
                }
                DPS = Damage / 10 * nullIs[0] * nullIs[1] * nullIs[2];
            }
            else if (Level >= 150 && Level < 250)
            {
                int[] nullIs = new int[4];
                for (int i = 0; i < nullIs.Length; i++)
                {
                    if (player.upperRare[i].Damage == 0)
                    {
                        nullIs[i] = 1;
                    }
                    else
                    {
                        nullIs[i] = player.upperRare[i].Damage;
                    }
                }
                DPS = Damage / 10 * nullIs[0] * nullIs[1] * nullIs[2] * nullIs[3];
            }
            else if (Level >= 250)
            {
                int[] nullIs = new int[5];
                for (int i = 0; i < nullIs.Length; i++)
                {
                    if (player.upperRare[i].Damage == 0)
                    {
                        nullIs[i] = 1;
                    }
                    else
                    {
                        nullIs[i] = player.upperRare[i].Damage;
                    }
                }
                DPS = Damage / 10 * nullIs[0] * nullIs[1] * nullIs[2] * nullIs[3] * nullIs[4];
            }
        }
        textAll[0].text = "" + Name;
        textAll[1].text = "" + FormatMoney(Cost);
        textAll[2].text = "DMG:" + FormatMoney(Damage);
        textAll[3].text = "LeveL:" + Level;
        if (textAll.Length == 5)
        {
            textAll[4].text = "DPS" + FormatMoney(DPS);
        }
        if (Level < 50 && player.upperRare[0].Level == 0)
        {
            icon.sprite = allSprites[0];
        }
        else if (Level >= 50 && Level < 100 && player.upperRare[1].Level == 0)
        {
            icon.sprite = allSprites[1];
        }
        else if (Level >= 100 && Level < 150 && player.upperRare[2].Level == 0)
        {
            icon.sprite = allSprites[2];
        }
        else if (Level >= 150 && Level < 250 && player.upperRare[3].Level == 0)
        {
            icon.sprite = allSprites[3];
        }
        else if (Level >= 250 && player.upperRare[4].Level == 0)
        {
            icon.sprite = allSprites[4];
        }

        else if (Level < 50 && player.upperRare[0].Level > 0)
        {
            icon.sprite = allUpSprites[0];
        }
        else if (Level >= 50 && Level < 100 && player.upperRare[1].Level > 0)
        {
            icon.sprite = allUpSprites[1];
        }
        else if (Level >= 100 && Level < 150 && player.upperRare[2].Level > 0)
        {
            icon.sprite = allUpSprites[2];
        }
        else if (Level >= 150 && Level < 250 && player.upperRare[3].Level > 0)
        {
            icon.sprite = allUpSprites[3];
        }
        else if (Level >= 250 && player.upperRare[4].Level > 0)
        {
            icon.sprite = allUpSprites[4];
        }
    }
    public void Click()
    {
        if (Level == 0)
        {
            buy();
        }
        else
        {
            UpLevel();
        }
    }
    public void buy()
    {
        if (player.allMoney >= Cost)
        {
            Level++;
            Damage = BaseDamage;
            player.allMoney -= Cost;
            buyIs = true;
        }
    }
    public void UpLevel()
    {
        if (player.allMoney >= Cost)
        {
            player.allMoney -= Cost;
            Level++;
            if (fiver < 49)
            {
                Damage += BaseDamage * Level;
                fiver++;
            }
            else if (fiver == 49)
            {
                Damage += BaseDamage * Level;
                BaseCost += Level / 2;
                Damage *= 2;
                fiver = 0;
            }
            Cost += Level * BaseCost;
            if (Level < 50 && player.upperRare[0].Level ==0)
            {
                icon.sprite = allSprites[0];
            }
            else if (Level >= 50 && Level < 100 && player.upperRare[1].Level == 0)
            {
                icon.sprite = allSprites[1];
            }
            else if (Level >= 100 && Level < 150 && player.upperRare[2].Level == 0)
            {
                icon.sprite = allSprites[2];
            }
            else if (Level >= 150 && Level < 250 && player.upperRare[3].Level == 0)
            {
                icon.sprite = allSprites[3];
            }
            else if (Level >= 250 && player.upperRare[4].Level == 0)
            {
                icon.sprite = allSprites[4];
            }

            else if (Level < 50 && player.upperRare[0].Level > 0)
            {
                icon.sprite = allUpSprites[0];
            }
            else if (Level >= 50 && Level < 100 && player.upperRare[1].Level > 0)
            {
                icon.sprite = allUpSprites[1];
            }
            else if (Level >= 100 && Level < 150 && player.upperRare[2].Level > 0)
            {
                icon.sprite = allUpSprites[2];
            }
            else if (Level >= 150 && Level < 250 && player.upperRare[3].Level > 0)
            {
                icon.sprite = allUpSprites[3];
            }
            else if (Level >= 250 && player.upperRare[4].Level > 0)
            {
                icon.sprite = allUpSprites[4];
            }

        }

    }
    static string[] names = { "", "K", "M", "B", "T", "q", "Q", };

    static string FormatMoney(decimal digit)
    {
        int n = 0;
        while (n + 1 < names.Length && digit >= 1000m)
        {
            digit /= 1000m;
            n++;
        }
        return string.Format("{0}{1}", digit.ToString("0"), names[n]);
    }
}
