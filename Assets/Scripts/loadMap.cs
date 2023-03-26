using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadMap : MonoBehaviour
{
    public string mapName;
    public void OnButtonPress()
    {
        SceneManager.LoadScene(mapName);
    }
}
