using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Refreshscript : MonoBehaviour
{
    public TextMeshProUGUI PriceTxt;
    public GameObject Shopmanager;
     

    // Update is called once per frame
    void Update()
    {
        PriceTxt.SetText("Refresh " + Shopmanager.GetComponent<ShopmanagerScript>().refreshCost.ToString()); 
    }
}
