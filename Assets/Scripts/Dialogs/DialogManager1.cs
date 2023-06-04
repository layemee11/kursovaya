using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager1 : MonoBehaviour
{
    public Text dialogText1;
    public Text nameText1;
    //public GameObject LevelChanger;
    public Animator boxAnim1;
    public Animator startAnim1;

    private Queue<string> sentences1;

    private void Start()
    {
        sentences1 = new Queue<string>();
    }
    public void StartDialog(Dialog1 dialog1)
    {
        boxAnim1.SetBool("boxOpen2", true);
        startAnim1.SetBool("startOpen2", false);

        nameText1.text = dialog1.name1;
        sentences1.Clear();

        foreach(string sentence in dialog1.sentences1)
        {
            sentences1.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences1.Count == 0) 
        {
            EndDialog();
            return ;
        }
        string sentence = sentences1.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogText1.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogText1.text += letter;
            yield return null;
        }
    }
    public void EndDialog()
    {
        boxAnim1.SetBool("boxOpen2", false);
        //LevelChanger.GetComponent<LevelChanger>().FadeToLevel();
        SceneManager.LoadScene("Level 2");
    }
}
