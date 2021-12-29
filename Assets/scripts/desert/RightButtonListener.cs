using UnityEngine;

namespace desert
{
    public class RightButtonListener: LongClickButton
    {
        public float rotationSpeed = 10;
        public GameObject player;
        
        protected override void ClickAction()
        {
            player.transform.Rotate(player.transform.up, rotationSpeed * Time.deltaTime);
        }
    }
}