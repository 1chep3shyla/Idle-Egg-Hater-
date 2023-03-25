using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public double allDamage;
    public double allDPS;
    public double allMoney;
    public double allDiamond;
    public Text[] stats; // 0 - damage, 1 - dps, 2 - money
    public GameObject[] panels;
    public Up[] upper;
    public UpRare[] upperRare;
    public Egg eggStats;
    public GameObject[] vfx;
    public GameObject dmgText;
    private Vector2 touchPosition;
    private int touchCount;
    private float dpsTime;
    public Color[] colors;
    public int[] materials;
    public GameObject CanvasSpawn;
    public DragonController stat;  // 0 - dmg, 1- dps, 2 - earn, 3 - critDMG, 4 - critChance, 5 - dropChance

    void Update()
    {
        dpsTime += Time.deltaTime;
        if (dpsTime >= 0.1f)
        {
            eggStats.curHp -= allDPS;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Ended)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            }

        }
        if (stat.allStatsAdd[0] != 0)
        {
            allDamage = (upper[0].Damage + upper[1].Damage + upper[2].Damage + upper[3].Damage + upper[4].Damage)* stat.allStatsAdd[0];
        }
        else
        {
            allDamage = (upper[0].Damage + upper[1].Damage + upper[2].Damage + upper[3].Damage + upper[4].Damage);
        }
        if (stat.allStatsAdd[1] != 0)
        {
            allDPS = (upper[0].DPS + upper[1].DPS + upper[2].DPS + upper[3].DPS + upper[4].DPS) / 10 * stat.allStatsAdd[1];
        }
        else
        {
            allDPS = (upper[0].DPS + upper[1].DPS + upper[2].DPS + upper[3].DPS + upper[4].DPS) / 10;
        }
        stats[0].text = "DMG:" + FormatMoney(allDamage); 
        stats[1].text = "DPS:" + FormatMoney(allDPS); 
        stats[2].text = "" + FormatMoney(allMoney);
        stats[3].text = "" + FormatMoney(allDiamond);
        for (int i = 2; i < upper.Length; i++)
        {
            if (upper[i-1].Level >=1)
            {
                panels[i].SetActive(true);
            }
        }
        for (int o = 1; o < upper.Length; o++)
        {
            if (upper[o].buyIs == false)
            {
                panels[o].GetComponent<Image>().color = colors[0];
            }
            else
            {
                panels[o].GetComponent<Image>().color = colors[1];
            }
        }
    }
    static string[] names = { "", "K", "M", "B", "T", "q", "Q","K+", "M+", "B+", "T+", "q+", "Q+" };

    static string FormatMoney(double digit)
    {
        int n = 0;
        while (n + 1 < names.Length && digit >= 1000.0)
        {
            digit /= 1000.0;
            n++;
        }
        return string.Format("{0}{1}", digit.ToString("0"), names[n]);
    }
    public void AttackEgg()
    {
        int randomVFX = Random.Range(0, 3);

        GameObject vfxNew = Instantiate(vfx[randomVFX], touchPosition, vfx[randomVFX].transform.rotation);
        GameObject attackText = Instantiate(dmgText, touchPosition, dmgText.transform.rotation);
        attackText.transform.SetParent(CanvasSpawn.transform);
        attackText.transform.InverseTransformPoint(touchPosition);
        attackText.transform.localScale = new Vector3(1, 1, 1);
        int random = Random.Range(0, 2);
        int randomCrit = Random.Range(0, 5000);
        if (stat.allStatsAdd[4] != 0)
        {
            if (randomCrit > 5000 - (5 * stat.allStatsAdd[4]))
            {
                if (stat.allStatsAdd[3] != 0)
                {
                    eggStats.curHp -= allDamage * (3* stat.allStatsAdd[3]);
                    attackText.GetComponent<Text>().text = "" + FormatMoney(allDamage * (3 * stat.allStatsAdd[3]));
                }
                else
                {
                    eggStats.curHp -= allDamage * 3;
                    attackText.GetComponent<Text>().text = "" + FormatMoney(allDamage * 3);
                }
                attackText.transform.localScale = new Vector3(2, 2, 1);
                attackText.GetComponent<Text>().color = colors[2];

            }
            else
            {
                eggStats.curHp -= allDamage;
                attackText.GetComponent<Text>().text = "" + FormatMoney(allDamage);
            }
        }
        else
        {
            if (randomCrit > 5000 - 5)
            {
                if (stat.allStatsAdd[3] != 0)
                {
                    eggStats.curHp -= allDamage * (3 * stat.allStatsAdd[3]);
                    attackText.GetComponent<Text>().text = "" + FormatMoney(allDamage * (3 * stat.allStatsAdd[3]));
                }
                else
                {
                    eggStats.curHp -= allDamage * 3;
                    attackText.GetComponent<Text>().text = "" + FormatMoney(allDamage * 3 );
                }
                attackText.transform.localScale = new Vector3(2, 2, 1);
                attackText.GetComponent<Text>().color = colors[2];

            }
            else
            {
                eggStats.curHp -= allDamage;
                attackText.GetComponent<Text>().text = "" + FormatMoney(allDamage);
            }
        }

        if (random == 0)
        {
            eggStats.animator.Play("egg_hit_1");
        }
        else if (random == 1)
        {
            eggStats.animator.Play("egg_hit_2");
        }
    }

    public void donatRed()
    {
        allDiamond += 500;
    }
    public void donatFosPack()
    {
        for (int i = 0; i < upperRare.Length; i++)
        {
            upperRare[i].count += 100;
        }
    }
    public void donatEpic()
    {
        allDiamond += 200;
        for (int i = 0; i < upperRare.Length; i++)
        {
            upperRare[i].count += 200;
        }
    }
}
