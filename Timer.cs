using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Specialized;

public class Timer : MonoBehaviour
{
    public TMP_Text[] textObj;
    public float currentTime;
    public float goalTime;
    public int sessionsCompleted;
    public int hoursCompleted;
    public int minGoal;
    public int hourGoal;
    public string minutesToDisplay;
    public string hoursToDisplay;
    public GameObject[] Popups;
    public bool timerOn = false;
    public Image clock;

    void Update()
    {
        textObj[6].text = System.DateTime.UtcNow.ToLocalTime().ToString("M/d/yy hh:mm tt");
        if (timerOn == false)
        {
            Time.timeScale = 0f;
        }
        else
        {
            if(currentTime < goalTime)
            {
                Time.timeScale = 1f;
                currentTime += Time.deltaTime;
                clock.fillAmount = currentTime / goalTime;
                int elapsedMinutes = (int)(currentTime / 60);
                int elapsedHours = elapsedMinutes / 60;
                if (elapsedMinutes == 60)
                {
                    elapsedMinutes = 0;
                    hoursCompleted += 1;
                    textObj[4].text = "Hours: " + hoursCompleted.ToString();
                }
                if (elapsedMinutes > 9)
                {
                    minutesToDisplay = elapsedMinutes.ToString();
                }
                else if (elapsedMinutes <= 9)
                {
                    minutesToDisplay = "0" + elapsedMinutes.ToString();
                }
                if (elapsedHours > 9)
                {
                    hoursToDisplay = elapsedHours.ToString();
                }
                else if (elapsedHours <= 9)
                {
                    hoursToDisplay = "0" + elapsedHours.ToString();
                }
                textObj[0].text = hoursToDisplay + ":" + minutesToDisplay;
            }
            else if(currentTime >= goalTime)
            {
                textObj[3].text = "START";
                sessionsCompleted += 1;
                textObj[5].text = "Sessions: " + sessionsCompleted.ToString();
                currentTime = 0;
                timerOn = false;
            }
        }
        if (Popups[0].activeSelf)
        {
            if (minGoal == 60)
            {
                minGoal = 0;
                hourGoal += 1;
            }
            if (minGoal > 9)
            {
                textObj[2].text = minGoal.ToString();
            }
            else if (minGoal <= 9)
            {
                textObj[2].text = "0" + minGoal.ToString();
            }
            if(hourGoal > 9)
            {
                textObj[1].text = hourGoal.ToString() + ":";
            }
            if (hourGoal <= 9)
            {
                textObj[1].text = "0" + hourGoal.ToString() + ":";
            }
        }
    }
    
    public void OpenGoalSet()
    {
        textObj[3].text = "PAUSED";
        Popups[0].SetActive(true);
        timerOn = false;
    }
    public void IncrMinGoal()
    {
        minGoal += 1;
        goalTime += 60f;
    }
    public void DecrMinGoal()
    {
        if(minGoal > 0)
        {
            minGoal -= 1;
            goalTime -= 60f;
        }
    }
    public void IncrHourGoal()
    {
        hourGoal += 1;
        goalTime += 3600f;
    }
    public void DecrHourGoal()
    {
        if(hourGoal > 0)
        {
            hourGoal -= 1;
            goalTime -= 3600f;
        }
    }
    public void SetGoal()
    {
        textObj[3].text = "PAUSE";
        Popups[0].SetActive(false);
        timerOn = true;
    }
    public void OpenBook(GameObject Popup)
    {
        Popup.SetActive(true);
    }
    public void CloseBook(GameObject Popup)
    {
        Popup.SetActive(false);
    }
}
