using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetNicknameField : MonoBehaviour
{
    [SerializeField] private Text[] nickname;
    
    public void TextNickname()
    {
        for (int x = 0; x < nickname.Length; x++)
        {
            nickname[x].text = NicknameScript.instance.nameFileData;
        }
    }

}
