using UnityEngine;

using Unravel.Scenes;

public class MainMenuSceneManager : MonoBehaviour
{
    Hub hub;

    private float timer = 2.0f;
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
            this.hub.getSceneAccess().markSceneReady(SCENE.MAIN_MENU);
        }
    }
    
    public void onStartButton()
    {
        this.hub.getSceneAccess().enqueueScene(SCENE.GAME);
    }

}
