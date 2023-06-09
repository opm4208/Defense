using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSceneUi : PopUpUi
{
    protected override void Awake()
    {
        base.Awake();

        buttons["InfoButton"].onClick.AddListener(() => { OpenInfoWindowUI(); });
        buttons["VolumeButton"].onClick.AddListener(() => { Debug.Log("Volume"); });
        buttons["SettingButton"].onClick.AddListener(() => { OpenPausePopUp(); });
    }

    public void OpenInfoWindowUI()
    {
        GameManager.UI.ShowWindowUI("UI/InfoWindowUI");
    }

    public void OpenPausePopUp()
    {
        GameManager.UI.ShowPopUpUI<PopUpUi>("UI/SettingPopUpUI");
    }
}
