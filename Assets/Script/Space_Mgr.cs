using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SpaceState
{
    none, White, Black
}

public class Space_Mgr : MonoBehaviour
{
    private RaycastHit hit;

    public static Space_Mgr Instance;

    public List<Space> SpaceList = new List<Space>();
    public List<Space> SelectList = new List<Space>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSetting();
    }

    // Update is called once per frame
    void Update()
    {
        ClickSpace();
        MoveSpace();
    }

    private void ClickSpace()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SelectList.Count == 3)
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject Obj = hit.collider.gameObject;
                SelectList.Add(Obj.GetComponent<Space>());
            }
            
        }
        
    }

    private void MoveSpace()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 v = Vector2.zero;
            switch(SelectList.Count)
            {
                case 0:
                    return;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

            if (Physics.Raycast(ray, out hit))
            {
                GameObject Obj = hit.collider.gameObject;
                

            }
        }
    }

    private void StartSetting()
    {
        for (int i = 0; i < 5; i++)
        {
            SpaceList[i].spaceState = SpaceState.White;
            SpaceList[i + 56].spaceState = SpaceState.Black;
        }
        for (int i = 0; i < 6; i++)
        {
            SpaceList[i + 5].spaceState = SpaceState.White;
            SpaceList[i + 50].spaceState = SpaceState.Black;
        }
        for (int i = 0; i < 3; i++)
        {
            SpaceList[i + 13].spaceState = SpaceState.White;
            SpaceList[i + 45].spaceState = SpaceState.Black;
        }
    }
}
