using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public static class PlayerControls
{
    public static GameController gc;
    public static bool PhoneControls = false;

    public static void PlayerTapProcessing()
    { //handling players input
        Shoot();
    }
    private static void Shoot()
    {
        GameObject bullet = GameObject.Instantiate(gc.BulletPrefab, gc.BulletSpawnPoint.position, Quaternion.identity);
        if (PhoneControls)
        {
            bullet.GetComponent<Rigidbody>().AddForce(Camera.main.ScreenPointToRay(Input.touches[0].position).direction * 350);
        }
        else
        {
            bullet.GetComponent<Rigidbody>().AddForce(Camera.main.ScreenPointToRay(Input.mousePosition).direction * 350);
        }
    }
    public static void PlayerStanceCheck()
    {
        gc.PlayerCharacterAnimator.SetFloat("Speed", gc.PlayerCharacterAgent.velocity.sqrMagnitude);
        if (gc.PlayerCharacterAgent.pathStatus == NavMeshPathStatus.PathComplete && gc.PlayerCharacterAgent.remainingDistance == 0)
        {
            if (GameData.Levels[GameData.CurrentLevel].EnemiesCount <= 0)
            {
                //all enemies killed, going to next level
                GameData.CurrentLevel++;
                if (GameData.CurrentLevel >= GameData.Levels.Length)
                {
                    //restart the scene
                    Debug.Log("Restarting game");
                    GameData.CurrentLevel = 0;
                    SceneManager.LoadScene(0);
                }
                else
                {
                    gc.PlayerCharacterAgent.destination = GameData.Levels[GameData.CurrentLevel].LevelWayPoint;
                }
            }
        }
    }
}
