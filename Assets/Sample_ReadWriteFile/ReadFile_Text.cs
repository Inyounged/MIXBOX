using JetBrains.Annotations;
using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEditor.TextCore.Text;
//using System.Xml;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.VisualScripting.Member;
using static UnityEngine.GraphicsBuffer;
//using static UnityEngine.GraphicsBuffer;
//using static UnityEngine.Rendering.DebugUI;

public class ReadFile_Text : MonoBehaviour
{
    bool hasHeader = true;
    public GameObject Cube;
    public GameObject Sphere;
    public Transform x;
    public GameObject clone;
    int j =0;


    Dictionary<string, List<Item>> Sources = new Dictionary<string, List<Item>>();
  
    


    void Start()
    {
        TextAsset MyFile = Resources.Load("mixbox_csv") as TextAsset;
        String File = MyFile.text;
       

        String[] Lines = File.Split('\n');
     

        int startIndex = 0;
        int endIndex = Lines.Length;
        if (hasHeader)
        {
            startIndex = 1;
            endIndex = endIndex - 1;
        } 

        for (int i = startIndex; i < endIndex; i++)
        { 
            String[] Line = Lines[i].Split(",");
            string Source = Line[0];
            string Target = Line[1];
            string Type = Line[2];
            float Weight = float.Parse(Line[3]);//숫자의 문자열 표현을 해당하는 32비트 정수로 표현하는 오버로드
            Item MyItem = new Item(Source, Target, Type, Weight);


            if (!Sources.ContainsKey(Source))//키 존재 여부 확인,검색
            {
                List<Item> MyItems = new List<Item>();
                MyItems.Add(MyItem);
                Sources.Add(Source, MyItems);            
            }
            else
            {
                Sources[Source].Add(MyItem);

            }
        }
         
         foreach (KeyValuePair<string, List<Item>> kvp in Sources)  
         {

            clone = Instantiate(Cube);
            clone.name = kvp.Key;

            //클론 위치 랜덤
            float newX = UnityEngine.Random.Range(-10f, 10f);
            float newY = UnityEngine.Random.Range(-50f, 50f);
            j = j + 15;
            clone.transform.position = new Vector2(0 +j, 0);


            for (int i = 0; i < kvp.Value.Count; i++) 
             {
                GameObject clone2 = Instantiate(Sphere);
                clone2.name = kvp.Value[i].GetTarget();
                clone2.transform.parent = clone.transform;

                int numOfObjects = clone.transform.childCount;

                float distance = 5;
                float angle = 0;
                float center_x = clone.transform.position.x;
                float center_y = clone.transform.position.y;

                float anglePerObject = 360 / numOfObjects;
                for (int k = 0; k < numOfObjects; k++)
                {
                    float x1 = Mathf.Cos(angle) * distance + center_x;
                    float y2 = Mathf.Sin(angle) * distance + center_y;
                    angle = angle + anglePerObject;
                    clone2.transform.position = new Vector3(x1, y2);
                }

               

               

            }
         
        }
        
         /*
        List<Item> SomeSources = Sources["시각"];
        for (int i = 0; i < SomeSources.Count; i++)
        {
            // print(SomeSources[i].GetSource() + ":" + SomeSources[i].GetTarget());
          
        }
       
      
        List<string> sourcesss = new List<string>();

        foreach (KeyValuePair<string, List<Item>> kvp in Sources)
        {

            for (int i = 0; i < kvp.Value.Count(); i++)
            {
                // print(ttt.Key + ttt.Value[k].GetTarget());

                  string findValue= "포스트잇";
               

                if (kvp.Value[i].GetTarget() == findValue)
                {
                    // print(ttt.Key + "," + findValue);
                    sourcesss.Add(kvp.Key);

                }

            }
        }

    
       */

    }

    public void Update()
    {
        
      
    }
}

public class Item
{
    string Source;
    string Target;
    string Type;
    float Weight;

    public Item(string source, string target, string type, float weight)
    {
        Source = source;
        Target = target;
        Type = type;
        Weight = weight;
    }

    public string GetSource()
    {
        return Source;
    }

    public string GetTarget()
    {
        return Target;
    }

   /* public string GetType()
    {
        return Type;
    }*/

    public float GetWeight()
    {
        return Weight;
    }
    public void Show()
    {
        Debug.Log(Source + " " + Target + " " + Type + " " + Weight);
    }
}




