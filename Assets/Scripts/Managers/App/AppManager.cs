using UnityEngine;

public class AppManager : MonoBehaviour,
    IPubAccess<SceneEvent>
{
    [SerializeField]
    private Hub hub;

    void Start()
    {
        this.hub.getSceneSubAccess().subscribe(this);
    }

/********** Scene Events **********/
    public void publishEvent(SceneEvent e)
    {
        
    }

/********** Clean Up **********/
    void OnDestroy()
    {
        this.hub.getSceneSubAccess().unsubscribe(this);
    }
}
