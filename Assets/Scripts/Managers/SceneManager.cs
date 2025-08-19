using UnityEngine;
using UnityEngine.SceneManagement;

public static class Scene
{
    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void GoToMainMenu()
    {
        //SceneManager.LoadScene(0);
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
}
