using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using Strings;
using System.IO;
using UnityEditor.iOS.Xcode;

namespace Strings
{
    public class PostProcess : MonoBehaviour
    {
        private const string ADMOB_SETTING = "GADIsAdManagerApp";
        
        [PostProcessBuildAttribute(199999)]
        public static void OnPostProcessBuild(BuildTarget target, string path)
        {
            if (target == BuildTarget.iOS)
            {
                OnIOSBuild(target, path);
            }
        }

        private static void OnIOSBuild(BuildTarget target, string path)
        {
            LocalizeName.AddLocalizedStringsIOS(path, Path.Combine(Application.dataPath, "testframework/localizationForiOS"));
            
            string infoPlistPath = path + "/Info.plist";

            PlistDocument plistDoc = new PlistDocument();
            plistDoc.ReadFromFile(infoPlistPath);
            if (plistDoc.root != null) {
                plistDoc.root.SetBoolean(ADMOB_SETTING, true);
                plistDoc.WriteToFile(infoPlistPath);
            }
            else {
                Debug.LogError("ERROR: Can't open " + infoPlistPath);
            }
        }
    }
}


