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

    public void UpdateBulletCount()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GunBehaviour gb = player.GetComponentInChildren<GunBehaviour>();
        AttractiveBullets.text = gb.attractiveBulletsAmmo.ToString();
        RepulsiveBullets.text = gb.repulsiveBulletsAmmo.ToString();
        print(gb.attractiveBulletsAmmo);
    }
}
