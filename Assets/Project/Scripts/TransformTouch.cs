using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class TransformTouch : MonoBehaviour {

    public static LeanTranslate lt;
    public static LeanScale ls;
    public static LeanRotateCustomAxis lr; 

    public void TranslateClick()
    {
        ClearAll();
        lt = GetClickedObject.LastClickedObject.AddComponent<LeanTranslate>();
        lt.IgnoreStartedOverGui = false;
    }

    public void RotateClick()
    {
        ClearAll();
        lr = GetClickedObject.LastClickedObject.AddComponent<LeanRotateCustomAxis>();
        lr.IgnoreStartedOverGui = false;
    }

    public void ScaleClick()
    {
        ClearAll();
        ls = GetClickedObject.LastClickedObject.AddComponent<LeanScale>();
        ls.IgnoreStartedOverGui = false;
    }

    public static void BackClick()
    {
        ClearAll();
    }

    public static void ClearAll()
    {
        lt = GetClickedObject.LastClickedObject.GetComponent<LeanTranslate>();
        ls = GetClickedObject.LastClickedObject.GetComponent<LeanScale>();
        lr = GetClickedObject.LastClickedObject.GetComponent<LeanRotateCustomAxis>();
        if (lt != null)
            Destroy(lt);
        if (ls != null)
            Destroy(ls);
        if (lr != null)
            Destroy(lr);
    }
}
