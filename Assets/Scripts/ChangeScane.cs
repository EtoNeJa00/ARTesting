using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class ChangeScane : MonoBehaviour
{
    public GameObject AR;
    ARSession aRSesion;
    // Start is called before the first frame update
    void Start()
    {
        aRSesion = AR.GetComponent<ARSession>();
    }

    // Update is called once per frame
    public void ChangeS(string scane)
    {
        aRSesion.Reset();
        SceneManager.LoadScene(scane);
    }
}
