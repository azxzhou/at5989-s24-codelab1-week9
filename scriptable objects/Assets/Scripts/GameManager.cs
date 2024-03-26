using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI titleUI;
    public TextMeshProUGUI descUI;

    public LocationScriptableObject currentLocation;

    public Button buttonNorth;
    public Button buttonSouth;
    public Button buttonEast;
    public Button buttonWest;
    
    // Start is called before the first frame update
    void Start()
    {
        //hookup with scriptable object code
        currentLocation.PrintLocation();
        currentLocation.UpdateCurrentLocation(this);
    }
    
    public void MoveDir(string dirChar)
    {
        switch (dirChar)
        {
            case "N":
                currentLocation = currentLocation.north;
                break;
            
            case "S":
                currentLocation = currentLocation.south;
                break;
            
            case "E":
                currentLocation = currentLocation.east;
                break;
            
            case "W":
                currentLocation = currentLocation.west;
                break;
            default:
                Debug.Log("ya broked it");
                break;
            
        }
        
        currentLocation.UpdateCurrentLocation(this);
    }
}
