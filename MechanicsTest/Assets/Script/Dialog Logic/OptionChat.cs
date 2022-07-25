using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionChat : MonoBehaviour
{
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public Animator anim;

    private void Update()
    {
        if(gameObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anim.SetBool("goToRight", true);
                SelectButton(buttonOne);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                anim.SetBool("goToRight", false);
                SelectButton(buttonTwo);
            }
        }
    }

    private void SelectButton(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }
}
