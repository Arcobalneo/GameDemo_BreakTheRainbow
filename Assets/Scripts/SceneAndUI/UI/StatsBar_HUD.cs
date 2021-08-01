using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatsBar_HUD : StatsBar
{
    [SerializeField] Text percentTxt;

    void SetPercentTxt()
    {
        percentTxt.text = Mathf.RoundToInt(targetFillAmount * 100f) + "%";
    }

    public override void Init(float curVal, float maxVal)
    {
        base.Init(curVal, maxVal);
        SetPercentTxt();
    }

    protected override IEnumerator BufferedFillCoroutine(Image img)
    {
        SetPercentTxt();
        return base.BufferedFillCoroutine(img);
    }
}
