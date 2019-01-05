using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class ClickActionUiController : MonoBehaviour, IPointerClickHandler
    {
        public int x;
        public int y;

        private LevelEditorUiController levelEditorUiController;
        private ButtonEditorsUiController buttonUiController;
        private Image image;

        private void Start()
        {
            levelEditorUiController = FindObjectOfType<LevelEditorUiController>();
            buttonUiController = FindObjectOfType<ButtonEditorsUiController>();
            image = GetComponent<Image>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //get activeButton
            var activeButton = buttonUiController.activeButton;
            //change sprite
            image.sprite = buttonUiController.activeSprite;
            if (activeButton.name.Contains("Delete"))
            {
                image.sprite = null;
            }
            //send to LevelEditor 
            levelEditorUiController.manageCellContent(x, y, activeButton);
        }
    }
}