/* SUMMARY: 
**      This tool's goal is to streamline the issues of using the default merge tooling of git.
**      Binary files do not play nice and YAML is by no means perfect but at minumum this aims to
**      prevent entire scene or project crashing when a merge conflict does arise... And it will.
**      -- You're Welcome.
**
** AUTHOR: 
**      Ray De Jesus @rayraysunrise
**
** NOTE: Currently appends yaml merge spec to git config files.
** TODO: Build custom mergespecfile to replace default per unity verison.
** TODO: Set custom folders for mergespecfile.
*/

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEditor;

public class MamaMerge : EditorWindow
{
    private string subTextLine1 = "Everyone hates configuring their local environment...";
    private string subTextLine2 = "Don't worry Mama will take of you dear.";

    private Rect autoConfigFrame;
    private string linkButtonText = "   Link   ";
    private string mergeButtonText = "   Merge   ";
    private bool advancedSettings;
    private string advancedSettingsText = "Advanced Settings";

    private bool isLinked = false;
    private static string defaultInstancePath = "Library/EditorInstance.json";
    private string instancePath = defaultInstancePath;
    private static string defaultYAMLExtension = "/Contents/Tools/UnityYAMLMerge";
    private string yamlExtension = defaultYAMLExtension;
    private string yamlPath;

    // TODO: Add file selection in advanced settings
    private static string defaultGitConfigPath = ".git/config";
    private string gitConfigPath = defaultGitConfigPath;

    // TODO: Add custom commands in advanced settings
    private static string defaultGitCmd = "git";
    private string gitCmd = defaultGitCmd;
    private static string defaultGitArgs = @"mergetool --tool=unityyamlmerge";
    private string gitArgs = defaultGitArgs;

    [MenuItem ("Window/MamaMerge")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MamaMerge));
    }

    void OnGUI()
    {
        // TODO: Title image graphic
        // TODO: Style window black and green h4x0r

        // NOTE: Subtext
        GUILayout.Label(subTextLine1);
        GUILayout.Label(subTextLine2);

        // NOTE: Auto configs
        autoConfigFrame = EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if(GUILayout.Button(linkButtonText))
                linkYAML();
            GUILayout.FlexibleSpace();
            if(GUILayout.Button(mergeButtonText))
                smartMerge();
            GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // NOTE: Start of the advanced setting dropdown
        advancedSettings = EditorGUILayout.BeginFoldoutHeaderGroup(advancedSettings, advancedSettingsText);

        EditorGUILayout.EndFoldoutHeaderGroup();

        // TODO: Display messages to user
    }

    // TODO: Comment out Apple FileMerge within mergespecfile.txt, install and config Diff Merge file path to mergespecfile.txt

    private void linkYAML()
    {
        yamlPath = retrieveYAMLpath();

        if(yamlPath != null)
        {
            appendYAML();
        }

        // TODO: Inform user with status messages
        if(isLinked)
            UnityEngine.Debug.Log("YAML LINKED");
        else
            UnityEngine.Debug.Log("FAILED YAML LINK");
    }

    private string retrieveYAMLpath()
    {
        //string pathArgs = "grep '\"\"\"app_path\"\"\"' Library/EditorInstance.json";
        //try 
        //{
            /*ProcessStartInfo pathInfo = new ProcessStartInfo()
            {
                FileName = "bash",
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Arguments = " -c \"" + pathArgs + " \""
            };

            Process pathProcess = new Process
            {
                StartInfo = pathInfo
            };

            pathProcess.Start();
            string output = pathProcess.StandardOutput.ReadToEnd();*/
            /*string output = null;
            string line;
            StreamReader file = new StreamReader(instancePath);

            while((line = file.ReadLine()) != null || output != null)
            {
                if(line.Contains("app_path"))
                {
                    output = line;
                    UnityEngine.Debug.Log(output);
                    break;
                }
            }

            file.Close();

            int colonIndex = output.IndexOf(":");
            string path = output.Substring(colonIndex+1,output.Length-colonIndex-3).Replace("\"", "").Trim() + yamlExtension;

            //pathProcess.WaitForExit();
            
            UnityEngine.Debug.Log("MY PATH : " + path);
            UnityEngine.Debug.Log("UNITY PATH : " + EditorApplication.applicationPath);*/
            //return path;
        /*} 
        catch (Exception e)
        {
            UnityEngine.Debug.Log("Error : " + e.Message);
            isLinked = false;
            return e.Message;
        }*/

        return (EditorApplication.applicationPath + yamlExtension);
    }

    private void appendYAML() 
    {
        // TODO:Windows file location strip out Unity.exe and append Data\Tools\UnityYAMLMerge.exe
        // NOTE: DEBUG code
        //string gitConfig = "";
        string newGitConfig = "";
        string mergeCMD = "\tcmd = " + yamlPath + " merge -p \"$BASE\" \"$REMOTE\" \"$LOCAL\" \"$MERGED\"";
        string gitMergeConfigs = "\n \n# Merge configs compliments of MAMA\n \n[mergetool]\n\tkeepBackup = false\n\n[merge]\n\ttool = unityyamlmerge\n\n[mergetool \"unityyamlmerge\"]\n\ttrustExitCode = false\n"+ mergeCMD;

        bool updatedPath = false;

        try
        {
            bool hasYAML = false;

            int index = 0;
            string line;

            // TODO: if(File.Exists(gitConfigPath){}
            StreamReader file = new StreamReader(gitConfigPath);
            while((line = file.ReadLine()) != null)
            {
                if(line.Contains("\"unityyamlmerge\""))
                {
                    hasYAML = true;
                    //UnityEngine.Debug.Log(line);
                }

                if(hasYAML && !updatedPath && line.Contains("cmd"))
                {
                    newGitConfig += "\n" + mergeCMD;
                    updatedPath = true;
                } 
                else
                {
                    if(index == 0 && line == "")
                        newGitConfig = "";
                    else if(line == "")
                        newGitConfig += line;
                    else
                        newGitConfig += "\n" + line;
                }

                // NOTE: DEBUG code
                //gitConfig += "\n" + line;

                index+=1;
            }
            file.Close();

            // NOTE: Append whole merge text if no prior yaml path was defined
            if(!updatedPath)
            {
                newGitConfig += "\n" + gitMergeConfigs;
                updatedPath = true;
            }

            // NOTE: Updates the file with append text
            // NOTE: WARNING DESTRUCTIVE
            if(updatedPath)
            {
                // NOTE: DEBUG code
                //UnityEngine.Debug.Log("NEW = " + newGitConfig);
                //UnityEngine.Debug.Log("OLD = " + gitConfig);


                // NOTE: WARNING DESTRUCTIVE
                File.WriteAllText(gitConfigPath, newGitConfig);
                isLinked = true;
            }
        }
        catch(Exception e)
        {
            UnityEngine.Debug.Log(e.Message);
        }
    }

    private void smartMerge()
    {
        if(isLinked)
        {
            try 
            {

                // TODO: Git running from the wrong location; Running from XCode/gitCore install. PATH conflict
                ProcessStartInfo gitStartInfo = new ProcessStartInfo()
                {
                    FileName = "bash",
                    WorkingDirectory = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/')),
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = false,
                    //WindowStyle = ProcessWindowStyle.Normal,
                    //Arguments = gitArgs
                    //Arguments = " -c \" git " + gitArgs + " \""
                    //Arguments = " -c \" git-lfs --v \""
                    Arguments = " -c \" git --exec-path \""
                    //Arguments = @"--exec-path"
                    //Arguments = " -c \"  ls \""
                };

                Process gitProcess = new Process
                {
                    StartInfo = gitStartInfo
                };

                gitProcess.Start();
                //Process.Start(gitCmd, gitArgs);
                string output = gitProcess.StandardOutput.ReadToEnd();
                string error = gitProcess.StandardError.ReadToEnd();
                StreamWriter input = gitProcess.StandardInput;
                
                UnityEngine.Debug.Log("OUTPUT: " + output);
                UnityEngine.Debug.Log("ERROR: " + error);
                //UnityEngine.Debug.Log(Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/')));

                gitProcess.WaitForExit();
            }
            catch(Exception e)
            {
                UnityEngine.Debug.Log(e.Message);
            }
        }
        else
        {
            UnityEngine.Debug.Log("Please link YAML");
        }
    }

}
