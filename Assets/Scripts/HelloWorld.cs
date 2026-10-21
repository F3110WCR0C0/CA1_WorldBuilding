using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // public string myName
    // Serialzed Field allows to use private variables in the inspector
    [SerializeField] string myName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello: " + myName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
