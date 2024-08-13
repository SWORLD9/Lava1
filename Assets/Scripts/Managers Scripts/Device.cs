using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Implementation;

using UnityEngine;
using YG;
using static UnityEngine.AudioSettings;

public class Device : MonoBehaviour
{
    [Header("Charactor Controller")]
    public CharacterBrain _characterBrain;
    public CharacterStateController _characterStateController;
    private InputHandler InputHandler;

    [Header("Keyboard")]    
    [SerializeField] private GameObject _cameraKeyboard;

    [Header("Mobile")]
    [SerializeField] private GameObject _cameraMobile;
    [SerializeField] private GameObject _ui;


    private void Awake()
    {
        //Mobile
        if (LoadManager.IsPc == false)
        {

            //Set input
            InputHandler = gameObject.AddComponent<UIInputHandler>();
            _characterBrain.SetInputHandler(InputHandler);

            //Mobile on           
            _cameraMobile.SetActive(true);
            _ui.SetActive(true);

            //Keyboard off
            _cameraKeyboard.SetActive(false);

            //Set cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            _characterStateController.ExternalReference = _cameraMobile.transform;


        }

        //Keyboard
        else
        {
            //Set cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _characterStateController.ExternalReference = _cameraKeyboard.transform;

            //Keyboard on
            _cameraKeyboard.SetActive(true);

            //Mobile off
            _cameraMobile.SetActive(false);
            _ui.SetActive(false);
            


            
        }
    }

       
    


    


}
