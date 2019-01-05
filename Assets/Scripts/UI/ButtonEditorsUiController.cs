using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonEditorsUiController : MonoBehaviour
    {
        public Button activeButton;
        public Sprite activeSprite;
        
        public void setActiveButton(Button button)
        {
            activeButton = button;
            activeSprite = button.GetComponent<Image>().sprite;
        }
    }
}