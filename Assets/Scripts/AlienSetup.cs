using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSetup : MonoBehaviour
{
    [Header("Spawn propertys")]
    public int spawnAmount = 1;

    [Header("References")]
    public PossibleAlienPrpertys possibleAlienPrpertys;
    public GameObject alienPrpertys;

    public Transform alienFolder;

    [SerializeField] AlienManager alienManagerScript;

    void Start()
    {
        CreateAlien(spawnAmount);
    }

    void CreateAlien(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject x = Instantiate(alienPrpertys);
            x.transform.SetParent(alienFolder);

            x.GetComponent<AlienPropertys>().picture = possibleAlienPrpertys.picture[Random.Range(0, possibleAlienPrpertys.picture.Count)];
            x.GetComponent<AlienPropertys>().occupation = possibleAlienPrpertys.occupation[Random.Range(0, possibleAlienPrpertys.occupation.Count)];
            x.GetComponent<AlienPropertys>().homeplanet = possibleAlienPrpertys.homeplanet[Random.Range(0, possibleAlienPrpertys.homeplanet.Count)];
            x.GetComponent<AlienPropertys>().species = possibleAlienPrpertys.species[Random.Range(0, possibleAlienPrpertys.species.Count)];
            x.GetComponent<AlienPropertys>().age = Random.Range(0, 99);

            x.GetComponent<AlienPropertys>().Setup();


            alienManagerScript.aliensSpawned.Add(x);
        }
    }
}