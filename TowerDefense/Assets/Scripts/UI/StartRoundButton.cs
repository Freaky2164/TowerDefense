using GameHandling;
using Unity.VisualScripting;
using UnityEngine;

namespace UI
{
    public class StartRoundButton : MonoBehaviour
    {
        public void Click()
        {
            GameHandler.I.Rounds.StartRound();
        }
    }
}