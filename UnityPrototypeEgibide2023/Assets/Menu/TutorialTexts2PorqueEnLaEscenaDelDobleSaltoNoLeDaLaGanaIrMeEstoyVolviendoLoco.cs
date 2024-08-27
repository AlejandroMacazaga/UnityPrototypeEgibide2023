using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace Menu
{
    public class TutorialTexts2PorqueEnLaEscenaDelDobleSaltoNoLeDaLaGanaIrMeEstoyVolviendoLoco : MonoBehaviour
    {
        //El script normal ya no guarda los objetos serializados que le metas te da error (AssetNotPersistentException: Object is not persistent. The object needs to be saved to disk.) y ya no se guardan. en las otras escenas no pasa nada porque ya estaba tod bien puesto de antes y si no lo tocas se queda, pero en esta escena le tengo que poner el tutorial nuevo y no me deja asi que he tenido que hacer esta chapuza script solo para esta escena, si en alguna otra tambien se jodiese habria que hacer otro como este o arreglar el problema raiz si eres capaz.
        
        
        public bool tutorialCompleted;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            if (!tutorialCompleted)
            {
                GameObject.Find("Canvas/Tutoriales/TutorialDobleJump").SetActive(true);
                tutorialCompleted = true;
            }
            
            GameObject.Find("Canvas/GameObject/TutorialLine1").SetActive(true);
            GameObject.Find("Canvas/GameObject/TutorialLine2").SetActive(true);
            GameObject.Find("Canvas/GameObject/TutorialButton").SetActive(true);

        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            
            GameObject.Find("Canvas/GameObject/TutorialLine1").SetActive(false);
            GameObject.Find("Canvas/GameObject/TutorialLine2").SetActive(false);
            GameObject.Find("Canvas/GameObject/TutorialButton").SetActive(false);
        }
    }
}
