using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text counter; //UI text game object
    GameController gc;
    private int total = 4; //int to store number of sorted collectibles
    private int sorted;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    void FixedUpdate()
    {
        sorted = total - gc.collectible; 
        counter.text = (sorted+"/"+total); //counter text displays the following in the text UI
        //gc.collectible is number of items remaining to sort
    }
}
