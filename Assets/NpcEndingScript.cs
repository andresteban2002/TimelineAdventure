using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NpcEndingScript : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = "";
        StartCoroutine(Typing());
    } 

    // Update is called once per frame
    void Update()
    {
        if (!dialoguePanel.activeInHierarchy)
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
        else if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }

        if (index == dialogue.Length - 1)
        {
            contButton.SetActive(false);
        }
    }

    public void zeroText(){
        dialogueText.text = "";
    }

    IEnumerator Typing(){
        contButton.SetActive(false);
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text +=  letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine(){
        if (index < dialogue.Length - 1){
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else{
            zeroText();
        }        
    }
}
