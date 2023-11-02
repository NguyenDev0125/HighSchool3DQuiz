using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUIController : MonoBehaviour
{
    public GameObject homeMenu;
    public GameObject selectQuesMenu;
    public LoginPanel loginPanel;

    public Button startBtn;
    public Button settingBtn;
    public Button quitBtn;
    public Button openLoginBtn;


    private void Awake()
    {
        startBtn.onClick.AddListener(OpenSelectQuesMenu);
        settingBtn.onClick.AddListener(OpenSettingMenu);
        quitBtn.onClick.AddListener(QuitGame);
        openLoginBtn.onClick.AddListener(OpenLoginMenu);
    }
    private void Start()
    {
        loginPanel.AutoLogin();
    }
    private void OpenSelectQuesMenu()
    {
        selectQuesMenu.SetActive(true);
        homeMenu.SetActive(false);
    }

    private void OpenSettingMenu()
    {
        // TODO : Setting
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void OpenLoginMenu()
    {
        loginPanel.gameObject.SetActive(true);
    }
}
