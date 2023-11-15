using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopmanagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public float coins;
    public TextMeshProUGUI CoinsTXT;
    public int[] currentUpgrades;
    public ButtonInfo1 button1;
    public ButtonInfo1 button2;
    public ButtonInfo1 button3;
    public ButtonInfo1 button4;
    public GameObject hiddenButton;
    private bool anotherChoice = false;

    private void Start()
        
    {
        currentUpgrades = new int[5];
        if(!anotherChoice)
        {
            hiddenButton.SetActive(false);
        }
        

        shuffleAll();
        
       

        CoinsTXT.text = coins.ToString();

        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        shopItems[2, 1] = 10;
        shopItems[2, 2] = 12;
        shopItems[2, 3] = 14;
        shopItems[2, 4] = 0;

        button1.Upgrade = currentUpgrades[1];
        button2.Upgrade = currentUpgrades[2];
        button3.Upgrade = currentUpgrades[3];
        button4.Upgrade = currentUpgrades[4];

    }
    void Update()
    {
        coins = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>().coinsamount;
        CoinsTXT.SetText(coins.ToString()) ;
    }
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if(coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo1>().ItemId ])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo1>().ItemId];
            
            CoinsTXT.SetText(  coins.ToString());
            GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>().coinsamount = ((int)coins);
            if(ButtonRef.GetComponent<ButtonInfo1>().Upgrade == 15)
            {
                anotherChoice = true;
                hiddenButton.SetActive(true);
                priceIncrease(4);
            }
            GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>().Upgrading(ButtonRef.GetComponent<ButtonInfo1>().Upgrade);
            shuffle(ButtonRef.GetComponent<ButtonInfo1>().ItemId);
            priceIncrease(ButtonRef.GetComponent<ButtonInfo1>().ItemId);

           
        }
    }
    
    public void LuckyRoll(int i)
    {

        if (anotherChoice == false) {
            if (currentUpgrades[i] == 15)
            {
                if (Random.Range(1, 2) == 1)
                {
                    currentUpgrades[i] = Random.Range(1, 14);
                }
            }
        }
        else
        {
            currentUpgrades[i] = Random.Range(1, 14);
        }
        
    }
    public void shuffle(int button)
    {
        currentUpgrades[button] = Random.Range(1, 15);
        if (currentUpgrades[button] == 15)
        {
            LuckyRoll(button);
        }
        while (Doubled(button))
        {
            currentUpgrades[button] = Random.Range(1, 14);
        }
        button1.Upgrade = currentUpgrades[1];
        button2.Upgrade = currentUpgrades[2];
        button3.Upgrade = currentUpgrades[3];
        button4.Upgrade = currentUpgrades[4];
    }
    public bool Doubled(int toCheck)
    {
        for (int i = 1; i < 5; i++)
        {
            if (toCheck != i)
            {
                if(currentUpgrades[toCheck] == currentUpgrades[i])
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void shuffleAll()
    {
        currentUpgrades[1] = Random.Range(1, 15);
        currentUpgrades[2] = Random.Range(1, 15);
        currentUpgrades[3] = Random.Range(1, 15);
        currentUpgrades[4] = 0;

        if (anotherChoice)
        {
            currentUpgrades[4] = Random.Range(1, 15);
        }
        else
        {
            for (int i = 1; i < 4; i++)
            {
                if (currentUpgrades[i]==15) { 
                LuckyRoll(i);
                }
            }
        }
        for (int j = 2; j < 5; j++)
        {
            while (currentUpgrades[1] == currentUpgrades[j])
            {
                currentUpgrades[j] = Random.Range(1, 14);
            }
        }
        for (int k = 3; k <5; k++) {
            while (currentUpgrades[2] == currentUpgrades[k])
            {
                currentUpgrades[k] = Random.Range(1, 14);
            }
        }
        while (currentUpgrades[3] == currentUpgrades[4])
        {
            currentUpgrades[4] = Random.Range(1, 14);
        }
        button1.Upgrade = currentUpgrades[1];
        button2.Upgrade = currentUpgrades[2];
        button3.Upgrade = currentUpgrades[3];
        button4.Upgrade = currentUpgrades[4];
    }
    public void priceIncrease(int buttonNumber)
    {
        int highestPrice =0;
        for(int i=1; i<5; i++)
        {
            if(highestPrice< shopItems[2, i])
            {
                highestPrice = shopItems[2, i];
            }

        }
        int priceIncrease =1;
        for(int k=1; k<11; k++)
        {
            if(highestPrice> k * 10)
            {
                priceIncrease++;
            }
        }
        shopItems[2, buttonNumber] = highestPrice + priceIncrease;
         
    }
}
