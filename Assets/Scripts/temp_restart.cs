using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {

  public void RestartGame () {
    Debug.Log("Entered the restart button");
    Application.LoadLevel("Practice");
  }
}
