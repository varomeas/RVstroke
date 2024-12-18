using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInfoOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public GameObject infoPanel; // Le panneau UI contenant les informations
    public string objectInfo = "Voici des informations sur l'objet."; // Le texte à afficher

    [SerializeField] TextMeshProUGUI infoText; // Le composant Text du panneau
    public float speed = 10.0f;
    void Start()
    {
        // Trouver le composant Text sur le panneau UI
        if (infoPanel != null)
        {
            infoText = infoPanel.GetComponentInChildren<Text>();
            infoPanel.SetActive(false); // Masquer le panneau au début
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si c'est le joueur qui entre
        {
            if (infoPanel != null && infoText != null)
            {
                infoText.text = objectInfo; // Met à jour le texte
                infoPanel.SetActive(true); // Affiche le panneau
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Quand le joueur quitte la zone
        {
            if (infoPanel != null)
            {
                infoPanel.SetActive(false); // Masquer le panneau
            }
        }
    }
}
