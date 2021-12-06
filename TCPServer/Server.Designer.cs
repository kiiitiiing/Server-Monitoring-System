
namespace TCPServer
{
    partial class Server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_start = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_addess = new System.Windows.Forms.TextBox();
            this.machineName = new System.Windows.Forms.Label();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.connections = new System.Windows.Forms.ListBox();
            this.ServerMonitoring = new System.Windows.Forms.TabControl();
            this.ServerMonitoringTab = new System.Windows.Forms.TabPage();
            this.IPMonitoringTab = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusPing = new System.Windows.Forms.ToolStripStatusLabel();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.pingLogs = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstIpAddress = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.ServerMonitoring.SuspendLayout();
            this.ServerMonitoringTab.SuspendLayout();
            this.IPMonitoringTab.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(6, 54);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(63, 38);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(6, 98);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(383, 220);
            this.logs.TabIndex = 2;
            this.logs.Text = "";
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(75, 54);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(63, 38);
            this.btn_stop.TabIndex = 1;
            this.btn_stop.Text = "STOP";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "host";
            // 
            // txt_addess
            // 
            this.txt_addess.Location = new System.Drawing.Point(9, 22);
            this.txt_addess.Name = "txt_addess";
            this.txt_addess.Size = new System.Drawing.Size(100, 20);
            this.txt_addess.TabIndex = 4;
            this.txt_addess.Text = "10.10.20.7";
            // 
            // machineName
            // 
            this.machineName.AutoSize = true;
            this.machineName.Location = new System.Drawing.Point(30, 6);
            this.machineName.Name = "machineName";
            this.machineName.Size = new System.Drawing.Size(79, 13);
            this.machineName.TabIndex = 3;
            this.machineName.Text = "machine_name";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(138, 22);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(100, 20);
            this.txt_port.TabIndex = 4;
            this.txt_port.Text = "13000";
            // 
            // connections
            // 
            this.connections.FormattingEnabled = true;
            this.connections.Location = new System.Drawing.Point(244, 6);
            this.connections.Name = "connections";
            this.connections.Size = new System.Drawing.Size(145, 82);
            this.connections.TabIndex = 5;
            // 
            // ServerMonitoring
            // 
            this.ServerMonitoring.Controls.Add(this.ServerMonitoringTab);
            this.ServerMonitoring.Controls.Add(this.IPMonitoringTab);
            this.ServerMonitoring.Controls.Add(this.tabPage1);
            this.ServerMonitoring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerMonitoring.Location = new System.Drawing.Point(0, 0);
            this.ServerMonitoring.Name = "ServerMonitoring";
            this.ServerMonitoring.SelectedIndex = 0;
            this.ServerMonitoring.Size = new System.Drawing.Size(431, 379);
            this.ServerMonitoring.TabIndex = 6;
            // 
            // ServerMonitoringTab
            // 
            this.ServerMonitoringTab.Controls.Add(this.connections);
            this.ServerMonitoringTab.Controls.Add(this.btn_start);
            this.ServerMonitoringTab.Controls.Add(this.txt_port);
            this.ServerMonitoringTab.Controls.Add(this.btn_stop);
            this.ServerMonitoringTab.Controls.Add(this.txt_addess);
            this.ServerMonitoringTab.Controls.Add(this.logs);
            this.ServerMonitoringTab.Controls.Add(this.machineName);
            this.ServerMonitoringTab.Controls.Add(this.label1);
            this.ServerMonitoringTab.Location = new System.Drawing.Point(4, 22);
            this.ServerMonitoringTab.Name = "ServerMonitoringTab";
            this.ServerMonitoringTab.Padding = new System.Windows.Forms.Padding(3);
            this.ServerMonitoringTab.Size = new System.Drawing.Size(423, 353);
            this.ServerMonitoringTab.TabIndex = 0;
            this.ServerMonitoringTab.Text = "Server";
            this.ServerMonitoringTab.UseVisualStyleBackColor = true;
            // 
            // IPMonitoringTab
            // 
            this.IPMonitoringTab.Controls.Add(this.statusStrip1);
            this.IPMonitoringTab.Controls.Add(this.rtbStatus);
            this.IPMonitoringTab.Controls.Add(this.pingLogs);
            this.IPMonitoringTab.Controls.Add(this.button1);
            this.IPMonitoringTab.Controls.Add(this.btnStop);
            this.IPMonitoringTab.Controls.Add(this.btnStart);
            this.IPMonitoringTab.Controls.Add(this.label2);
            this.IPMonitoringTab.Controls.Add(this.lstIpAddress);
            this.IPMonitoringTab.Location = new System.Drawing.Point(4, 22);
            this.IPMonitoringTab.Name = "IPMonitoringTab";
            this.IPMonitoringTab.Padding = new System.Windows.Forms.Padding(3);
            this.IPMonitoringTab.Size = new System.Drawing.Size(423, 353);
            this.IPMonitoringTab.TabIndex = 1;
            this.IPMonitoringTab.Text = "Public IP";
            this.IPMonitoringTab.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusProgressBar,
            this.statusPing});
            this.statusStrip1.Location = new System.Drawing.Point(3, 328);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(417, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // statusPing
            // 
            this.statusPing.Name = "statusPing";
            this.statusPing.Size = new System.Drawing.Size(77, 17);
            this.statusPing.Text = "txtStatusPing";
            // 
            // rtbStatus
            // 
            this.rtbStatus.Location = new System.Drawing.Point(223, 68);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.Size = new System.Drawing.Size(192, 257);
            this.rtbStatus.TabIndex = 3;
            this.rtbStatus.Text = "";
            // 
            // pingLogs
            // 
            this.pingLogs.Location = new System.Drawing.Point(8, 68);
            this.pingLogs.Name = "pingLogs";
            this.pingLogs.Size = new System.Drawing.Size(209, 257);
            this.pingLogs.TabIndex = 3;
            this.pingLogs.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(69, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(55, 56);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(8, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(55, 56);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP Addresses";
            // 
            // lstIpAddress
            // 
            this.lstIpAddress.FormattingEnabled = true;
            this.lstIpAddress.Location = new System.Drawing.Point(295, 6);
            this.lstIpAddress.Name = "lstIpAddress";
            this.lstIpAddress.Size = new System.Drawing.Size(120, 56);
            this.lstIpAddress.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(423, 353);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 379);
            this.Controls.Add(this.ServerMonitoring);
            this.Name = "Server";
            this.Text = "TCP Server";
            this.ServerMonitoring.ResumeLayout(false);
            this.ServerMonitoringTab.ResumeLayout(false);
            this.ServerMonitoringTab.PerformLayout();
            this.IPMonitoringTab.ResumeLayout(false);
            this.IPMonitoringTab.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_addess;
        private System.Windows.Forms.Label machineName;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.ListBox connections;
        private System.Windows.Forms.TabControl ServerMonitoring;
        private System.Windows.Forms.TabPage ServerMonitoringTab;
        private System.Windows.Forms.TabPage IPMonitoringTab;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar statusProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel statusPing;
        private System.Windows.Forms.RichTextBox pingLogs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstIpAddress;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button2;
    }
}

