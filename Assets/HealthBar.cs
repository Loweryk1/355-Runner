using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image ImgHealthBar;
    public Text TxtHealth;

    public int Min;
    public int Max;

    private int mCurrentValue;
    private float mCurrentPercent; 
	// Use this for initialization
	void Start () {
        mCurrentValue = Max;
        mCurrentPercent = 1;
	}
	
	// Update is called once per frame
	void Update () {
        TxtHealth.text = mCurrentValue + " / " + Max;
        ImgHealthBar.fillAmount = mCurrentPercent;
    }

    public void SetHealth(int health)
    {
        if(health != mCurrentValue)
        {
            if(Max - Min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = health;
                mCurrentPercent = (float)mCurrentValue / (float)(Max - Min);

            }
        }
    }

    public void SetMaxHealth (int maxHealth)
    {
        Max = maxHealth;
    }

    public float CurrentPercent
    {
        get { return mCurrentPercent; }
    }

    public int CurrentValue
    {
        get { return mCurrentValue; }
    }
}
