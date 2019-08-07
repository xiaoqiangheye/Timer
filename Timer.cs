using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Timer : MonoBehaviour
{

    private bool isActive;
    private float passedTime;
    private float time;
    private Action func;
    private bool isRepeatedForever;
    private int repeatedTimes;
  

    public Timer(float time, bool isRepeatedForever, Action act, int times)
    {
        this.time = time;
        this.isRepeatedForever = isRepeatedForever;
        this.func = act;
        this.isActive = false;
    }

    public void activate()
    {
        isActive = true;
    }

    public void deactivate()
    {
        isActive = false;
    }


   
     
    public void Update(){
        if (isActive)
        {
            passedTime += Time.deltaTime;
            if (passedTime >= time)
            {
                if (!isRepeatedForever && repeatedTimes > 0)
                {
                    func.Invoke();
                    repeatedTimes -= 1;
                    
                }
                else if(isRepeatedForever)
                {
                    func.Invoke();
                    passedTime = 0f;
                }
                else
                {
                    isActive = false;
                    passedTime = 0f;
                }
            }
        }
    }

}
