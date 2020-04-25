using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Webcam : MonoBehaviour
{

    int currentCamIndex = 0;

    WebCamTexture tex;

    public RawImage display; 
    // Start is called before the first frame update
    void Start()
    {
        if (tex != null)
        {
            display.texture = null;
            tex.Stop();
            tex = null;
        }
        else
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;

            tex.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
