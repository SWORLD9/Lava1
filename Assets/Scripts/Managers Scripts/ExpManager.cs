using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{//UI coin
    [SerializeField] Text _expText;

    //Event
    [SerializeField] LocationsManager _locationsManager;



    private void OnEnable()
    {
        if (_locationsManager != null)
        {
            _locationsManager.GetExp += NewExp;
        }
       
    }

    private void OnDisable()
    {
        if (_locationsManager != null)
        {
            _locationsManager.GetExp -= NewExp;
        }
    }


    private void Start()
    {
        //Update UI
        _expText.text = "Exp: " + LoadManager.exp.ToString();
    }

    //Coin + 1 and Update UI
    public void NewExp()
    {
        LoadManager.exp += 5;
        _expText.text = "Exp: " + LoadManager.exp.ToString();

    }
}
