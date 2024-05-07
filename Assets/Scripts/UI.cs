using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    VisualElement rootVE;

    public Label AttractiveBullets;
    public Label RepulsiveBullets;

    void OnEnable()
    {
        rootVE = GetComponent<UIDocument>().rootVisualElement;

        AttractiveBullets = rootVE.Q<Label>("AttractiveBullets");
        RepulsiveBullets = rootVE.Q<Label>("RepulsiveBullets");
    }

    void Start()
    {
        UpdateBulletCount();
    }

    void Update()
    {
        AdjustFontSize();
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
        AttractiveBullets.style.fontSize = newFontSize;
        RepulsiveBullets.style.fontSize = newFontSize;
    }
}
