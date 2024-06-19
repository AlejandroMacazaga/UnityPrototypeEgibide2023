using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace Menu
{
    public class TutorialTexts : MonoBehaviour
    {
        [SerializeField] private String strTable;
        [SerializeField] private Texture control;
        [SerializeField] private String linea1;
        [SerializeField] private String linea2;
        [SerializeField] private GameObject line1;
        [SerializeField] private GameObject line2;
        [SerializeField] private GameObject image;
        [SerializeField] private GameObject popup;
        public bool tutorialCompleted;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            if (!tutorialCompleted)
            {
                popup.SetActive(true);
                tutorialCompleted = true;
            }
            
            image.SetActive(true);
            image.GetComponent<RawImage>().texture = control;
            
            var translatedValue1 = LocalizationSettings.StringDatabase.GetLocalizedString(strTable, linea1);
            var translatedValue2 = LocalizationSettings.StringDatabase.GetLocalizedString(strTable, linea2);
            
            line1.GetComponent<TextMeshProUGUI>().text = translatedValue1;
            line2.GetComponent<TextMeshProUGUI>().text = translatedValue2;
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            image.SetActive(false);
            
            line1.GetComponent<TextMeshProUGUI>().text = "";
            line2.GetComponent<TextMeshProUGUI>().text = "";
        }
    }
}
