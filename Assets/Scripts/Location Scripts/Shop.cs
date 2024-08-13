using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField] private GameObject _shopUI;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UI();
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }



    public void UI()
    {
        if (_shopUI != null)
        {
            if (_shopUI.activeSelf == true & LoadManager.IsPc == true) 
            {

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;


            }
            _shopUI.SetActive(!_shopUI.activeSelf);

        }
    }

}
