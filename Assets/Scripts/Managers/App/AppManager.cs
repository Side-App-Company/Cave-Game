using UnityEngine;

public class AppManager : MonoBehaviour,
    IPubAccess<SceneEvent>
{
    [SerializeField]
    Hub hub;

    void Start()
    {
        this.hub.getSceneSubAccess().subscribe(this);
    }

/********** Scene Events **********/
    public void publishEvent(SceneEvent e)
    {
        UnityEngine.Debug.Log(e.sceneEvent);
    }

/********** Clean Up **********/
    void OnDestroy()
    {
        this.hub.getSceneSubAccess().unsubscribe(this);
    }
}
