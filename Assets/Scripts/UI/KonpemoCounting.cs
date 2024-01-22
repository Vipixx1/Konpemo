using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KonpemoCounting : MonoBehaviour
{
    [SerializeField] private TMP_Text nbKonpemoText;
    //public static int konpemoCount = 0;
    public static int nbKonpemoMax = 5;
    public static List<Konpemo> konpemosBlue = new();

    [SerializeField] private TMP_Text nbEvorenText;
    [SerializeField] private Evoren evorenPrefab;
    public static int evorenCount = 0;

    [SerializeField] private TMP_Text nbSourimiText;
    [SerializeField] private Sourimi sourimiPrefab;
    public static int sourimiCount = 0;

    [SerializeField] private TMP_Text nbKairocheText;
    [SerializeField] private Kairoche kairochePrefab;
    public static int kairocheCount = 0;

    [SerializeField] private TMP_Text nbSerbiereText;
    [SerializeField] private Serbiere serbierePrefab;
    public static int serbiereCount = 0;

    [SerializeField] private TMP_Text nbNinjaxText;
    [SerializeField] private Ninjax ninjaxPrefab;
    public static int ninjaxCount = 0;

    [SerializeField] private TMP_Text nbCaspowText;
    [SerializeField] private Caspow caspowPrefab;
    public static int caspowCount = 0;

    [SerializeField] private TMP_Text nbBeatowtronText;
    [SerializeField] private Beatowtron beatowtronPrefab;
    public static int beatowtronCount = 0;

    [SerializeField] private TMP_Text nbCaillebonbonText;
    [SerializeField] private Caillebonbon caillebonbonPrefab;
    public static int caillebonbonCount = 0;

    [SerializeField] private TMP_Text nbMagitruiteText;
    [SerializeField] private Magitruite magitruitePrefab;
    public static int magitruiteCount = 0;

    public void Update()
    {
        nbKonpemoText.text = string.Format("({0}/{1})", konpemosBlue.Count, nbKonpemoMax);

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

    public void KonpemoCounterIncrease(string konpemo)
    {
        Enum.TryParse<KonpemoSpecies>(konpemo, out KonpemoSpecies konpemoSpecies);

        if (konpemosBlue.Count < nbKonpemoMax)
        {
            switch (konpemoSpecies)
            {
                case KonpemoSpecies.Evoren:
                    evorenCount++;
                    konpemosBlue.Add(evorenPrefab);
                    break;

                case KonpemoSpecies.Sourimi:
                    sourimiCount++;
                    konpemosBlue.Add(sourimiPrefab);
                    break;

                case KonpemoSpecies.Kairoche:
                    kairocheCount++;
                    konpemosBlue.Add(kairochePrefab);
                    break;

                case KonpemoSpecies.Serbiere:
                    serbiereCount++;
                    konpemosBlue.Add(serbierePrefab);
                    break;

                case KonpemoSpecies.Ninjax:
                    ninjaxCount++;
                    konpemosBlue.Add(ninjaxPrefab);
                    break;

                case KonpemoSpecies.Caspow:
                    caspowCount++;
                    konpemosBlue.Add(caspowPrefab);
                    break;

                case KonpemoSpecies.Beatowtron:
                    beatowtronCount++;
                    konpemosBlue.Add(beatowtronPrefab);
                    break;

                case KonpemoSpecies.Caillebonbon:
                    caillebonbonCount++;
                    konpemosBlue.Add(caillebonbonPrefab);
                    break;

                case KonpemoSpecies.Magitruite:
                    magitruiteCount++;
                    konpemosBlue.Add(magitruitePrefab);
                    break;

                default: Debug.Log("Can't add Konpemo"); break;
            }
        }
    }

    public void KonpemoCounterDecrease(string konpemo)
    {
        Enum.TryParse<KonpemoSpecies>(konpemo, out KonpemoSpecies konpemoSpecies);
        switch (konpemoSpecies)
        {
            case KonpemoSpecies.Evoren:
                if (evorenCount > 0)
                {
                    foreach (Konpemo kon in konpemosBlue)
                    {
                        if (kon.GetComponent<Evoren>())
                        {
                            konpemosBlue.Remove(kon);
                            evorenCount--;
                            break;
                        }
                    }
                }
                break;

            case KonpemoSpecies.Sourimi:
                if (sourimiCount > 0)
                {
                    foreach (Konpemo kon in konpemosBlue)
                    {
                        if (kon.GetComponent<Sourimi>())
                        {
                            konpemosBlue.Remove(kon);
                            sourimiCount--;
                            break;
                        }
                    }
                }
                break;

            case KonpemoSpecies.Kairoche:
                if (kairocheCount > 0)
                {
                    foreach (Konpemo kon in konpemosBlue)
                    {
                        if (kon.GetComponent<Kairoche>())
                        {
                            konpemosBlue.Remove(kon);
                            kairocheCount--;
                            break;
                        }
                    }
                }
                break;

            case KonpemoSpecies.Serbiere:
                if (serbiereCount > 0)
                {
                    foreach (Konpemo kon in konpemosBlue)
                    {
                        if (kon.GetComponent<Serbiere>())
                        {
                            konpemosBlue.Remove(kon);
                            serbiereCount--;
                            break;
                        }
                    }
                }
                break;

            case KonpemoSpecies.Ninjax:
                if (ninjaxCount > 0)
                {
                    foreach (Konpemo kon in konpemosBlue)
                    {
                        if (kon.GetComponent<Ninjax>())
                        {
                            konpemosBlue.Remove(kon);
                            ninjaxCount--;
                            break;
                        }
                    }
                }
                break;

            case KonpemoSpecies.Caspow:
                if (caspowCount > 0)
                {
                    foreach (Konpemo kon in konpemosBlue)
                    {
                        if (kon.GetComponent<Caspow>())
                        {
                            konpemosBlue.Remove(kon);
                            caspowCount--;
                            break;
                        }
                    }
                }
                break;

            case KonpemoSpecies.Beatowtron:
                if (beatowtronCount > 0)
                {
                    foreach (Konpemo kon in konpemosBlue)
                    {
                        if (kon.GetComponent<Beatowtron>())
                        {
                            konpemosBlue.Remove(kon);
                            beatowtronCount--;
                            break;
                        }
                    }
                }
                break;

            case KonpemoSpecies.Caillebonbon:
                if (caillebonbonCount > 0)
                {
                    foreach (Konpemo kon in konpemosBlue)
                    {
                        if (kon.GetComponent<Caillebonbon>())
                        {
                            konpemosBlue.Remove(kon);
                            caillebonbonCount--;
                            break;
                        }
                    }
                }
                break;

            case KonpemoSpecies.Magitruite:
                if (magitruiteCount > 0)
                {
                    foreach (Konpemo kon in konpemosBlue)
                    {
                        if (kon.GetComponent<Magitruite>())
                        {
                            konpemosBlue.Remove(kon);
                            magitruiteCount--;
                            break;
                        }
                    }
                }
                break;

            default: break;
        }    
    }

}
