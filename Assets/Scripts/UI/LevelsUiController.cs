using Boo.Lang;
using Game;
using LevelEditor.Models;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelsUiController : MonoBehaviour
    {
        [SerializeField] private GameObject levelContentButtons;
        [SerializeField] private GameObject levelsPanel;
        
        private LevelsController levelsController;
        private List<Map> maps;

        [SerializeField] private Button prefabButton;

        // Start is called before the first frame update
        void Start()
        {
            levelsController = new LevelsController();
            maps = levelsController.getAllLevelList();
            loadUiLevelButtons();
        }


        private void loadUiLevelButtons()
        {
            var count = 1;
            foreach (var map in maps)
            {
                var levelButton = Instantiate(prefabButton, levelContentButtons.transform);
                levelButton.GetComponentInChildren<Text>().text = "Level " + count;
                levelButton.GetComponent<LevelButtonUiController>().setlevelMap(map);
                count++;
            }
        }

        public void generateLevel(Map map)
        {
            Cell[,] grid = levelsController.generateGrid(map);
            loadPlayableLevel(grid);
        }

        private void loadPlayableLevel(Cell[,] grid )
        {
           levelsPanel.SetActive(false);
           
        }
    }
}