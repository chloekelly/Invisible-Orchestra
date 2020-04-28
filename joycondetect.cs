using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class joycondetect : MonoBehaviour


{
    // Start is called before the first frame update

    public Image tick;
    public Image cross;
    private Joycon j;
    void Start()

    {


        // get the public Joycon object attached to the JoyconManager in scene
        j = JoyconManager.Instance.j;

    }

    // Update is called once per frame
    void Update()
    {
        // make sure the Joycon only gets checked if attached
        if (j != null && j.state > Joycon.state_.ATTACHED)
        {

            cross.enabled = false;
            tick.enabled = true;
        }
        else
        {
            tick.enabled = false;
            cross.enabled = true;
        }
    }

    // Update is called once per frame
}
