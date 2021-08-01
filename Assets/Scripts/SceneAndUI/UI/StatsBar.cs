using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatsBar : MonoBehaviour
{
    [SerializeField] Image fillImgBack;
    [SerializeField] Image fillImgFront;
    [SerializeField] float fillSpeed = 0.1f;
    [SerializeField] bool isDelayFill = true;
    [SerializeField] float fillDelayTime = 0.5f;

    float curFillAmount;
    protected float targetFillAmount;

    float t;

    Canvas canvas;
    Coroutine bufferedFillCor;
    WaitForSeconds waitForDelayFill;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        waitForDelayFill = new WaitForSeconds(fillDelayTime);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public virtual void Init(float curVal, float maxVal)
    {
        curFillAmount = curVal / maxVal;
        targetFillAmount = curFillAmount;
        fillImgBack.fillAmount = curFillAmount;
        fillImgFront.fillAmount = curFillAmount;
    }

    public void UpdateState(float curVal, float maxVal)
    {
        targetFillAmount = curVal / maxVal;

        if(bufferedFillCor != null)
        {
            StopCoroutine(bufferedFillCor);
        }

        if(curFillAmount > targetFillAmount) // 状态条减少
        {
            fillImgFront.fillAmount = targetFillAmount; // 前图片立即改变
            bufferedFillCor = StartCoroutine(BufferedFillCoroutine(fillImgBack)); // 后图片缓冲改变
        }
        else if(curFillAmount < targetFillAmount) // 状态条回复
        {
            fillImgBack.fillAmount = targetFillAmount; // 后图片立即改变
            bufferedFillCor = StartCoroutine(BufferedFillCoroutine(fillImgFront)); // 前图片缓冲改变
        }

    }

    protected virtual IEnumerator BufferedFillCoroutine(Image img)
    {
        if (isDelayFill)
        {
            yield return waitForDelayFill;
        }

        t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * fillSpeed;
            curFillAmount = Mathf.Lerp(curFillAmount, targetFillAmount, t);
            img.fillAmount = curFillAmount;

            yield return null;
        }
        
    }
}
