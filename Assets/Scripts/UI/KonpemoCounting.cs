using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KonpemoCounting : MonoBehaviour
{
    [SerializeField] private TMP_Text nbKonpemoText;
    public static int konpemoCount = 0;
    public static int nbKonpemoMax = 5;

    [SerializeField] private TMP_Text nbEvorenText;
    public static int evorenCount = 0;

    [SerializeField] private TMP_Text nbSourimiText;
    public static int sourimiCount = 0;

    [SerializeField] private TMP_Text nbKairocheText;
    public static int kairocheCount = 0;

    [SerializeField] private TMP_Text nbSerbiereText;
    public static int serbiereCount = 0;

    [SerializeField] private TMP_Text nbNinjaxText;
    public static int ninjaxCount = 0;

    [SerializeField] private TMP_Text nbCaspowText;
    public static int caspowCount = 0;

    [SerializeField] private TMP_Text nbBeatowtronText;
    public static int beatowtronCount = 0;

    [SerializeField] private TMP_Text nbCaillebonbonText;
    public static int caillebonbonCount = 0;

    [SerializeField] private TMP_Text nbMagitruiteText;
    public static int magitruiteCount = 0;

    public void Update()
    {
        nbKonpemoText.text = "(" + konpemoCount.ToString() + "/" + nbKonpemoMax + ")";

        nbEvorenText.text = evorenCount.ToString();
        nbSourimiText.text = sourimiCount.ToString();
        nbKairocheText.text = kairocheCount.ToString();
        nbSerbiereText.text = serbiereCount.ToString();
        nbNinjaxText.text = ninjaxCount.ToString();
        nbCaspowText.text = caspowCount.ToString();
        nbBeatowtronText.text = beatowtronCount.ToString();
        nbCaillebonbonText.text = caillebonbonCount.ToString();
        nbMagitruiteText.text = magitruiteCount.ToString();

    }

    public void KonpemoCounter()
    {
        konpemoCount = evorenCount + sourimiCount + kairocheCount + serbiereCount + ninjaxCount + caspowCount + beatowtronCount + caillebonbonCount + magitruiteCount;
    }

    public void KonpemoCounterIncrease(string konpemo)
    {
        if (konpemoCount < 5)
        {
            switch (konpemo)
            {
                case "Evoren":
                    evorenCount++;
                    break;
                case "Sourimi":
                    sourimiCount++;
                    break;
                case "Kairoche":
                    kairocheCount++;
                    break;
                case "Serbiere":
                    serbiereCount++;
                    break;
                case "Ninjax":
                    ninjaxCount++;
                    break;
                case "Caspow":
                    caspowCount++;
                    break;
                case "Beatowtron":
                    beatowtronCount++;
                    break;
                case "Caillebonbon":
                    caillebonbonCount++;
                    break;
                case "Magitruite":
                    magitruiteCount++;
                    break;

                default: Debug.Log("Can't add Konpemo"); break;
            }
        }
        KonpemoCounter();
    }

    public void KonpemoCounterDecrease(string konpemo)
    {
        switch (konpemo)
        {
            case "Evoren":
                if (evorenCount > 0) evorenCount--;
                break;
            case "Sourimi":
                if (sourimiCount > 0) sourimiCount--;
                break;
            case "Kairoche":
                if (kairocheCount > 0) kairocheCount--;
                break;
            case "Serbiere":
                if (serbiereCount > 0) serbiereCount--;
                break;
            case "Ninjax":
                if (ninjaxCount > 0) ninjaxCount--;
                break;
            case "Caspow":
                if (caspowCount > 0) caspowCount--;
                break;
            case "Beatowtron":
                if (beatowtronCount > 0) beatowtronCount--;
                break;
            case "Caillebonbon":
                if (caillebonbonCount > 0) caillebonbonCount--;
                break;
            case "Magitruite":
                if (magitruiteCount > 0) magitruiteCount--;
                break;

            default: break;
        }
        KonpemoCounter();
    }
}
