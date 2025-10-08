using UnityEngine;

public class canvasScript : MonoBehaviour
{
    public GameObject textMesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMesh.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activeprompt()
    {
        textMesh.SetActive(true);
    }
    public void inActiveprompt()
    {
        textMesh.SetActive(false);
    }
}
