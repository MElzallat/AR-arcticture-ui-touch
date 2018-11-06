using UnityEngine;
using Lean.Touch;

public class GetClickedObject : MonoBehaviour {

    public bool UsingUI;
    public static GameObject LastClickedObject;
    public static Vector3 LastClickedPosition;
    public static Vector3 LastClickedScale;
    public static Quaternion LastClickedRotation;
    public static Color LastClickedColor;
    public static LeanTranslate Previous_Object;
    public static GameObject yPreventer;

    private void Start()
    {
        // to prevent lean to cahande y axis value
        if (!UsingUI)
            yPreventer = GameObject.Find("ypreventer");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(Transformation_Functions.Can_Detect)
                {
                    if (hit.transform.gameObject.tag != "House")
                    {
                        if (!UsingUI && LastClickedObject != null && LastClickedObject != hit.transform.gameObject)
                            TransformTouch.ClearAll();
                        LastClickedObject = hit.transform.gameObject;
                        LastClickedPosition = hit.transform.position;
                        LastClickedScale = hit.transform.localScale;
                        LastClickedRotation = hit.transform.rotation;

                        if (UsingUI)
                        {
                            if (GetClickedObject.Previous_Object != null)
                                Destroy(GetClickedObject.Previous_Object);
                            LeanTranslate LS = GetClickedObject.LastClickedObject.AddComponent<LeanTranslate>();
                            LS.IgnoreStartedOverGui = false;
                            GetClickedObject.Previous_Object = LS;
                        }
                    }
                }
            }
        }
    }
}
