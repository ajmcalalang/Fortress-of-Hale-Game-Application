using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanager : MonoBehaviour
{
    public static levelmanager main;

    public Transform startPoint;
    public Transform[] path;

    public int currency;
    private void Awake()
    { 
        main = this;
    }

    private void Start()
    {
        currency = 650;
    }

    public void IncreseCurrency(int amount) {

        currency += amount;
    
    }

    public bool SpendCurrency(int amount) {

        if (amount <= currency){

            currency -= amount;
            return true;

        }else{

            Debug.Log("You Do Not Have Enough to purchase this item");
            return false;
        }
    }
}
