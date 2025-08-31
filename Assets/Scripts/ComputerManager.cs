using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//This is a horribly coded script to manage the computer
//This will be fixed with a state machine in the future (if this game has a future)
public class ComputerManager : MonoBehaviour
{
    [SerializeField] GameObject pnlLogin;
    [SerializeField] GameObject pnlDesktop;
    [SerializeField] GameObject pnlEmail;
    [Space]
    //Desktop
    [SerializeField] GameObject emailTab;
    [Space]
    //Email App
    [SerializeField] GameObject pnlInbox;
    [SerializeField] GameObject pnlSent;
    [SerializeField] GameObject pnlBin;
    [Space]
    [SerializeField] GameObject WelcomeEmailRecieved;
    [SerializeField] GameObject BossEmailRecieved;
    [Space]
    //Login
    [SerializeField] InputField username;
    [SerializeField] InputField password;
    [Space]
    //Forward Email
    [SerializeField] GameObject pnlEmailForwardPrompt;
    [SerializeField] GameObject EmailForwardConfirmed;
    [SerializeField] GameObject EmailForwardDenied;
    public void LoginToComputer()
    {
        if (username.text == "GREENHOLDINGS" && password.text == "LOV3TH3LAND")
        {
            pnlLogin.SetActive(false);
            pnlDesktop.SetActive(true);
            pnlEmail.SetActive(false);
        }
        else Debug.Log("TODO: Incorrect password or username entered!");
    }

    public void TurnComputerOn()
    {
        pnlLogin.SetActive(true);
        pnlDesktop.SetActive(false);
        pnlEmail.SetActive(false);
    }

    public void ShowEmailApplication()
    {
        pnlLogin.SetActive(false);
        pnlDesktop.SetActive(true);
        pnlEmail.SetActive(true);

        emailTab.SetActive(true);
    }

    public void HideEmailApplication()
    {
        pnlLogin.SetActive(false);
        pnlDesktop.SetActive(true);
        pnlEmail.SetActive(false);

        emailTab.SetActive(false);
    }

    public void MinimiseEmailApplication()
    {
        pnlLogin.SetActive(false);
        pnlDesktop.SetActive(true);
        pnlEmail.SetActive(false);

        emailTab.SetActive(true);
    }

    //Email App

    public void ShowInboxMessages()
    {
        pnlInbox.SetActive(true);
        pnlSent.SetActive(false);
        pnlBin.SetActive(false);
    }

    public void ShowSentMessages()
    {
        pnlInbox.SetActive(false);
        pnlSent.SetActive(true);
        pnlBin.SetActive(false);
    }

    public void ShowBinnedMessages()
    {
        pnlInbox.SetActive(false);
        pnlSent.SetActive(false);
        pnlBin.SetActive(true);
    }

    //Emails Recieved
    public void ShowWelcomeEmail()
    {

    }

    public void ShowBossEmail()
    {

    }

    //Emails Sent

    public void ShowTiagoSilvaEmail()
    {

    }

    public void ShowForwardEmailPrompt()
    {

    }
}
