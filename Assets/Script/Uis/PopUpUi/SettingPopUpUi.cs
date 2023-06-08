using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopUpUi : PopUpUi
{
    protected override void Awake()
    {
        base.Awake();

        buttons["ContinueButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
        buttons["SettingButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUi>("UI/ConfigPopUpUI"); });
    }
}
