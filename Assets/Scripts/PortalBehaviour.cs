using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehaviour : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("LastUnlockedLevel", nextSceneName);
            PlayerPrefs.Save();
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
