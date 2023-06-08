using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoSceneUi : SceneUi
{
    public TMP_Text heartText;

    protected override void Awake()
    {
        base.Awake();

        heartText = texts["HeartText"];
        texts["CoinText"].text = "100";
    }
}
