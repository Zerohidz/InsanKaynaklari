using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMB<GameController>
{
    public GameState MyProperty { get; set; }
    public int Day { get; set; }
}

