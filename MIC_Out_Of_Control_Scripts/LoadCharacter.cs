using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public TMP_Text[] label;
    public Transform spawnPoint;
    public static LoadCharacter instance;

    void Start ()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        Debug.Log(selectedCharacter);


        GameObject prefab = characterPrefabs[selectedCharacter];
        prefab.SetActive(true);
        Debug.Log(prefab);

        Debug.Log (PlayerPrefs.GetString("namePlayer"));
        Debug.Log(label[selectedCharacter].text);

        if (PlayerPrefs.GetString("namePlayer") != null)
            label[selectedCharacter].text = PlayerPrefs.GetString("namePlayer");
        else label[selectedCharacter].text = null;

        Debug.Log (label[selectedCharacter].text);

        //label[selectedCharacter].rectTransform.rotation.y = 0f;
    }
}