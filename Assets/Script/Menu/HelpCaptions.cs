using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script handler for help captions
/// </summary>

public class HelpCaptions : MonoBehaviour
{

    public Text closeButtonCaption;
    public Text titleCaption;
    public Text[] helpLineCaption;

    private readonly bool helpForAndroid = true;

    // Modify captions
    public void ChangeCaptions()
    {
        switch (DataManagement.data.languageIndex)
        {
            case 0:
                // English
                closeButtonCaption.text = "Close";
                titleCaption.text = "How to play";
                helpLineCaption[0].text = "";
                helpLineCaption[1].text = "Fill lines to destroy them";
                helpLineCaption[2].text = "Level increases for each 10 lines destroyed";
                helpLineCaption[3].text = "Don't let pieces touch the top part of screen";
                helpLineCaption[4].text = "";

                if (helpForAndroid)
                {
                    helpLineCaption[5].text = "Arrows on left part of HUD move piece";
                    helpLineCaption[6].text = "Arrows on left part of HUD rotate piece";
                    helpLineCaption[7].text = "";
                }
                else
                {
                    helpLineCaption[5].text = "Arrows keys are used to move piece";
                    helpLineCaption[6].text = "H or J are used to rotate the piece";
                    helpLineCaption[7].text = "Escape or P are used for pausing game";
                }
                break;
            case 1:
                // French
                closeButtonCaption.text = "Fermer";
                titleCaption.text = "Comment jouer";
                helpLineCaption[0].text = "";
                helpLineCaption[1].text = "Remplissez les lignes pour les détruire";
                helpLineCaption[2].text = "Le niveau augmente pour chaque 10 lignes détruites";
                helpLineCaption[3].text = "Ne laissez pas les briques toucher la partie haute de l'écran";
                helpLineCaption[4].text = "";
                if (helpForAndroid)
                {
                    helpLineCaption[5].text = "Les flèches sur la partie gauche bougent la pièce";
                    helpLineCaption[6].text = "Les flèches sur la partie droite tournent la pièce";
                    helpLineCaption[7].text = "";
                }
                else
                {
                    helpLineCaption[5].text = "Les flèches bougent la pièce";
                    helpLineCaption[6].text = "Les touches H et J font tourner la pièce";
                    helpLineCaption[7].text = "Les touches Esc et P mettent le jeu en pause";
                }
                break;
        }
    }
}
