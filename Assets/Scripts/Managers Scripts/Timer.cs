using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    //UI Time
    [SerializeField] private Text _timerObject;

    //Event
    [SerializeField] private MenuGameOver _menuGame;
    [SerializeField] private ColliderPlayer _player;
    public event Action TimeStart;
    public event Action TimeRestart;
    public event Action Win;


    private int _timeSecond;
    private bool _lavaMove = true;
    private bool _lose = false;

    private void Start()
    {
        RestartTime();
    }

    IEnumerator Time() 
    {
         yield return new WaitForSeconds(1);
        _timeSecond --;

        Check_Time();
    }

    private void Check_Time() 
    {
        //Update UI
        _timerObject.text = _timeSecond.ToString();

        if (_timeSecond < 1)
        {
            _timerObject.gameObject.SetActive(false);

            if (_lavaMove) 
            { //Start Lava
                TimeStart?.Invoke(); 
            }
            else 
            {
                if (!_lose)
                {   
                    //Teleport in Win Location
                    Win?.Invoke();
                }
                
            }
            
        }
        else
        {
            StartCoroutine( Time() );
        }
    
    }

    //The beginning of the countdown of the winning time
    public void WinTimer()
    {
        _timeSecond = 3;
        _timerObject.gameObject.SetActive(true);
        _lavaMove = false;

        Check_Time();
    }

    //Stopping the game due to a loss
    public void StopTime()
    {
        _timerObject.gameObject.SetActive(false);
        _lose = true;
    }

    //Restart location and new Time
    public void RestartTime() 
    {

        _timeSecond = 5;
        _timerObject.gameObject.SetActive(true);
        _lavaMove = true;
        _lose = false;

        TimeRestart?.Invoke();
        
        //Time on
        Check_Time();

    }

    private void OnEnable()
    {
        _menuGame.RestartMenu += RestartTime;
        _player.Lose += StopTime;
    }

    private void OnDisable()
    {
        _player.Lose -= StopTime;
        _menuGame.RestartMenu -= RestartTime;
    }
}
