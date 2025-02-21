using TMPro;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Itens
{
    public class ItemLayout : MonoBehaviour
    {
        private ItemSetup _currSetup;
        public Image uiIcon;
        public TextMeshProUGUI uiValue;
        public void OnLoad(ItemSetup setup)
        {
            _currSetup = setup;
            UpdateUI();
        }

        private void UpdateUI()
        {
            uiIcon.sprite = _currSetup.icon;
        }

        void Update()
        {
            uiValue.text = _currSetup.soInt.value.ToString();
        }
    }
}
