using System.Collections;
using System.Collections.Generic;
using General.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MostrarStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI collectable;
    [SerializeField] TextMeshProUGUI gisotzo;
    [SerializeField] TextMeshProUGUI galtzagorri;
    [SerializeField] TextMeshProUGUI cabra;
    [SerializeField] TextMeshProUGUI arrano;
    [SerializeField] TextMeshProUGUI bruja;
    public void UpdateStats()
    {
        collectable.text = GameController.Instance.collectedItems.Count + "/10";
        gisotzo.text = GameController.Instance.gisotzosKilled.ToString();
        galtzagorri.text = GameController.Instance.galtzagorrisKilled.ToString();
        cabra.text = GameController.Instance.cabrasKilled.ToString();
        arrano.text = GameController.Instance.arranosKilled.ToString();
        bruja.text = GameController.Instance.brujasKilled.ToString();
    }
}
