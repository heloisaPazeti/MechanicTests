using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyTextDialog : MonoBehaviour
{
    public string[] sentences;
    private int index = 0;
    private bool isPlayerColliding;

    private void Update()
    {
        if (isPlayerColliding && Input.GetKeyDown(KeyCode.X))
            if (!DialogManager.instance.isChatOpen)
                NewDialog();
            else
                NextDialog();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            isPlayerColliding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerColliding = false;
    }

    private void NewDialog()
    {
        DialogManager.instance.ShowDialog(sentences[index]);
    }

    private void NextDialog()
    {
        index++;

        if (index < sentences.Length)
            NewDialog();
        else
        {
            index = 0;
            EndDialog();
        }
    }

    private void EndDialog()
    {
        DialogManager.instance.HideDialog();
    }
}
