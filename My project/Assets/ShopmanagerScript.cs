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
    public int currentAbility = -1;
    public int doubleShot = 0;
    public int spreadshot = 0;
    public int backshot = 0;
    public int shotIntervall = 0;
    public float refreshCost;
    public int refreshCostPerClick = 10;


    private void Start()
        
    {
        refreshCost = 10f;
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
            switch(ButtonRef.GetComponent<ButtonInfo1>().Upgrade)
            {
                case 19: 
                    anotherChoice = true;
                hiddenButton.SetActive(true);
                priceIncrease(4);
                    break;
                case 2:
                    doubleShot++;
                    break;
                case 3:
                    spreadshot++;
                    break;
                case 4:
                    backshot++;
                    break;
                case 8:
                    shotIntervall++;
                    break;
                case 11:
                    currentAbility = 11;
                    break;
                case 12:
                    currentAbility = 12;
                    break;
                case 13:
                    currentAbility = 13;
                    break;
                case 14:
                    currentAbility = 14;
                    break;
            }
            GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>().Upgrading(ButtonRef.GetComponent<ButtonInfo1>().Upgrade);
            shuffle(ButtonRef.GetComponent<ButtonInfo1>().ItemId);
            priceIncrease(ButtonRef.GetComponent<ButtonInfo1>().ItemId);
            ButtonRef.GetComponent<ButtonInfo1>().pics();
           
        }
    }
    
    public void LuckyRoll(int i)
    {

        if (anotherChoice == false) {
            if (currentUpgrades[i] == 19)
            {
                if (Random.Range(1, 2) == 1)
                {
                    currentUpgrades[i] = Random.Range(1, 18);
                }
            }
        }
        else
        {
            currentUpgrades[i] = Random.Range(1, 18);
        }
        
    }
    public void shuffle(int button)
    {
        currentUpgrades[button] = Random.Range(1, 19);
        if (currentUpgrades[button] == 19)
        {
            LuckyRoll(button);
        }
        while (Doubled(button)|| bannedUpgardes(button))
        {
            currentUpgrades[button] = Random.Range(1, 18);
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
        currentUpgrades[1] = Random.Range(1, 19);
        currentUpgrades[2] = Random.Range(1, 19);
        currentUpgrades[3] = Random.Range(1, 19);
        currentUpgrades[4] = 0;

        if (anotherChoice)
        {
            currentUpgrades[4] = Random.Range(1, 18);
        }
        else
        {
            for (int i = 1; i < 4; i++)
            {
                if (currentUpgrades[i]==19) { 
                LuckyRoll(i);
                }
            }
        }
        for (int j = 2; j < 5; j++)
        {
            while (Doubled(j) || bannedUpgardes(j) )
            {
                currentUpgrades[j] = Random.Range(1, 18);
            }
        }
       
        button1.Upgrade = currentUpgrades[1];
        button2.Upgrade = currentUpgrades[2];
        button3.Upgrade = currentUpgrades[3];
        button4.Upgrade = currentUpgrades[4];
        button1.pics();
        button2.pics();
        button3.pics();
        button4.pics();

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
    public bool bannedUpgardes(int button)
    {
        if(currentUpgrades[button] == currentAbility)
        {
            return true;
        }else if(currentUpgrades[button] == 2 && doubleShot > 1)
        {
            return true;
        } else if(currentUpgrades[button] == 3 && spreadshot > 1)
        {
            return true;
        }else if(currentUpgrades[button] == 4 && backshot > 1)
        {
            return true;
        } else if(currentUpgrades[button] == 8 && shotIntervall > 8)
        {
            return true;
        }
        return false;
    }

    public void Refresh()
    {
        if (coins >= refreshCost)
        {

            coins = coins - refreshCost;
            CoinsTXT.SetText(coins.ToString());
            refreshCost += refreshCostPerClick;
            GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>().coinsamount = ((int)coins);
            shuffleAll();
            
        }
    }
    public void Refreshdecrease()
    {
        if (refreshCostPerClick != 1)
        {
            refreshCostPerClick -= 1;
        }
        refreshCost -= refreshCost * 0.25f;
        refreshCost =((int)refreshCost);
    }
   }

