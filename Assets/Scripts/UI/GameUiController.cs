using Boo.Lang;
using Game;
using LevelEditor.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace UI
{
    public class GameUiController : MonoBehaviour
    {
        [Header("Game's prefabs ")] [SerializeField]
        private GameObject prefabWall;

        [SerializeField] private GameObject prefabPlayer;
        [SerializeField] private GameObject prefabWallExterior;
        [SerializeField] private GameObject prefabBox;
        [SerializeField] private GameObject prefabPoint;
        [SerializeField] private GameObject prefabFloor;

        [SerializeField] private Sprite grass;
        [SerializeField] private Sprite dirt;
        [SerializeField] private Sprite stone;

        private List<CheckPointController> pointToWin;

        [FormerlySerializedAs("level content")] [Header("GameContent")] [SerializeField]
        private GameObject levelContent;

        private Cell[,] actualLevel;
        private string backgroundTerrain;

        // Update is called once per frame
        void Update()
        {
            if (checkLevelComplete())
            {
                SceneManager.LoadScene("Levels_Scene");
            }
        }

        private bool checkLevelComplete()
        {
            bool isComplete = true;

            if (pointToWin == null) return false;

            foreach (var point in pointToWin)
            {
                if (!point.isFull)
                {
                    isComplete = false;
                }
            }

            return isComplete;
        }

        public void generateGame(Cell[,] grid, string backgroundTerrain)
        {
            actualLevel = grid;
            this.backgroundTerrain = backgroundTerrain;

            var boundX = grid.GetUpperBound(0);
            var boundY = grid.GetUpperBound(1);
            pointToWin = new List<CheckPointController>();
            var position = levelContent.transform.position;

            var lastPosition = new Vector3(position.x + 1.28f, position.y + -1.28f, 0);

            generateWalls(grid);

            for (var y = 0; y <= boundY; y++)
            {
                for (var x = 0; x <= boundX; x++)
                {
                    Vector3 nextPosition;

                    if (x == 0 && y == 0)
                    {
                        nextPosition = lastPosition;
                    }
                    else if (x == 0)
                    {
                        nextPosition = new Vector3(position.x + 1.28f, lastPosition.y - 1.28f, lastPosition.z);
                    }
                    else
                    {
                        nextPosition = new Vector3(lastPosition.x + 1.28f, lastPosition.y, lastPosition.z);
                    }

                    var cell = grid[x, y];
                    if (cell != null)
                    {
                        var floorSprite = getFloorSprite(backgroundTerrain);
                        prefabFloor.GetComponent<SpriteRenderer>().sprite = floorSprite;
                        var instantiateFloor = Instantiate(prefabFloor, levelContent.transform);
                        var instantiateTransform = instantiateFloor.transform;
                        instantiateTransform.localPosition = nextPosition;
                        if (cell.Type.Equals("Point"))
                        {
                        }
                    }


                    var instantiate = Instantiate(getTemplate(cell), levelContent.transform);

                    var imgTransform = instantiate.transform;
                    imgTransform.localPosition = nextPosition;

                    instantiate.name = y + "_" + x + "_cell";
                    if (cell != null)
                    {
                        if (cell.Type.Equals("Point"))
                        {
                            pointToWin.Add(instantiate.GetComponent<CheckPointController>());
                        }
                    }

                    lastPosition = nextPosition;
                }
            }
        }

        private Sprite getFloorSprite(string backgroundTerrain)
        {
            if (backgroundTerrain.Contains("04"))
            {
                return stone;
            }

            if (backgroundTerrain.Contains("05"))
            {
                return dirt;
            }

            return grass;
        }

        private void generateWalls(Cell[,] grid)
        {
            var boundX = grid.GetUpperBound(0) + 2;
            var boundY = grid.GetUpperBound(1) + 2;

            var position = levelContent.transform.position;


            var wallLastPosition = new Vector3(position.x, position.y, 0);

            for (var y = 0; y <= boundY; y++)
            {
                for (var x = 0; x <= boundX; x++)
                {
                    Vector3 nextPosition;

                    if (x == 0 && y == 0)
                    {
                        nextPosition = wallLastPosition;
                    }
                    else if (x == 0)
                    {
                        nextPosition = new Vector3(position.x, wallLastPosition.y - 1.28f, wallLastPosition.z);
                    }
                    else
                    {
                        nextPosition = new Vector3(wallLastPosition.x + 1.28f, wallLastPosition.y, wallLastPosition.z);
                    }


                    if (y == 0 || x == 0 || y == boundY || x == boundX)
                    {
                        var instantiate = Instantiate(prefabWallExterior, levelContent.transform);

                        var imgTransform = instantiate.transform;
                        imgTransform.localPosition = nextPosition;

                        instantiate.name = y + "_" + x + "_wall";
                    }


                    wallLastPosition = nextPosition;
                }
            }
        }

        private GameObject getTemplate(Cell cell)
        {
            if (cell == null)
            {
                return prefabFloor;
            }

            if (cell.Type.Equals("Box"))
            {
                return prefabBox;
            }

            if (cell.Type.Equals("Wall"))
            {
                return prefabWall;
            }

            if (cell.Type.Equals("Player"))
            {
                return prefabPlayer;
            }

            if (cell.Type.Equals("Point"))
            {
                return prefabPoint;
            }

            return null;
        }

        public void resetGameScene()
        {
            foreach (Transform child in levelContent.transform)
                Destroy(child.gameObject);

            generateGame(actualLevel, backgroundTerrain);
        }
    }
}