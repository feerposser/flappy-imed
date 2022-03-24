using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GameController;

public class AddScoreCollision : MonoBehaviour
{
    public int score = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameController.instance.SetPoint(score);
        }
    }

}
