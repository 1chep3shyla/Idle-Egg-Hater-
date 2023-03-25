using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonController : MonoBehaviour
{
    public Button[] dragonBut;
    public Button wearBut;
    public Button wearButNot;
    public Dragon[] dragons;
    public GameObject Panel;
    public string[] nameStats;
    public string[] nameDragon;
    public Text nameText;
    public Text[] textStats; // 0 - dmg, 1- dps, 2 - earn, 3 - critDMG, 4 - critChance, 5 - dropChance
    public bool[] wearSlot;
    public int[] wearID;
    public int[] allStatsAdd;

    void Update()
    {
        for (int i = 0; i < dragonBut.Length; i++)
        {
            int index = i;
            dragonBut[i].onClick.AddListener(() => StartCoroutine(dragonInfo(dragons[index])));
            if (dragons[i].have == true)
            {
                dragonBut[i].interactable = true;
            }
        }
    }
    public void offPanel()
    {
        wearBut.onClick.RemoveAllListeners();
        wearButNot.onClick.RemoveAllListeners();
    }
    public void dragonOFF()
    {
        for (int i = 0; i < dragons.Length; i++)
        {
            dragons[i].dragonPic.SetActive(false);
        }
    }
    IEnumerator dragonInfo(Dragon info)
    {
        if (info.wear == false)
        {
            wearBut.onClick.AddListener(() => dragonOn(info));
            wearButNot.onClick.AddListener(() => dragonOffFull(info));
            wearButNot.gameObject.SetActive(false);
            wearBut.gameObject.SetActive(true);
        }
        else
        {
            wearBut.onClick.AddListener(() => dragonOn(info));
            wearButNot.onClick.AddListener(() => dragonOffFull(info));
            wearButNot.gameObject.SetActive(true);
            wearBut.gameObject.SetActive(false);
        }
        nameText.text = nameDragon[info.dragonId];
        info.dragonPic.SetActive(true);
        nameText.color = info.colorBack;
        Panel.SetActive(true);
        for (int i = 0; i < textStats.Length; i++)
        {
            if (info.statsDragon[i] > 0)
            {
                textStats[i].gameObject.SetActive(true);
                textStats[i].text = nameStats[i] + info.statsDragon[i];
            }
            else
            {
                textStats[i].gameObject.SetActive(false);
            }
        }
        yield return null;
    }
    public void dragonOn(Dragon OnDragon)
    {
        if (OnDragon.wear == false)
        {

            for (int i = 0; i < wearSlot.Length; i++)
            {
                if (wearSlot[i] == false)
                {
                    wearButNot.gameObject.SetActive(true);
                    wearBut.gameObject.SetActive(false);
                    OnDragon.wear = true;
                    OnDragon.WearImage.SetActive(true);
                    wearSlot[i] = true;
                    wearID[i] = OnDragon.dragonId;
                    OnDragon.dragonGM.SetActive(true);
                    for (int s = 0; s < OnDragon.statsDragon.Length; s++)
                    {
                        allStatsAdd[s] += OnDragon.statsDragon[s];
                    }
                    return;
                }
            }
        }
    }

    public void dragonOffFull(Dragon OnDragon)
    {
        if (OnDragon.wear == true)
        {
            for (int i = 0; i < wearSlot.Length; i++)
            {
                if (wearID[i] == OnDragon.dragonId)
                {
                    wearButNot.gameObject.SetActive(false);
                    wearBut.gameObject.SetActive(true);
                    wearID[i] = 0;
                    OnDragon.wear = false;
                    wearSlot[i] = false;
                    OnDragon.WearImage.SetActive(false);
                    wearID[i] = OnDragon.dragonId;
                    OnDragon.dragonGM.SetActive(false);
                    for (int s = 0; s < OnDragon.statsDragon.Length; s++)
                    {
                        allStatsAdd[s] -= OnDragon.statsDragon[s];
                    }
                    return;
                }
            }
        }
    }
}
