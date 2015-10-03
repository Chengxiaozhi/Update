using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MyUpdate.Utils;
using MyUpdate.Entity;
using System.Threading;

namespace MyUpdate
{
    public partial class RecoverForm : MyBaseForm
    {
        public RecoverForm()
        {
            InitializeComponent();
        }

        private void BackupForm_Load(object sender, EventArgs e)
        {
            List<string> list= GetBackupList();
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].Substring(list[i].LastIndexOf('\\')).Trim('\\').Replace(".rar", "");
            }
            listBox1.Items.AddRange(list.ToArray());
        }

        private void RecoverForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartApp();
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择相应的还原点");
                return;
            }
            this.btnOption.Enabled = false;
            this.btnOption.Text = "正在还原...";
            string fileName = listBox1.SelectedItem.ToString();
            string version = fileName.Substring(fileName.LastIndexOf('_')).Trim('_');
            fileName = GetBackupList()[listBox1.SelectedIndex];

            CloseApp();

            #region 用Thread

            //Thread t = new Thread(new ThreadStart(delegate()
            //{
            //    #region thread method
            //    string path=AppParameter.MainPath.Trim();
            //    path=path.Substring(0,path.LastIndexOf('\\'));
            //    ZipHelper.UnZip(fileName, path);
            //    MessageBox.Show("还原完毕，程序已还原到" + version,"提示");
            //    AppParameter.Version = version;
            //    ConfigHelper.UpdateAppConfig("version", version);
            //    File.Delete(AppParameter.LocalUPdateConfig);

            //    if (this.InvokeRequired)
            //    {
            //        this.Invoke((Action)delegate() {
            //            this.btnOption.Enabled = true;
            //            this.btnOption.Text = "还原";
            //        });
            //    }

            //    #endregion

            //}));

            //t.Start();

            #endregion

            #region 用Action

            Action callBack = new Action(delegate() {

                string path = AppParameter.MainPath.Trim();
                path = path.Substring(0, path.LastIndexOf('\\'));
                ZipHelper.UnZip(fileName, path);
                MessageBox.Show("还原完毕，程序已还原到" + version, "提示");
                AppParameter.Version = version;
                ConfigHelper.UpdateAppConfig("version", version);
                File.Delete(AppParameter.LocalUPdateConfig);

                if (this.InvokeRequired)
                {
                    this.Invoke((Action)delegate()
                    {
                        this.btnOption.Enabled = true;
                        this.btnOption.Text = "还原";
                    });
                }
            });

            callBack.BeginInvoke(null, null);

            #endregion
        }

        /// <summary>
        /// 获取备份文件列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetBackupList()
        {
            List<string> result = Directory.GetFiles(AppParameter.BackupPath, "*.rar").ToList();            
            return result;
        }
    }
}
