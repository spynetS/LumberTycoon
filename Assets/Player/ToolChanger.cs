using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class ToolChanger : MonoBehaviour
    {
        public int activeToolIndex;
        private int prevIndex = 0;
        void Update()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if (scroll > 0f)
            {
                if (activeToolIndex < transform.childCount-1)
                    activeToolIndex++;
                else
                    activeToolIndex = 0;
            }
            else if (scroll < 0f)
            {
                if (activeToolIndex > 0)
                    activeToolIndex--;
                else
                    activeToolIndex = transform.childCount-1;
            }

            if (activeToolIndex != prevIndex)
            {
                channgeActiveTool();
            }

            prevIndex = activeToolIndex;

        }

        public void channgeActiveTool()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                child.SetActive(false);
                if (i == activeToolIndex)
                {
                    child.SetActive(true);
                    try
                    {
                        transform.GetComponent<Attack>().tool = child.GetComponent<Tool>();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Attack script should be on this transform");
                    }
                }
            }
        }
    }
}

