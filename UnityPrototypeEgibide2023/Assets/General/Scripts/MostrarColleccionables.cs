using System.Collections;
using System.Collections.Generic;
using General.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MostrarColleccionables : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _infoText;
    public void UpdateCollectables()
    {
        _infoText.text = GameController.Instance.collectedItems.Count + "/10";
    }
}
