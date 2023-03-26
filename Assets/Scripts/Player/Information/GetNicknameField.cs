using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetNicknameField : MonoBehaviour
{
    [SerializeField] private Text nickname;
    
    public void TextNickname()
    {
        nickname.text = NicknameScript.instance.nameFileData;
    }

}
