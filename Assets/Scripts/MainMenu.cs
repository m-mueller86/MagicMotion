using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 public void PlayGame()
 {
  SceneManager.LoadSceneAsync("Duel");
 }
 
 public void SelectSpellbook()
 {
  SceneManager.LoadSceneAsync("Spellbook");
 }

 public void MainMenuLoader()
 {
  SceneManager.LoadSceneAsync("MainMenu");
 }

 public void TrainingLoader()
 {
  SceneManager.LoadSceneAsync("Training");
 }

 public void SpellSelectionDuel()
 {
  SceneManager.LoadSceneAsync("SpellSelection");
 }

 public void SpellSelectionTraining()
 {
  SceneManager.LoadSceneAsync("SpellSelectionTraining");
 }
}
