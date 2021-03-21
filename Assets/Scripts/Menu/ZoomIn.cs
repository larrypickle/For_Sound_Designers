using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ZoomIn : MonoBehaviour
{
    public Transform startMarker;

    public Transform camera;

    public Transform endMarker;

    public bool startGame;
    void Start()
    {
        startGame = false;
    }

    // Update is called once per frame
    void Update()
    {
    
        if(startGame == true)
        {
            StartCoroutine(PlayGame());
            camera.position = Vector3.Lerp(camera.position, endMarker.position, Time.deltaTime * 2);
        }
    }

    private void OnMouseDown()
    {
        startGame = true;
    }
    IEnumerator PlayGame()
    {   
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
