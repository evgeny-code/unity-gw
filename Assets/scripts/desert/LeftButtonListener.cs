using UnityEngine;

namespace desert
{
    public class LeftButtonListener: LongClickButton
    {
        public float rotationSpeed = 10;
        public GameObject player;
        
        protected override void ClickAction()
        {
            player.transform.Rotate(new Vector3(0,1,0), -rotationSpeed * Time.deltaTime);
        }
    }
}