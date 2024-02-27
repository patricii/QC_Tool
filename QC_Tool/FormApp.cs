﻿using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QC_Tool
{
    public partial class FormApp : Form
    {
        ReadingXMLFile readXML;
        Cmd CmdC;
        DataGridView Dgv;
        private static FormApp INSTANCE = null;

        public FormApp()
        {
            InitializeComponent();
            GetClasses();
            INSTANCE = this;
            Dgv.PopulateToolDGV();
            readXML.FillingComboBoxProducts();
        }

        public static FormApp getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new FormApp();

            return INSTANCE;
        }

        private void GetClasses()
        {
            readXML = new ReadingXMLFile();
            CmdC = new Cmd();
            Dgv = new DataGridView();
        }

        public string CheckDirectoryQpmCli()
        {
            try
            {
                string directory = @"C:\Program Files (x86)\Qualcomm\QPM-CLI";
                string pathSave = @".\License_List.txt";
                if (Directory.EnumerateFileSystemEntries(directory).Any())
                {
                    CmdC.Commands("qpm-cli --license-list", pathSave);

                    if (File.Exists(pathSave))
                    {
                        using (StreamReader reader = new StreamReader(pathSave))
                        {
                            string line = string.Empty;

                            if ((line = reader.ReadLine()) == null)
                                return "FAIL";

                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line.Contains("is not recognized as an internal or external command"))
                                    return "FAIL";
                            }
                        }
                    }
                    else
                        return "FAIL";
                }
                else
                    return "FAIL";

                return "PASS";
            }
            catch
            { return "FAIL"; }
        }

        private void comboBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEstation.Enabled = true;
            buttonActions.Enabled = false;
            comboBoxEstation.Items.Clear();
            readXML.FillingComboBoxStations(readXML.allProducts);
        }

        private void buttonActions_Click(object sender, EventArgs e)
        {
            readXML.FillingDGVTools(readXML.indexProduct, readXML.countStationName);
        }

        private void comboBoxEstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonActions.Enabled = true;
        }
    }
}