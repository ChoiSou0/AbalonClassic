using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

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
                                    BlankSpace("1");
                                    if (SelectList.Count != 0)
                                    { 
                                        FindSpace(SelectList[0], "1");
                                        FindSpace(SelectList[1], "1");
                                    }
                                }
                                else if (SelectList[0].Num - 1 == Obj.GetComponent<Space>().Num ||
                                         SelectList[1].Num - 1 == Obj.GetComponent<Space>().Num)
                                {
                                    BlankSpace("-1");
                                    if (SelectList.Count != 0)
                                    {
                                        FindSpace(SelectList[0], "-1");
                                        FindSpace(SelectList[1], "-1");
                                    }
                                }
                                else
                                {
                                    switch (Obj.transform.parent.name)
                                    {
                                        case "WidthLine1":
                                            break;
                                        case "WidthLine2":
                                            if (SelectList[0].Num - 5 == Obj.GetComponent<Space>().Num ||
                                                SelectList[1].Num - 5 == Obj.GetComponent<Space>().Num)
                                            {

                                            }
                                            break;
                                        case "WidthLine3":
                                            if (SelectList[0].Num - 6 == Obj.GetComponent<Space>().Num ||
                                                SelectList[1].Num - 6 == Obj.GetComponent<Space>().Num)
                                            {

                                            }
                                            break;
                                        case "WidthLine4":
                                            if (SelectList[0].Num - 7 == Obj.GetComponent<Space>().Num ||
                                                SelectList[1].Num - 7 == Obj.GetComponent<Space>().Num)
                                            {
                                                
                                            }
                                            break;
                                        case "WidthLine5":
                                            if (SelectList[0].Num - 8 == Obj.GetComponent<Space>().Num ||
                                                SelectList[1].Num - 8 == Obj.GetComponent<Space>().Num)
                                            {
                                                BlankSpace("8");
                                                if (SelectList.Count != 0)
                                                {
                                                    FindSpace(SelectList[0], "8");
                                                    FindSpace(SelectList[1], "8");
                                                }
                                            }
                                            break;
                                        case "WidthLine6":
                                            if (SelectList[0].Num - 8 == Obj.GetComponent<Space>().Num ||
                                                SelectList[1].Num - 8 == Obj.GetComponent<Space>().Num)
                                            {

                                            }
                                            break;
                                        case "WidthLine7":
                                            if (SelectList[0].Num - 7 == Obj.GetComponent<Space>().Num ||
                                                SelectList[1].Num - 7 == Obj.GetComponent<Space>().Num)
                                            {

                                            }
                                            break;
                                        case "WidthLine8":
                                            if (SelectList[0].Num - 6 == Obj.GetComponent<Space>().Num ||
                                                SelectList[1].Num - 6 == Obj.GetComponent<Space>().Num)
                                            {

                                            }
                                            break;
                                        case "WidthLine9":
                                            if (SelectList[0].Num - 5 == Obj.GetComponent<Space>().Num ||
                                                SelectList[1].Num - 5 == Obj.GetComponent<Space>().Num)
                                            {

                                            }
                                            break;
                                    }
                                }
                                //else if (SelectList[0].Num - Obj.GetComponent<Space>().Num <= 8 &&
                                //         SelectList[0].Num - Obj.GetComponent<Space>().Num >= 4)
                                //{
                                //    switch (transform.parent.name)
                                //    {
                                        
                                //    }
                                //}    
                                //else if (Obj.GetComponent<Space>().Num - SelectList[1].Num >= -8)
                                //{

                                //}

                                break;
                            case 3:
                                if (SelectList[0].Num + 1 == Obj.GetComponent<Space>().Num ||
                                    SelectList[1].Num + 1 == Obj.GetComponent<Space>().Num ||
                                    SelectList[2].Num + 1 == Obj.GetComponent<Space>().Num)
                                {
                                    BlankSpace("1");
                                    if (SelectList.Count != 0)
                                    {
                                        FindSpace(SelectList[0], "1");
                                        FindSpace(SelectList[1], "1");
                                        FindSpace(SelectList[2], "1");
                                    }
                                }
                                else if (SelectList[0].Num - 1 == Obj.GetComponent<Space>().Num ||
                                         SelectList[1].Num - 1 == Obj.GetComponent<Space>().Num ||
                                         SelectList[2].Num - 1 == Obj.GetComponent<Space>().Num)
                                {
                                    BlankSpace("-1");
                                    if (SelectList.Count != 0)
                                    {
                                        FindSpace(SelectList[0], "-1");
                                        FindSpace(SelectList[1], "-1");
                                        FindSpace(SelectList[2], "-1");
                                    }
                                }
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

    // 작은 순으로 재배열
    private void Asend()
    {
        SelectList.OrderBy(o=>o.Num).ToList();
    }

    // 큰 순으로 재배열
    private void Desend()
    {
        SelectList.OrderByDescending(o=>o.Num).ToList();
    }

    // 이동칸이 빈칸인지 검사하는 함수
    private void BlankSpace(string Type)
    {
        switch(Type)
        {
            case "1":
                for (int i = 0; i < SelectList.Count - 1; i++)
                {
                    for (int j = 0; j < SpaceList.Count; j++)
                    {
                        if (SelectList[i].Num + 1 == SpaceList[j].Num &&
                            SpaceList[j].spaceState != SpaceState.none)
                        {
                            SelectList.Clear();
                        }
                    }
                }
                break;
            case "-1":
                for (int i = 0; i < SelectList.Count - 1; i++)
                {
                    for (int j = 0; j < SpaceList.Count; j++)
                    {
                        if (SelectList[i].Num + 1 == SpaceList[j].Num &&
                            SpaceList[j].spaceState != SpaceState.none)
                        {
                            SelectList.Clear();
                        }
                    }
                }
                break;
            case "8":
                for (int i = 0; i < SelectList.Count - 1; i++)
                {
                    for (int j = 0; j < SpaceList.Count; j++)
                    {
                        switch (SelectList[i].transform.parent.name)
                        {   
                            case "WidthLine1":
                                break;
                            case "WidthLine2":
                                if (SelectList[i].Num - 5 == SpaceList[j].Num &&
                                    SpaceList[j].spaceState != SpaceState.none)
                                    SelectList.Clear();
                                break;
                            case "WidthLine3":
                                if (SelectList[i].Num - 6 == SpaceList[j].Num &&
                                    SpaceList[j].spaceState != SpaceState.none)
                                    SelectList.Clear();
                                break;
                            case "WidthLine4":
                                if (SelectList[i].Num - 7 == SpaceList[j].Num &&
                                    SpaceList[j].spaceState != SpaceState.none)
                                    SelectList.Clear();
                                break;
                            case "WidthLine5":
                                if (SelectList[i].Num - 8 == SpaceList[j].Num &&
                                    SpaceList[j].spaceState != SpaceState.none)
                                    SelectList.Clear();
                                break;
                            case "WidthLine6":
                                if (SelectList[i].Num - 8 == SpaceList[j].Num &&
                                    SpaceList[j].spaceState != SpaceState.none)
                                    SelectList.Clear();
                                break;
                            case "WidthLine7":
                                if (SelectList[i].Num - 7 == SpaceList[j].Num &&
                                    SpaceList[j].spaceState != SpaceState.none)
                                    SelectList.Clear();
                                break;
                            case "WidthLine8":
                                if (SelectList[i].Num - 6 == SpaceList[j].Num &&
                                    SpaceList[j].spaceState != SpaceState.none)
                                    SelectList.Clear();
                                break;
                            case "WidthLine9":
                                if (SelectList[i].Num - 5 == SpaceList[j].Num &&
                                    SpaceList[j].spaceState != SpaceState.none)
                                    SelectList.Clear();
                                break;
                        }
                    }
                }
                break;
        }
    }

    // 클릭한 이동위치를 찾는 함수
    private void FindSpace(Space Founded, string Type)
    {
        for (int i = 0; i < SpaceList.Count; i++)
        {
            switch (Type)
            {
                case "1":
                    if (i == Founded.Num + 1)
                    {
                        ChangeSpace(Founded, SpaceList[i]);
                        break;
                    }
                    break;
                case "-1":
                    if (i == Founded.Num - 1)
                    {
                        ChangeSpace(Founded, SpaceList[i]);
                        break;
                    }
                    break;
                case "8":
                    if (i == Founded.Num - 8)
                    {
                        ChangeSpace(Founded, SpaceList[i]);
                        break;
                    }
                    break;
            }
        }
    }

    // 클릭한 위치로 이동해주는 함수
    private void ChangeSpace(Space a, Space b)
    {
        b.spaceState = a.spaceState;
        a.spaceState = SpaceState.none;
    }

    // 맨처음 세팅해주는 함수
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
