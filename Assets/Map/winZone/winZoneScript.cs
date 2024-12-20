using UnityEngine;
using UnityEngine.SceneManagement;

public class winZoneScript : MonoBehaviour
{
    void OnTriggerEnter()
    {
        globalVariable.monsterSpeed = 0;
        Invoke("backToMenu", 10f);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
        Cursor.visible = true;
    }
}
