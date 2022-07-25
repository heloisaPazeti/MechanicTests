using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionOpenMenu : OptionManager
{
    public GameObject menu;

    protected override void StartChoice()
    {
        base.StartChoice();

        DialogManager.instance.firstOption.onClick.AddListener(caseOne);
        DialogManager.instance.secondOption.onClick.AddListener(caseTwo);
    }

    private void caseOne()
    {
        DialogManager.instance.HideDialog();
        RemoveAllListners();

        menu.SetActive(true);
    }

    private void caseTwo()
    {
        DialogManager.instance.HideDialog();
        RemoveAllListners();
    }

    public void closeMenu()
    {
        menu.SetActive(false);
    }
}
