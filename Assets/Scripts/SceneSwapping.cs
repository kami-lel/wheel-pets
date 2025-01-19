using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapping : MonoBehaviour
{
   //Load GameScene
   public void LoadDrivingGameScene()
   {
       SceneManager.LoadScene("DrivingGameScene");
   }

    public void LoadPetGameScene()
   {
       SceneManager.LoadScene("PetGameScene");
   }

   public void LoadTitleScene()
   {
       SceneManager.LoadScene("TitleScene");
   }
   
   public void LoadLeaderboardScene()
   {
       SceneManager.LoadScene("LeaderboardScene");
   }
   
   public void LoadOptionsScene(){
         SceneManager.LoadScene("OptionsScene");
   }
   
   public void LoadDogCareScene()
   {
        SceneManager.LoadScene("DogWalkScene");
   }
   
   public void ExitGame(){
        Application.Quit();
   }
   


}
