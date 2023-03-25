using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpRare : MonoBehaviour
{
    public int Damage;
    public int count;
    public int Level;
    public int Cost;
    public Stats player;
    public Text[] textAll; // 0 - cost, 1 - damage, 2 - level, 3 - count
    public bool buyIs;
    public int NameF;
    public Image panelImage;
    void Update()
    {
        count = player.materials[NameF];
        textAll[0].text = "" + FormatMoney(Cost);
        textAll[1].text = "DMG:x" + FormatMoney(Damage);
        textAll[2].text = "LeveL:" + Level;
        textAll[3].text = "" + FormatMoney(count);
        if (buyIs == false)
        {
            panelImage.color = player.colors[0];
        }
        else
        {
            panelImage.color = player.colors[1];
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
        if (player.materials[NameF] >= Cost)
        {
            Level++;
            Damage += 2;
            player.materials[NameF] -= Cost;
            buyIs = true;
        }
    }
    public void UpLevel()
    {
        if (player.materials[NameF] >= Cost)
        {
            player.materials[NameF] -= Cost;
            Damage += 1;
            Level++;
            Cost += Cost;
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
