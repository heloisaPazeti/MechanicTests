using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    public string quest;
    public string[] options;
    private bool isPlayerColliding;

    /*
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player" && Input.GetKeyDown(KeyCode.X) && !DialogManager.instance.isChatOpen)
            StartChoice();
    }
    */

    private void Update()
    {
        if (isPlayerColliding && Input.GetKeyDown(KeyCode.X) && !DialogManager.instance.isChatOpen)
            StartChoice();
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

    protected virtual void StartChoice()
    {
        DialogManager.instance.ShowDialog(options, quest);
    }

    protected virtual void RemoveAllListners()
    {
        DialogManager.instance.firstOption.onClick.RemoveAllListeners();
        DialogManager.instance.secondOption.onClick.RemoveAllListeners();
    }
}
