using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardsGA : GameAction
{
    public int Amout {  get; set; }
    public DrawCardsGA(int amout)
    {
        Amout = amout;
    }
}
