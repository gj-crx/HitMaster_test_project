using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static int CurrentLevel = 0;
    public static Level[] Levels;


    public static int GetIndexOutOfName(string s)
    {
       return int.Parse(s.Substring(s.IndexOf("_") + 1));
    }
    public struct Level
    {
        public Vector3 LevelWayPoint;
        public int EnemiesCount;
        public bool Complited;
    }
    public static void BuildLevels()
    {
        GameObject[] LevelObjects = GameObject.FindGameObjectsWithTag("Level");
        Levels = new Level[LevelObjects.Length];
        foreach (var v in LevelObjects)
        {
            int LevelNumber = GetIndexOutOfName(v.name);
            Levels[LevelNumber] = new Level();
        }

        foreach (var v in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            int LevelNumber = GetIndexOutOfName(v.transform.parent.gameObject.name);
            Levels[LevelNumber].LevelWayPoint = v.transform.position;
        }

        foreach (var v in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            int LevelNumber = GetIndexOutOfName(v.transform.parent.gameObject.name);
            Levels[LevelNumber].EnemiesCount++;
        }
    }
}
