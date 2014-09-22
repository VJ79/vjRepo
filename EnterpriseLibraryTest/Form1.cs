using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace EnterpriseLibraryTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.EventInstance ei=new System.Diagnostics.EventInstance(22,44);
            System.Diagnostics.EventLog.WriteEvent("fds", ei, "fds");
            LogEntry logEntry = new LogEntry();
            logEntry.EventId = 1;
            logEntry.Priority = 1;
            logEntry.Message = "»’÷æƒ⁄»›";
            logEntry.Categories.Clear();
            logEntry.Categories.Add("Category");
            logEntry.Title = "Title11";
            logEntry.TimeStamp = DateTime.Now;
            // Writes the log entry.
            Logger.Write(logEntry);
        }
    }
}