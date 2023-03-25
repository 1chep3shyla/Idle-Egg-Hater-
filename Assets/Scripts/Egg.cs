using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Egg : MonoBehaviour
{
    public Sprite[] eggSprite;
    public int curLevel;
    public int floor;
    public double HP = 10;
    public double curHp = 10;
    public double MoneyGive;
    public string[] eggName;
    public Animator animator;
    public Slider slider;
    public Text hpText;
    public Text nameText;
    public Text floorText;
    public Text levelText;
    public Stats player;
    public GameObject[] needMore;
    public GameObject[] unlock;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (HP > 10000000000000)
        {
            slider.value = (float)Math.Log10(curHp);
            slider.maxValue = (float)Math.Log10(HP);
        }
        else
        {
            slider.value = Convert.ToSingle(curHp);
            slider.maxValue = Convert.ToSingle(HP);
        }
        hpText.text = "" + FormatMoney(curHp);
        floorText.text = "" + floor +"/10";
        levelText.text = "" + curLevel;
        if (curLevel >= 100)
        {
            needMore[0].SetActive(false);
            unlock[0].SetActive(true);
        }
        if (curLevel >= 250)
        {
            needMore[1].SetActive(false);
            unlock[1].SetActive(true);
        }
        if (curHp <= 0 && floor < 10)
        {
            int newSprite = UnityEngine.Random.Range(0, eggSprite.Length);
            gameObject.GetComponent<Image>().sprite = eggSprite[newSprite];
            animator.Play("egg_spawn");
            nameText.text = "" + eggName[newSprite];
            int addHp = UnityEngine.Random.Range(curLevel * curLevel, curLevel * curLevel * 5);
            HP = curLevel * curLevel * curLevel * curLevel * 10 + addHp;
            int randomMoney = UnityEngine.Random.Range(curLevel * curLevel/2, curLevel * curLevel * 2);
            curHp = HP;
            floor++;
            if (player.stat.allStatsAdd[2] != 0)
            {
                player.allMoney += randomMoney * player.stat.allStatsAdd[2];
            }
            else
            {
                player.allMoney += randomMoney;
            }
            int randomMaterial = UnityEngine.Random.Range(0, 10000);
            if (player.stat.allStatsAdd[5] != 0)
            {
                if (randomMaterial > 10000 - (5 * player.stat.allStatsAdd[2]) && curLevel >= 100)
                {
                    int randomAdd = UnityEngine.Random.Range(0, 5);
                    player.materials[randomAdd]++;

                }
            }
            else
            {
                if (randomMaterial > 10000 - 5 && curLevel >= 100)
                {
                    int randomAdd = UnityEngine.Random.Range(0, 5);
                    player.materials[randomAdd]++;

                }
            }
        }
        else if (floor >= 10)
        {
            floor = 0;
            curLevel++;
            int newSprite = UnityEngine.Random.Range(0, eggSprite.Length);
            gameObject.GetComponent<Image>().sprite = eggSprite[newSprite];
            nameText.text = "" + eggName[newSprite];
            int addHp = UnityEngine.Random.Range(curLevel * curLevel, curLevel * curLevel * 5);
            HP = curLevel * curLevel * curLevel * 10 + addHp;
            int randomMoney = UnityEngine.Random.Range(curLevel * curLevel / 2, curLevel * curLevel * 2);
            curHp = HP;
            player.allMoney += randomMoney;
        }
    }
    static string[] names = { "", "K", "M", "B", "T", "q", "Q", "K+", "M+", "B+", "T+", "q+", "Q+" };

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
}
