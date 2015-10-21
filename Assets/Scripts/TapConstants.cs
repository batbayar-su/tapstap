using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class TapConstants
{
  // game based variables
  public static bool gameover = false;
  public static float start_delay = 5.0f;
  public static float user_score = 0f;
  public static float fadeSpeed = 1f;
  public static AudioClip theme_song = Resources.Load("ui_back") as AudioClip;
  public static AudioClip ending_song = Resources.Load("game_ending") as AudioClip;

  // file stored variables
  public static float sound_volume = 1f;
  public static string player_name = "Tapstaper";
  public static float personal_high_score = 0f;

  public static void Save() 
  {
    Hashtable save_data = new Hashtable();
    save_data.Add("sound_volume", sound_volume);
    save_data.Add("player_name", player_name);
    save_data.Add("high_score", personal_high_score);
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + "/tapstap_settings.gd");
    bf.Serialize(file, save_data);
    file.Close();
  }

  public static void Load() 
  {
    if(File.Exists(Application.persistentDataPath + "/tapstap_settings.gd"))
    {
      Hashtable save_data = new Hashtable();
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Open(Application.persistentDataPath + "/tapstap_settings.gd", FileMode.Open);
      save_data = (Hashtable)bf.Deserialize(file);
      sound_volume = (float)save_data["sound_volume"];
      player_name = (string)save_data["player_name"];
      personal_high_score = (float)save_data["high_score"];
      file.Close();
    }
  }
}