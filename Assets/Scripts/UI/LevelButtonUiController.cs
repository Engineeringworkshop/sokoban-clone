using LevelEditor.Models;
using UnityEngine;

namespace UI
{
    public class LevelButtonUiController : MonoBehaviour
    {
        private Map levelMap;
        private LevelsUiController levelsUiController;


        private void Start()
        {
            levelsUiController = FindObjectOfType<LevelsUiController>();
        }


        public void setlevelMap(Map level)
        {
            levelMap = level;
        }


        public void activeLevel()
        {
            levelsUiController.generateLevel(levelMap);
        }
    }
}
