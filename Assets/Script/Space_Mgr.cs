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
    }

    private void ClickSpace()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject Obj = hit.collider.gameObject;

                switch (Obj.GetComponent<Space>().spaceState)
                {
                    // 이동
                    case SpaceState.none:
                        switch (SelectList.Count)
                        {
                            case 1:
                                ChangeSpace(SelectList[0], Obj.GetComponent<Space>());
                                break;
                            case 2:
                                if (SelectList[0].Num + 1 == Obj.GetComponent<Space>().Num ||
                                    SelectList[1].Num + 1 == Obj.GetComponent<Space>().Num)
                                {
                                    ChangeSpace(SelectList[0], );
                                    ChangeSpace(SelectList[1], );
                                }
                                else if (SelectList[0].Num - 1 == Obj.GetComponent<Space>().Num ||
                                    SelectList[1].Num - 1 == Obj.GetComponent<Space>().Num)
                                {

                                }
                                //else if ()
                                //{

                                //}
                                //else if ()
                                //{

                                //}

                                break;
                            case 3:
                                break;
                        }
                        SelectList.Clear();
                        break;

                    // 선택
                    default:
                        if (SelectList.Count == 3)
                            return;

                        SelectList.Add(Obj.GetComponent<Space>());

                        break;
                }
            }

        }
        
    }

    private void Asend()
    {

    }

    private void Desend()
    {

    }

    private void ChangeSpace(Space a, Space b)
    {
        b.spaceState = a.spaceState;
        a.spaceState = SpaceState.none;
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
        for (int i = 0; i < SpaceList.Count; i++)
        {
            SpaceList[i].Num = i;
        }
    }
}
