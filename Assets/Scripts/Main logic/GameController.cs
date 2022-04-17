using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    public NavMeshAgent PlayerCharacterAgent;
    public Animator PlayerCharacterAnimator;

    public GameObject BulletPrefab;
    public Transform BulletSpawnPoint;

    private void Awake()
    {
        InitializeGame();
    }
    void Start()
    {

    }


    void Update()
    {

        PlayerControls.PlayerStanceCheck();
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            PlayerControls.PlayerTapProcessing();
        }
    }
    private void InitializeGame()
    {
        GameData.BuildLevels();
        PlayerControls.gc = this;
    }
}
