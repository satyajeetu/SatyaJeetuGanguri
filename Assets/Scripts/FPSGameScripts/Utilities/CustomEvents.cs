using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomEvents 
{
    [System.Serializable]
    public  class GameStateChangeEvent : UnityEvent<DataTypes.GameState , DataTypes.GameState>
    {

    }

    [System.Serializable]
    public class WeaponChanged : UnityEvent<Sprite , int >
    {

    }



}
