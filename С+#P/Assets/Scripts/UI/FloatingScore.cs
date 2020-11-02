using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScore : MonoBehaviour
{
   public int score;
   private TextMesh textMesh;

   private void Start() {
   textMesh = GetComponent<TextMesh>();
   textMesh.text = score.ToString();   
   }
   public void onEndAnimation()
   {
       Destroy(gameObject);
   }
}
