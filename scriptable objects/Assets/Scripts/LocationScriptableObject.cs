using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu
    (fileName = "New Location",
     menuName = "ScriptableObjectLocation",
     order = 0)
]
public class LocationScriptableObject : ScriptableObject
{
    public string locationName;
    public string locationDesc;

    public LocationScriptableObject north;
    public LocationScriptableObject south;
    public LocationScriptableObject east;
    public LocationScriptableObject west;

    //define scriptable object that you can create from unity gameobject menu
    public void PrintLocation()
    {
        string printStr =
            "\nLocation Name: " + locationName +
            "\nLocation Description: " + locationDesc;
        
        Debug.Log("hello");
    }

    //tell game manager what to display where - must hook up in game manager as well
    public void UpdateCurrentLocation(GameManager gm)
    {
        gm.titleUI.text = locationName;
        gm.descUI.text = locationDesc;

        if (north == null)
        {
            gm.buttonNorth.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonNorth.gameObject.SetActive(true);
            north.south = this;
        }

        if (south == null)
        {
            gm.buttonSouth.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonSouth.gameObject.SetActive(true);
            south.north = this;
        }
        
        if (east == null)
        {
            gm.buttonEast.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonEast.gameObject.SetActive(true);
            east.west = this;
        }
        
        if (west == null)
        {
            gm.buttonWest.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonWest.gameObject.SetActive(true);
            west.east = this;
        }
    }
}
