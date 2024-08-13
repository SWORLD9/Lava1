using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Vote : MonoBehaviour
{

    [SerializeField] GameObject _voteMenu;
    [SerializeField] MenuGameOver _menuGame;

    [SerializeField] Text[] _text;

    //Event
    public event Action<int> VoneLoc;
    

    //Number Location
    [HideInInspector] public int _playerVote;


    private int[] _votes = new int[3];
    private int _voteMax;




  


    IEnumerator Voting()
    {
        yield return new WaitForSeconds(3);


        //Menu on
        _voteMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;


        for (int i = 0; i < 9; i++)
        {
            _votes[UnityEngine.Random.Range(0, 3)]++;
        }

        for (int i = 0; i < 3; i++)
        {
            _text[i].text = _votes[i].ToString();
        }



        yield return new WaitForSeconds(5);


        for (int i = 0; i < _votes.Length; i++)
        {
            if (_voteMax < _votes[i])
            {
                _voteMax = _votes[i];

                Debug.Log("MAX^ " + _voteMax );
            }

        }


        //Menu off and Enabling the location that was voted for
        for (int i = 0; i < 3; i++)
        {
            if (_votes[i] == _voteMax)
            {
                VoneLoc?.Invoke(i);
                Debug.Log(i);
                break;
            }

        }


        _menuGame.Resetart();
        _voteMenu.SetActive(false);
        _votes = new int[3];
        _voteMax = 0;

    }


    public void Button(int nummber)
    {
        _votes[nummber]++;
        _text[nummber].text = _votes[nummber].ToString();
    }



    private void OnEnable()
    {
        StartCoroutine(Voting());
        


    }







}
