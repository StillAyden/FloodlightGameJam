using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] TaskManager taskManager;

    public void sendTaskManager()
    {
        taskManager.FadeOut();
    }
}
