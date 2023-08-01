using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unravel.Scenes;

public class GameSceneManager : MonoBehaviour
{
    Hub hub;

    private float timer = 5.0f;
    private bool marked = false;

    void Awake()
    {
        this.hub = GameObject.FindWithTag("Hub").GetComponent<Hub>();
    }

    void Update()
    {
        this.timer -= Time.deltaTime;

        if(!this.marked && this.timer <= 0.0f)
        {
            this.marked = true;
            this.hub.getSceneAccess().markSceneReady(SCENE.GAME);
        }
    }
}
