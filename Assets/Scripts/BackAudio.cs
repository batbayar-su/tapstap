using UnityEngine;
using System.Collections;

public class BackAudio : MonoBehaviour {
  private static BackAudio instance = null;
  public static BackAudio Instance {
    get { return instance; }
  }
  void Awake() {
    if (instance != null && instance != this) {
      Destroy(this.gameObject);
      return;
    } else {
      instance = this;
    }
    DontDestroyOnLoad(this.gameObject);
  }
}
