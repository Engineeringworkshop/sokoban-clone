using LevelEditor;
using LevelEditor.Models;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelEditorUiController : MonoBehaviour
    {
        #region FormFields
        [Header("FormFields")]
        [SerializeField] private InputField inputX;

        [SerializeField] private InputField inputY;

        [SerializeField] private Dropdown terrainType;

        #endregion

        [Header("Canvas UI")]
        [SerializeField] private Canvas createUi;

        [SerializeField] private Canvas mapUi;

        [SerializeField] private GameObject generatePanel;

        [Header("Prefabs")]
        [SerializeField] private Image imgTemplate;

        [SerializeField] private Cell[,] grid;

        private LevelEditorController levelEditorController;

        private int imgSize; 
        
        private void Start()
        {
            grid = null;
            levelEditorController = FindObjectOfType<LevelEditorController>();
        }


        public void generateUiMap()
        {
            getMapData();
            if (grid == null) return;

            createUi.enabled = false;
            mapUi.enabled = true;
            instantiateMapUI();
        }

        private void instantiateMapUI()
        {

            var boundX = grid.GetUpperBound(0);
            var boundY = grid.GetUpperBound(1);

            var position = generatePanel.GetComponent<RectTransform>();
            var lastPosition = new Vector3(position.offsetMin.x + 25, position.offsetMax.y + -25, 0);
            for (var y = 0; y <= boundY; y++)
            {
                for (var x = 0; x <= boundX; x++)
                {
                    Vector3 nextPosition;
                    grid[x, y] = null;
                    if (x == 0 && y == 0)
                    {
                        nextPosition = lastPosition;                        
                    }else if (x == 0)
                    {
                        nextPosition = new Vector3(position.offsetMin.x + 25, lastPosition.y - 51, lastPosition.z); 
                    }else {
                        nextPosition = new Vector3(lastPosition.x + 51, lastPosition.y , lastPosition.z); 
                    }


                    var img = Instantiate(imgTemplate, generatePanel.transform);

                    var imgTransform = img.transform;
                    imgTransform.localPosition = nextPosition;
                    img.GetComponent<ClickActionUiController>().x = x;
                    img.GetComponent<ClickActionUiController>().y = y;
                    img.name =  y +"_"+ x +"_cell" ;
                    
                    
                    lastPosition = nextPosition;
                }
            }
        }

        private void getMapData()
        {
            Debug.Log(string.Format("<color='green'>{0},{1},{2}</color>",
                inputX.text, inputY.text, terrainType.value));

            if (inputX.text.Equals("") || inputY.text.Equals(""))
            {
                Debug.Log(string.Format("<color='red'>{0},{1} Wrong values</color>",
                    inputX.text, inputY.text));
                return;
            }

            if (int.Parse(inputX.text) < 0 || int.Parse(inputY.text) < 0 || int.Parse(inputX.text) > 20 || int.Parse(inputY.text) > 20)
            {
                Debug.Log(string.Format("<color='red'>{0},{1} Wrong values</color>",
                    inputX.text, inputY.text));
                return;
            }

            //call level Editor to generate the object
            grid = levelEditorController.generateMap(int.Parse(inputX.text), int.Parse(inputY.text),
                terrainType.itemImage.sprite.name);


        }

        public void manageCellContent(int x, int y, Button activeButton)
        {
            if (activeButton.name.Contains("Box"))
            {
                grid[x, y] = new Cell(x, y,"Box", "grey");
            }else if (activeButton.name.Contains("Point"))
            {
                grid[x, y] = new Cell(x, y,"Point", "grey");
            }else if (activeButton.name.Contains("Player"))
            {
                grid[x, y] = new Cell(x, y,"Player", "default");
            }else if (activeButton.name.Contains("Wall"))
            {
                grid[x, y] = new Cell(x, y,"Wall", "red");
            }else if (activeButton.name.Contains("Delete"))
            {
                grid[x, y] = null;
            }
        }


        public void saveLevelEditorMap()
        {
            levelEditorController.updateMap(grid);
            levelEditorController.saveActualMap();
        }
    }
}