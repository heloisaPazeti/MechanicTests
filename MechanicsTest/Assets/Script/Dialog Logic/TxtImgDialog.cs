using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtImgDialog : MonoBehaviour
{
    public string[] sentences;
    public Sprite image;
    private int index = 0;
    private bool isPlayerColliding;

    /*
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player" && Input.GetKeyDown(KeyCode.X))
            if (!DialogManager.instance.isChatOpen)
                NewDialog();
            else
                NextDialog();
    }
    */

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
        DialogManager.instance.ShowDialog(sentences[index], image);
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
