using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlienPropertys : MonoBehaviour
{
    public Sprite picture;
    public string occupation;
    public string homeplanet;
    public string species;
    public int age;

    [SerializeField] Image alienImage;
    [SerializeField] TMP_Text occupationText;
    [SerializeField] TMP_Text homePlanetText;
    [SerializeField] TMP_Text speciesText;
    [SerializeField] TMP_Text ageText;

    public void Setup()
    {
        alienImage.sprite = picture;
        occupationText.text = occupation;
        homePlanetText.text = homeplanet;
        speciesText.text = species;
        ageText.text = age.ToString();
    }
}