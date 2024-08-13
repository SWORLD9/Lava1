using UnityEngine;
using UnityEngine.SceneManagement;
using YG;


public class LoadManager : MonoBehaviour
{
    public static int coin;
    public static bool IsPc = false;
    public static int exp;

   /* public static Boosts speed;
    public static Boosts dubleJump;
    public static Boosts highJump;
    public static Boosts magnet;
    public static Boosts jetpack;
    public static Boosts shield;*/


    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    private void OnDisable() => YandexGame.GetDataEvent -= GetData;


    /*public class Boosts
    {
        public int lot;
        public bool infinity;

    }*/

    public void Start()
    {
        //Check Yandex
        if (YandexGame.SDKEnabled == true)
        {
            GetData();

        }

    }

    private void GetData()
    {
        //Check Platform
        if (YandexGame.EnvironmentData.isDesktop == true)
        {
            IsPc = true;
        }

        Load();
    }


    //Save informations from Yandex
    public static void Save()
    {
        YandexGame.savesData.exp = exp;
        YandexGame.savesData.coin = coin;

        /*YandexGame.savesData.speed = speed;
        YandexGame.savesData.dubleJump = dubleJump;
        YandexGame.savesData.highJump = highJump;
        YandexGame.savesData.magnet = magnet;
        YandexGame.savesData.jetpack = jetpack;
        YandexGame.savesData.shield = shield;*/



        YandexGame.SaveProgress();




        Debug.Log("Save");
    }

    //Load informations from Yandex
    public static void Load()
    {
        coin = YandexGame.savesData.coin;
        exp = YandexGame.savesData.exp;


        //Start Game
        SceneManager.LoadScene(1);
    }
}
