using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviourSingletonPersistent<GameManager>
{

    GameObject Player;

    [SerializeField]
    GameObject AudioManager , UIManager , NetworkManager;

    public static CustomEvents.GameStateChangeEvent gameStateChangeEvent;


    public static DataTypes.GameState currentgameState { get; private set; }

    [HideInInspector]
    public static DataTypes.GameState previousGameState { get; private set; }


    public override void Awake()
    {

        base.Awake();

        if (gameStateChangeEvent == null)
            gameStateChangeEvent = new CustomEvents.GameStateChangeEvent();

        InitializeGame();

    }


    public void ChangeGameState( DataTypes.GameState gameStatefrom , DataTypes.GameState gameStateToChange)
    {
        gameStatefrom = currentgameState;
        currentgameState = gameStateToChange;

    }


    void InitializeGame()
    {
        currentgameState = DataTypes.GameState.Intialize;
        Instantiate(AudioManager);
        Instantiate(UIManager);
        Instantiate(NetworkManager);

    }

    void GamePause()
    {
        // stop fixed update

        previousGameState = currentgameState;

        currentgameState = DataTypes.GameState.Paused;


        gameStateChangeEvent.Invoke(currentgameState, previousGameState);
    }

    void GameQuit()
    {
        previousGameState = currentgameState;

        currentgameState = DataTypes.GameState.Stopped;


        // Do things before closing


        gameStateChangeEvent.Invoke(currentgameState, previousGameState);
    }

    void GamePlay()
    {
        previousGameState = currentgameState;

        currentgameState = DataTypes.GameState.Playing;

        // play as normal


        gameStateChangeEvent.Invoke(currentgameState, previousGameState);
    }


}
