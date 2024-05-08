using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    VisualElement rootVE;

    public Label AttractiveBullets;
    public Label RepulsiveBullets;

    private Label QuitText;
    private Label QuitLabel;

    private VisualElement pauseMenu;

    void OnEnable()
    {
        rootVE = GetComponent<UIDocument>().rootVisualElement;

        AttractiveBullets = rootVE.Q<Label>("AttractiveBullets");
        RepulsiveBullets = rootVE.Q<Label>("RepulsiveBullets");
        QuitLabel = rootVE.Q<Label>("QuitLabel");
        QuitText = rootVE.Q<Label>("QuitText");
        pauseMenu = rootVE.Q<VisualElement>("PauseMenu");
    }

    void Start()
    {
        UpdateBulletCount();
    }

    void Update()
    {
        AdjustFontSize();
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (pauseMenu.style.display != DisplayStyle.Flex)
            {
                pauseMenu.style.display = DisplayStyle.Flex;
            }
            else
            {
                pauseMenu.style.display = DisplayStyle.None;
            }
        }
        if (pauseMenu.style.display == DisplayStyle.Flex)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                UnityEngine.Cursor.visible = true;
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("StartMenu");
            }
        }
    }

    public void UpdateBulletCount()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GunBehaviour gb = player.GetComponentInChildren<GunBehaviour>();
        AttractiveBullets.text = gb.attractiveBulletsAmmo.ToString();
        RepulsiveBullets.text = gb.repulsiveBulletsAmmo.ToString();
    }

    void AdjustFontSize()
    {
        float screenWidth = Screen.width;
        float baseScreenWidth = 1920f;

        float newFontSize = (screenWidth / baseScreenWidth) * 50;
        float newQuitLabelFontSize = (screenWidth / baseScreenWidth) * 28;
        float newQuitTextFontSize = (screenWidth / baseScreenWidth) * 32;
        AttractiveBullets.style.fontSize = newFontSize;
        RepulsiveBullets.style.fontSize = newFontSize;
        QuitLabel.style.fontSize = newQuitLabelFontSize;
        QuitText.style.fontSize = newQuitTextFontSize;
    }
}
