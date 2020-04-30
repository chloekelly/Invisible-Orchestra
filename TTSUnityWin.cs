﻿using UnityEngine;
using System.Collections;
using SpeechLib;
using System.Xml;
using System.IO;
using UnityEngine.UI;

/**************************************************************************************
 * ******************Text to Speech for Windows SAPI *********************************
 * ************************************************************************************
 * v 1.0 - 01/01/2016
 * Marco Martinelli 
 * marco.m@gamesource.it
 * 
 * 
 * Tested on Windows 10, SAPI 4.0 | Windows 8.1
 * More info on www.finalmarco.com
/*************************************************************************************/



public class TTSUnityWin : MonoBehaviour {

	private SpVoice voice;
    public GameObject tts;

/// CODE FOR LOAD XML OR OTHER TEXT FILES IN THE SISTEM FROM THE FOLDER RESOURCE

	string loadXMLStandalone (string fileName) {
		
		string path  = Path.Combine("Resources", fileName);
		path = Path.Combine (Application.dataPath, path);
		Debug.Log ("Path:  " + path);
		StreamReader streamReader = new StreamReader (path);
		string streamString = streamReader.ReadToEnd();
		Debug.Log ("STREAM XML STRING: " + streamString);
		return streamString;
	}
///




	//Resources.Load('builtIn.xml') as Texture;

/// PRINT ON SCREEN SAPI VOICES INSTALLED IN THE OS
	void OnGUI() {
	
		SpObjectTokenCategory tokenCat = new SpObjectTokenCategory();
		tokenCat.SetId(SpeechLib.SpeechStringConstants.SpeechCategoryVoices, false);
		ISpeechObjectTokens tokens = tokenCat.EnumerateTokens(null, null);
		
		int n = 0;
		foreach (SpObjectToken item in tokens)
		{
			//	GUILayout.Label( "Voice"+ n +" ---> "+ item.GetDescription(0));
			    n ++;
		}
		//GUILayout.Label( "There are "+ n +" SAPI voices installed in your OS | Press SPACE for start TEST");
	
		//Set a voice (if not using XML)
	//	voice.Voice = (tokens.Item (3)); // Comment this line if you use XML parser for choice voices, force a voice over the def one.

	}

    

	string BuiltAsset = "";

	void Start(){
    //print (loadXMLStandalone ("fottiti.xml"));	

		voice = new SpVoice();
        voice.Volume = 100; // Volume (no xml)

        //TextAsset txt = (TextAsset)Resources.Load("readme", typeof(TextAsset));
        //	TextAsset txt = (TextAsset)Resources.Load("builtIn.xml", typeof(XmlText));
        //	TextAsset textXML = (TextAsset)Resources.Load("builtIn", typeof(TextAsset));
        //	BuiltAsset = textXML.text;
        //TextAsset textAsset = (TextAsset) Resources.Load("builtIn.xml");  

    }
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("return"))
		{
            int i = Random.Range(0, inputfield.words.Length);
            voice.Speak(inputfield.words[i], SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFIsXML);
            /***************************************************
			 * Userful resources for Country codes and SAPI XML fomat
			 * https://msdn.microsoft.com/en-us/library/ms723602(v=vs.85).aspx
			 * https://msdn.microsoft.com/en-us/library/ms717077(v=vs.85).aspx
			 * https://msdn.microsoft.com/en-us/library/windows/desktop/dd318693(v=vs.85).aspx
			 * https://msdn.microsoft.com/en-us/library/jj127898.aspx
			/**************************************************/


            
			//voice.Rate = 0 ;  //   Rate (no xml)

            tts.GetComponent<Text>().text += inputfield.words[i];
            tts.GetComponent<Text>().text += " ";



        }
		if (Input.GetKeyDown(KeyCode.P))
		{
			voice.Pause();
			
		}
		
		
		//TEST PER ANDROID
		/*	if (Input.GetTouch)
		{

			voice.Resume();
		}*/
		
		
	}
}


