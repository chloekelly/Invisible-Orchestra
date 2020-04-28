using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateClips : MonoBehaviour
{

    private string defaultMic;
    //private AudioSource audioSource;
    public AudioClip[] clips;
    public float timer = 0;
    public Image microphone;
    public int recordings = 0;
    private string x;
    public Text crash;
    public Text mingle;
    public Text applause;


    // Start is called before the first frame update
    void Start()

    {
        x = System.DateTime.UtcNow.ToString();
        //x = x.Substring(x.Length - 9);
        x = x.Replace("/", "");
        x = x.Replace(":", "");
        Debug.Log(x);
        microphone.enabled = false;
        //audioSource = GetComponent<AudioSource>();
        defaultMic = Microphone.devices[0];
        crash.enabled = false;
        mingle.enabled = false;
        applause.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > 5 && clips[0] == null)
        {
            clips[0] = Microphone.Start(defaultMic, false, 15, 44100);
            microphone.enabled = true;
            mingle.enabled = true;
        }
        if (timer > 20 && recordings < 1)
        {
            SavWav.Save("Mingle"+ x, clips[0], Application.dataPath + @"/mingle" );  //@"C:\Users\Sam\Desktop\mingle\"
            Debug.Log("Saved 1");
            microphone.enabled = false;
            recordings++;
            mingle.enabled = false;
        }

        if(timer > 34 && clips[1] == null)
        {
            Debug.Log("Starting");
            clips[1] = Microphone.Start(defaultMic, false, 15, 44100);
            Debug.Log("Started");
            microphone.enabled = true;
            crash.enabled = true;
            }
        if (timer > 45 && recordings < 2)
        {
            SavWav.Save("Crash" + x, clips[1], Application.dataPath + @"/crash");
            microphone.enabled = false;
            recordings++;
            crash.enabled = false;
        }

        if (timer > 66 && clips[2] == null)
        {
            Debug.Log("Starting");
            clips[2] = Microphone.Start(defaultMic, false, 15, 44100);
            Debug.Log("Started");
            microphone.enabled = true;
            crash.enabled = true;
        }
        if (timer > 76 && recordings < 3)
        {
            SavWav.Save("Crash" + x, clips[2], Application.dataPath + @"/crash");
            microphone.enabled = false;
            recordings++;
            crash.enabled = false;
        }

        if(timer > 193 && clips[3] == null)
        {
            clips[3] = Microphone.Start(defaultMic, false, 15, 44100);
            microphone.enabled = true;
            applause.enabled = true;
        }

        if(timer > 213 && recordings < 4)
        {
            SavWav.Save("Applause" + x, clips[3], Application.dataPath + @"/applause");
            microphone.enabled = false;
            recordings++;
            applause.enabled = false;
        }
     


    }
}
