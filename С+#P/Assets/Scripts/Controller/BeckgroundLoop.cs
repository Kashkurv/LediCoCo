using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeckgroundLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;
    void Start()
    {
     mainCamera = gameObject.GetComponent<Camera>();
     screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,mainCamera.transform.position.z));
      foreach (GameObject obj in levels)
      {
          loadChildObjects(obj);
      }

    }
    void loadChildObjects(GameObject obj)
    {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        int childNeeded = (int) Mathf.Ceil(screenBounds.x*2/objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
       for (int i = 0; i < childNeeded; i++)
       {
           GameObject c = Instantiate(clone) as GameObject;
           c.transform.SetParent(obj.transform);
           c.transform.position = new Vector3(objectWidth*i,obj.transform.position.y,obj.transform.position.z);
           c.name = obj.name +i;

       }
       Destroy(clone);
       Destroy(obj.GetComponent<SpriteRenderer>());
    }
    void LateUpDade()
    {
        foreach (GameObject obj in levels)
        {
            repositionChildObjects(obj);
        }
    }
    void repositionChildObjects(GameObject obj)
    {
        Transform[] childer = obj.GetComponentsInChildren<Transform>();
        if (childer.Length >1 )
        {
            GameObject firstChild = childer[1].gameObject;
            GameObject lastChild = childer[childer.Length-1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x- choke;
            if (transform.position.x + screenBounds.x> lastChild.transform.position.x+halfObjectWidth)
            {
                firstChild.transform.SetAsFirstSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth*2,transform.position.y,transform.position.z);

            }else if ( transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth*2, transform.position.y,transform.position.z);

            }
            {
                
            }
        }

    }
}
