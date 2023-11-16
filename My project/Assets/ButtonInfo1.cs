using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo1 : MonoBehaviour
{
    public int ItemId;
    public TextMeshProUGUI PriceTxt;
    public GameObject ShopManager;
    public int Upgrade;
    public Sprite upgrade1;
    public Sprite upgrade2;
    public Sprite upgrade3;
    public Sprite upgrade4;
    public Sprite upgrade5;
    public Sprite upgrade6;
    public Sprite upgrade7;
    public Sprite upgrade8;
    public Sprite upgrade9;
    public Sprite upgrade10;
    public Sprite upgrade11;
    public Sprite upgrade12;
    public Sprite upgrade13;
    public Sprite upgrade14;
    public Sprite upgrade15;
    public Sprite upgrade16;
    public Sprite upgrade17;
    public Sprite upgrade18;
    public Sprite upgrade19;
    public void Update()
    {
        PriceTxt.SetText(ShopManager.GetComponent<ShopmanagerScript>().shopItems[2, ItemId].ToString());
    }
    public void pics()
    {

        switch (Upgrade)
        {
            case 1:
                GetComponent<Image>().sprite = upgrade1;
                break;
            case 2:
                GetComponent<Image>().sprite = upgrade2;
                break;
            case 3:
                GetComponent<Image>().sprite = upgrade3;
                break;
            case 4:
                GetComponent<Image>().sprite = upgrade4;
                break;
            case 5:
                GetComponent<Image>().sprite = upgrade5;
                break;
            case 6:
                GetComponent<Image>().sprite = upgrade6;
                break;
            case 7:
                GetComponent<Image>().sprite = upgrade7;
                break;
            case 8:
                GetComponent<Image>().sprite = upgrade8;
                break;
            case 9:
                GetComponent<Image>().sprite = upgrade9;
                break;
            case 10:
                GetComponent<Image>().sprite = upgrade10;
                break;
            case 11:
                GetComponent<Image>().sprite = upgrade11;
                break;
            case 12:
                GetComponent<Image>().sprite = upgrade12;
                break;
            case 13:
                GetComponent<Image>().sprite = upgrade13;
                break;
            case 14:
                GetComponent<Image>().sprite = upgrade14;
                break;
            case 15:
                GetComponent<Image>().sprite = upgrade15;
                break;
            case 16:
                GetComponent<Image>().sprite = upgrade16;
                break;
            case 17:
                GetComponent<Image>().sprite = upgrade17;
                break;
            case 18:
                GetComponent<Image>().sprite = upgrade18;
                break;
            case 19:
                GetComponent<Image>().sprite = upgrade19;
                break;


        }
    }
}
