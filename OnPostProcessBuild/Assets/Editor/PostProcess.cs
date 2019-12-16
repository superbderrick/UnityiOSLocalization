using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using Strings;
using System.IO;

namespace Strings
{
    public class PostProcess : MonoBehaviour
    {
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
        }
    }
}


