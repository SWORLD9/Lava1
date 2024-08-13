using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    //Event
    [SerializeField] private ColliderPlayer _gameOver;
    public event Action RestartMenu;

    //UI Menu Game Over
    [SerializeField] private GameObject _buttons;




    private void OnEnable()
    {
        _gameOver.Lose += MenuTrue;
    }

    private void OnDisable()
    {
        _gameOver.Lose -= MenuTrue;
    }

    //Menu on
    public void MenuTrue()
    {
        _buttons.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        //Save coins
        LoadManager.Save();

    }

    //Button Lobby
    public void Lobby()
    {
        //Menu off 
        if (LoadManager.IsPc)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        _buttons.SetActive(false);


        SceneManager.LoadScene("Lobby");



    }
    //Button Restart
    public void Resetart()
    {
        //Menu off 
        if (LoadManager.IsPc)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        _buttons.SetActive(false);

        //Restart location
        RestartMenu?.Invoke();


    }

}
