﻿using System.Diagnostics;
using System.IO;
using System.Net;

namespace QC_Tool
{
    class Cmd
    {
        FormApp frmApp;

        public void Commands(string command, string path)
        {
            try
            {
                frmApp = FormApp.getInstance();
                Process cmd = new Process();
                cmd.StartInfo.FileName = "CMD.exe";
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                cmd.StandardInput.WriteLine(command + " > " + path);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
            }
            catch { }
        }

        public void Commands(string command)
        {
            try
            {
                frmApp = FormApp.getInstance();
                Process cmd = new Process();
                cmd.StartInfo.FileName = "CMD.exe";
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                cmd.StandardInput.WriteLine(command);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
            }
            catch { }
        }

        public bool licenseGroupID(string groupID)
        {
            try
            {
                frmApp = FormApp.getInstance();

                using (var reader = new StreamReader(frmApp.pathFileLicensesList))
                {
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("License group ID"))
                        {
                            if (line.Contains(groupID))
                                return true;
                        }
                    }
                    return false;
                }
            }
            catch { return false; }
        }

        public bool GetHostID()
        {
            try
            {
                Commands(@"qpm-cli --generate-host-id c:\");
                return true;
            }
            catch { return false; }
        }

        public string getHostName()
        {
            try
            {
                string hostname = Dns.GetHostName();
                return hostname;
            }
            catch { return ""; }
        }
    }
}
