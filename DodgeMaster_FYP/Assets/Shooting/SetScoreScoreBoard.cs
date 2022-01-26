//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class SetScoreScoreBoard : MonoBehaviour
//{
//    [SerializeField] Text score;

//    // Start is called before the first frame update
//    void Start()
//    {
//        score.text = PlayerPrefsManager.ScorePref.ToString();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        score.text = PlayerPrefsManager.ScorePref.ToString();

//        if (PlayerPrefsManager.ScorePref >= 10)
//        {
//            GameManager.instance.Complete();
//            PlayerPrefsManager.ScorePref = 0;
//        }
//    }
//}
