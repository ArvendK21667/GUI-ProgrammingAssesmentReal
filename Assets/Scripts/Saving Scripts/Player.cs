using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 3;
    public float score = 100;

    public void SavePlayer() //Saves Player
    {
        //SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() //Load players
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        score = data.score;

        Vector2 position; // Position
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;
    }

    public void ChangeLevel(int amount) // Changes Scene (Level of Game)
    {
        level += amount;
    }
    public void ChangeScore(int amount)  // Changes score (Score of Game)
    {
        score += amount;
    }

}
