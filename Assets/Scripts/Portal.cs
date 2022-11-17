using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Collidable
{
    public string[] sceneNames;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            GameManager.instance.SaveState();
            string sceneNames = this.sceneNames[Random.Range(0, this.sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNames);
        }
    }
}
