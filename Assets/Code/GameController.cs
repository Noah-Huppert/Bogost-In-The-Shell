using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    public Canvas uiCanvas;

    public static GameController Instance;

    public void Awake(){
        if(Instance == null){
            Instance = this;

            DontDestroyOnLoad(Instance.gameObject);
        }
    }

    public void Start(){
        //Put Version on screen
        GameObject versionText = Instance.uiCanvas.transform.FindChild("Version").gameObject;
        versionText.GetComponent<Text>().text = Version.Assemble();
    }
}
