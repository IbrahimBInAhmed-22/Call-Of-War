using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    // Start is called before the first frame update
  public void loadWin()
    {
        SceneManager.LoadScene("Win");
    }
    public void loadStart()
    {
        SceneManager.LoadScene("scene_day");
    }
    public void loadEnd()
    {
        SceneManager.LoadScene("gameOver");
    }
}
