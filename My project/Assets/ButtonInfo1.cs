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
    public void Update()
    {
      PriceTxt.SetText( ShopManager.GetComponent<ShopmanagerScript>().shopItems[2, ItemId].ToString());
    }

}
