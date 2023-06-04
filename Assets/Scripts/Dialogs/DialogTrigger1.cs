using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger1: MonoBehaviour
{
    public Dialog1 dialog1;
    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager1>().StartDialog(dialog1);
    }
}
