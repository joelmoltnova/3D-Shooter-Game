using UnityEngine;
using UnityEngine.SceneManagement;

public class flagGrab : MonoBehaviour
{
    public bool haveFlag;
    public Transform lookCamera;
    private RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        haveFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(new Vector3(transform.position.x,lookCamera.position.y, transform.position.z), lookCamera.forward * 1, Color.red);
        if (Physics.Raycast(new Vector3(transform.position.x, lookCamera.position.y, transform.position.z), lookCamera.forward, out hit, 1)) 
        {
            if (hit.collider.CompareTag("Objective")) 
            {
                //Debug.Log("found");
                if (Input.GetKey(KeyCode.E))
                {
                    haveFlag = true;
                    //Debug.Log("have flag");
                }
            }
        }   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (haveFlag && other.CompareTag("Finish")) 
        {
            Debug.Log("game complete");
            SceneManager.LoadScene("1 - Main Menu");
        }
    }
}
