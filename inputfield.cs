using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputfield : MonoBehaviour
{

    public static string dada;
    public GameObject inputField;
    public GameObject textDisplay;

    public void Storedada()
    {

        dada = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = dada;
            }
    // Start is called before the first frame update
   
}
