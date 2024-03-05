﻿using System.Drawing;

namespace QC_Tool
{
    class DataGridView
    {
        FormApp frmApp;
        Utils uts = new Utils();

        public void PopulateResultDGV()
        {
            frmApp = FormApp.getInstance();

            try
            {
                frmApp.dataGridViewCheckTools.Rows[0].Cells[2].Value = frmApp.CheckDirectoryQpmCli();

                if (frmApp.dataGridViewCheckTools.Rows[0].Cells[2].Value.ToString() == "OK")
                    uts.cleanLabel();


                else
                {
                    frmApp.comboBoxProducts.Enabled = false;
                    uts.labelError("QPM-CLI not found, please install the QPM3!");
                }
                formattingDGV();
            }
            catch
            {
                frmApp.dataGridViewCheckTools.Rows[0].Cells[2].Value = "NOK";
                formattingDGV();
                uts.labelError("QPM-CLI not found, please install the QPM3!");
            }
        }

        public void PopulateToolDGV()
        {
            frmApp = FormApp.getInstance();
            frmApp.dataGridViewCheckTools.Rows.Add();
            frmApp.dataGridViewCheckTools.Rows[0].Cells[0].Value = "QPM-CLI";
            frmApp.dataGridViewCheckTools.Rows[0].Cells[1].Value = "Software";
            PopulateResultDGV();
        }

        public void formattingDGV()
        {
            int rowsDGV = frmApp.dataGridViewCheckTools.Rows.Count;

            for (int i = 0; i < rowsDGV; i++)
            {
                if (frmApp.dataGridViewCheckTools.Rows[i].Cells[2].Value.ToString() == "NOK")
                {
                    frmApp.dataGridViewCheckTools.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                   // frmApp.dataGridViewCheckTools.Rows[i].DefaultCellStyle.ForeColor = Color.White;


                }

                else
                {
                    frmApp.dataGridViewCheckTools.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                   // frmApp.dataGridViewCheckTools.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }
            }
        }


    }
}
