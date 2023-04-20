using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcchievementsMenu : MonoBehaviour
{
    private NicknameData data;

    [SerializeField] private GameObject[] acchievementImage;
    [SerializeField] private Text acchievementCant;
    
    // Start is called before the first frame update
    void Start()
    {
        data = new NicknameData();
        getAcchievements();
    }

    public void getAcchievements()
    {
        data = NicknameScript.instance.LoadData();
        int number = 0;
        for (int i = 0; i < 5; i++)
        {
            if (data.acchievements[i].state)
            {
                number++;
                Debug.Log(true);
                var newColor = new Color(191, 191, 191, 255);
                acchievementImage[i*2].GetComponent<Image>().color = newColor;
                acchievementImage[(i*2)+1].GetComponent<Image>().color = newColor;
            }
            else
            {
                Debug.Log(false);
                var newColor = new Color(0, 0, 0, 255);
                acchievementImage[i*2].GetComponent<Image>().color = newColor;
                acchievementImage[(i*2)+1].GetComponent<Image>().color = newColor;
            }
        }

        acchievementCant.text = number.ToString();
    }
}
