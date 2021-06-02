using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public float score;
    public float[] position;

    public PlayerData (BirdBoiScript player) //PlayerData
    {
        level = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        score = player.Score.endofTime;

        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }
}
