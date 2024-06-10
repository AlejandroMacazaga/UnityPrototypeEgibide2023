using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHide : MonoBehaviour
{
    [SerializeField] private GameObject[] UiComponentsToHide;

    public void Hide()
    {
        foreach (var UiComponentToHide in UiComponentsToHide)
        {
            UiComponentToHide.SetActive(false);
        }
    }
}
