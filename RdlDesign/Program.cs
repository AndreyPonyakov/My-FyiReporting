﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels;

namespace fyiReporting.RdlDesign
{
    public class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string version = "454";// !!!! warning  !!!! string needs to be changed with when release version changes
           
            string ipcChannelPortName = string.Format("RdlProject{0}", version); 
            // Determine if an instance is already running?
            bool firstInstance;
            string mName = string.Format("Local\\RdlDesigner{0}", version);         
            //   can't use Assembly in this context
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, mName, out firstInstance);
         
            if (firstInstance)
            {   // just start up the designer when we're first in line
                Application.EnableVisualStyles();
                Application.DoEvents();
                Application.Run(new RdlDesigner(ipcChannelPortName, true));
                return;
            }

            // Process already running.   Notify other process that is might need to open another file
            string[] args = Environment.GetCommandLineArgs();

        }

    }
}
