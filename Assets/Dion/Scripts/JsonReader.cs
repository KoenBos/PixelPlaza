using UnityEngine;
using System.IO;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class JsonReader : MonoBehaviour
{
    //Text object
    [SerializeField] private TextMeshProUGUI textbox;

    // The C# object to deserialize the JSON data into
    [System.Serializable]
    public class CharacterData
    {
        public int ID;
        public string firstname;
        public string lastname;
        public int cohort;
        public string portfoliolink;
        public string charactersprite;
        public string walkingspritesheet;
    }

    public class CharacterObjects
    {
        public CharacterData[] characterArray;
    }

    void Start()
    {
        StartCoroutine(GetRequest("http://10.112.123.255/WebsiteTeam13/updateJson.php"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:

                    string jsonString = webRequest.downloadHandler.text;

                    // Deserialize the JSON data into the C# object
                    CharacterObjects characters = JsonUtility.FromJson<CharacterObjects>("{\"characterArray\":" + jsonString + "}");

                    // Print the count of the characterList to the console
                    Debug.Log("Character List Count: " + characters.characterArray.Length);

                    textbox.text = "entries: " + characters.characterArray.Length + "\n";

                    // Use the deserialized data as needed
                    foreach (CharacterData character in characters.characterArray)
                    {
                        textbox.text += "ID: " + character.ID + ", First Name: " + character.firstname + ", Last Name: " + character.lastname + ", Cohort: " + character.cohort + ", Portfolio Link: " + character.portfoliolink + ", Character Sprite: " + character.charactersprite + ", Walking Sprite Sheet: " + character.walkingspritesheet + "\n";
                    }
                    break;
            }
        }
    }
}



