using System;
using UnityEngine;
using System.Collections;




public class TimeManager:MonoBehaviour
{
    public static ArrayList timers;
    static TimeManager()
    {
        timers = new ArrayList();
    }

    public static Timer setInterval(float interval, Action act)
    {
        Timer timer = new Timer(interval, true, act,0);
        timers.Add(timer);
        return timer;
    }


    public static Timer setTimeOut(float interval, Action act)
    {
        Timer timer = new Timer(interval, false, act,1);
        timers.Add(timer);
        return timer;
    }

    public static Timer setInterval(float interval, Action act, int times)
    {
        Timer timer = new Timer(interval,false,act, times);
        timers.Add(timer);
        return timer;
    }

    public static void remove(Timer timer)
    {
        timer.deactivate();
        timers.Remove(timer);
    }

    void Update()
    {
        foreach (Timer timer in timers)
        {
            timer.Update();
        }
    }
}
