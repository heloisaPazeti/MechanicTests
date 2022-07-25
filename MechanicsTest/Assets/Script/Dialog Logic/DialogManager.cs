using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    
    public bool isChatOpen;

    public GameObject textChat;
    public GameObject imageTextChat;
    public GameObject optionChat;
    public Image imageComponent;
    public Button firstOption;
    public Button secondOption;

    private GameObject openChat;
    private Player player;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        player = FindObjectOfType<Player>();
    }

    public void ShowDialog(string msg)
    {
        textChat.GetComponentInChildren<Text>().text = msg;
        ActiveDialog(textChat);
    }

    public void ShowDialog(string msg, Sprite img)
    {
        imageComponent.sprite = img;
        imageTextChat.GetComponentInChildren<Text>().text = msg;
        ActiveDialog(imageTextChat);
    }

    public void ShowDialog(string[] options, string quest)
    {
        ActiveDialog(optionChat);
        optionChat.GetComponentInChildren<Text>().text = quest;
        firstOption.GetComponentInChildren<Text>().text = options[0];
        secondOption.GetComponentInChildren<Text>().text = options[1];
    }

    public void HideDialog()
    {
        if(openChat != null)
        {
            isChatOpen = false;
            openChat.SetActive(isChatOpen);
            openChat = null;
            player.PausePlayer(false);
        }    
    }

    private void ActiveDialog(GameObject dialog)
    {
        if(openChat == null)
        {
            isChatOpen = true;
            dialog.SetActive(isChatOpen);
            openChat = dialog;
            player.PausePlayer(true);
        }  
    }
}
