using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script written following Jayanam's youtube tutorial https://www.youtube.com/watch?v=URS9A4V_yLc

public class DropdownHandler : MonoBehaviour
{
    public Text selected;
    public GameObject info;
 
    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();
        dropdown.options.Clear(); //clears dropdown options
        List<string> options = new List<string>();
        options.Add("Password"); //list to store dropdown options
        options.Add("Dog123");
        options.Add("Dog23");
        options.Add("DogDog#231");

        foreach(var option in options) //fill dropdown with options list
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = option });
        }
        DropdownItemSelected(dropdown);
        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
        
    }

    void DropdownItemSelected(Dropdown dropdown) //methods shows displayed text in UI under drop down menu
    {
        int index = dropdown.value;
        if (dropdown.options[index].text.Equals("Password")){ //if no option has been chosen yet
            selected.text = ("Choose A Password."); //display choose password text.
        }
        else if (dropdown.options[index].text.Equals("Dog123")) //if password chosen is one found on sticky note
        {
            selected.text = (dropdown.options[index].text + " selected.");
            info.SetActive(true); //set info object to active 
            //info object can now be viewed by player and triggers door 3 to open
        }
        else {
            selected.text = (dropdown.options[index].text + " selected."); //else display the option selected.
        }
    }
 
}
