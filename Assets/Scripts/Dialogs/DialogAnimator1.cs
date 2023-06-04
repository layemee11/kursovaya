using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAnimator1 : MonoBehaviour
{
    public Animator startAnim1;
    public DialogManager1 dm1;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            startAnim1.SetBool("startOpen2", true);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        startAnim1.SetBool("startOpen2", false);
        dm1.EndDialog();
    }
}
