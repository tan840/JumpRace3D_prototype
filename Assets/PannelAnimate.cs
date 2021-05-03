using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PannelAnimate : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject[] items;
    public float delay = 0.5f;
    WaitForSeconds wait;
    private void Start()
    {
        wait = new WaitForSeconds(delay);
        foreach (GameObject item in items)
        {
            item.SetActive(false);
        }
        canvasGroup.interactable = false;
    }
    
    private void OnEnable()
    {
        canvasGroup.DOFade(1, 1f);
        StartCoroutine(AnimateItems());
    }
    private void OnDisable()
    {
        canvasGroup.alpha = 0f;
        foreach (GameObject item in items)
        {          
            item.SetActive(false);
        }
        canvasGroup.interactable = false;
    }

    IEnumerator AnimateItems()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject item in items)
        {
            yield return wait;
            item.SetActive(true);
        }
        canvasGroup.interactable = true;
    }
}
