using UnityEngine;

namespace desert
{
    public class BackButtonListener: LongClickButton
    {
        public float velocity = 5;
        public GameObject player;
        
        protected override void ClickAction()
        {
            player.transform.position -= player.transform.forward * (velocity * Time.deltaTime);
        }
    }
}