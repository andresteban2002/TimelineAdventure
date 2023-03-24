
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class NicknameValidation : MonoBehaviour
{
    public InputField nicknameField;
    public Button Acceptbutton;
    NicknameData data;
    private void Start()
    {
        Acceptbutton.interactable = true;
    }

    public void isRequired()
    {
        if (nicknameField.text != "")
        {
            Acceptbutton.interactable = true;
        }
        else
        {
            Acceptbutton.interactable = false;
        }
    }
    
    public void onButtonAcept()
    {
        data = new NicknameData();
        data.nickname = nicknameField.text;
        gameObject.GetComponent<NicknameScript>().nameFileData = data.nickname;
        NicknameData dataOld = gameObject.GetComponent<NicknameScript>().LoadData();
        if (dataOld != null)
        {
            if (dataOld.nickname != data.nickname)
            {
                gameObject.GetComponent<NicknameScript>().SaveData(data);
            }
        }
        else
        {
            gameObject.GetComponent<NicknameScript>().SaveData(data);
        }
    }
}
