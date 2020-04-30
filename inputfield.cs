using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputfield : MonoBehaviour
{

    public static string dada;
    public static string[] words;
    public InputField inputField;
    public GameObject textDisplay;

    private int limit = 20;

    public void Storedada()
    {

        //dada = inputField.GetComponent<Text>().text;
        
        dada = inputField.text;
        string[] tempwords = dada.Split(' ');
        words = tempwords;

       
        
        





         //textDisplay.GetComponent<Text>().text = dada;
    }
    // Start is called before the first frame update

}
