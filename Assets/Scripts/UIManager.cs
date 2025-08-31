using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Canvases")]
    Canvas mainMenu;
    Canvas settings;
    Canvas credits;
    public void StartGame()
    {
        Scene.LoadScene("Reception");
    }

    public void ExitGame()
    {
        Scene.ExitGame();
    }

    public void OpenSettings()
    {
        mainMenu.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        settings.gameObject.SetActive(true);
    }
    public void OpenCredits()
    {
        mainMenu.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
        settings.gameObject.SetActive(false);
    }
    public void BackToMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        credits.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
    }
}
