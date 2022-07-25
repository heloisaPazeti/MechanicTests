using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
