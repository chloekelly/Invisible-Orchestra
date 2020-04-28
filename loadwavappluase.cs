using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class loadwavappluase : MonoBehaviour
{
    private AudioSource myAudio;
    public string folder;
    public float timer;
    public AudioClip[] sounds;
    public bool mingle = false;


    // Start is called before the first frame update
    void Awake()
    {
        folder = "applause";

        DirectoryInfo dir = new DirectoryInfo(Application.dataPath + @"/" + folder);
        FileInfo[] info = dir.GetFiles("*.wav");

        sounds = new AudioClip[info.Length];
        int c = 0;
        foreach (FileInfo f in info)
        {
            Debug.Log(f.ToString());
            sounds[c] = WavUtility.ToAudioClip(Application.dataPath + @"/" + folder + @"/" + Path.GetFileName(f.ToString()));
            sounds[c].name = Path.GetFileName(f.ToString());
            c++;
        }
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = sounds[Random.Range(0, sounds.Length)];


    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > 100 && mingle == false)
        {
            myAudio.Play();
            mingle = true;

        }
        if (timer > 115)
        {


        }
    }
}

