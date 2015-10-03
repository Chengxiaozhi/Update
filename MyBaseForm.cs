using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyUpdate.Entity;
using MyUpdate.Utils;

namespace MyUpdate
{
    public class MyBaseForm:Form
    {
        protected void CloseApp()
        {
            #region  Process Handling
          
            List<string> processNames = new List<string>();
            string mainPro = string.Empty;
            processNames.AddRange(AppParameter.AppNames);
            for (int i = 0; i < processNames.Count; i++)
            {
                processNames[i] = processNames[i].Substring(processNames[i].LastIndexOf('\\')).Trim('\\').Replace(".exe", "");
            }
            mainPro = processNames.FirstOrDefault();
            AppParameter.IsRunning = ProcessHelper.IsRunningProcess(mainPro);
            if (AppParameter.IsRunning)
            {
                MessageBox.Show("此操作需要关闭要更新的程序，请保存相关数据按确定继续", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (string item in processNames)
                    ProcessHelper.CloseProcess(item);
            }

            #endregion
        }

        protected void StartApp()
        {
            try
            {
                if (AppParameter.IsRunning) ProcessHelper.StartProcess(AppParameter.AppNames.First());
            }
            catch (Exception ex)
            {

                MessageBox.Show("程序无法启动!" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MyBaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "MyBaseForm";
            this.ResumeLayout(false);

        }
    }
}
