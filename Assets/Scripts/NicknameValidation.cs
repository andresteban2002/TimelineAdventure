
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class NicknameValidation : MonoBehaviour
{
    public InputField nicknameField;
    public Button Acceptbutton;
    [SerializeField] private GameObject newMatchButton;
    NicknameData data;
    private void Start()
    {
        Acceptbutton.interactable = false;
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

            if (dataOld.matches.Count >= 5)
            {
                newMatchButton.SetActive(false);
            }
            else
            {
                newMatchButton.SetActive(true);
            }
        }else
        {
            gameObject.GetComponent<NicknameScript>().SaveData(data);
            data = gameObject.GetComponent<NicknameScript>().LoadData();
            for (int i = 0; i < 5; i++)
            {
                AcchievementsData acchievements = new AcchievementsData();
                acchievements.state = false;
                data.acchievements.Add(acchievements);
                data.acchievements[i].level = i + 1;
                data.acchievements[i].state = false;
            }
            gameObject.GetComponent<NicknameScript>().SaveData(data);
        }
    }
}
