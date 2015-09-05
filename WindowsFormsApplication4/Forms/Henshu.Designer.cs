using System.Windows.Forms;
namespace WordConverter_v2.Forms
{
    partial class Henshu
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.registeredPairsCbx = new System.Windows.Forms.CheckBox();
            this.dataTypeCbx = new System.Windows.Forms.ComboBox();
            this.kensu = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.registBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.butsurimeiTextBox = new System.Windows.Forms.TextBox();
            this.tanitsuDataGridView = new System.Windows.Forms.DataGridView();
            this.ronrimei1TextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.kensuIkkatsu = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ikkatsuRegistBtn = new System.Windows.Forms.Button();
            this.ikkatsuDataGridView = new System.Windows.Forms.DataGridView();
            this.readFile = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.orSettingBtn = new System.Windows.Forms.Button();
            this.orSetthingDataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tanitsuDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ikkatsuDataGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orSetthingDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(96, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(745, 483);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.registeredPairsCbx);
            this.tabPage1.Controls.Add(this.dataTypeCbx);
            this.tabPage1.Controls.Add(this.kensu);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.delete);
            this.tabPage1.Controls.Add(this.addBtn);
            this.tabPage1.Controls.Add(this.registBtn);
            this.tabPage1.Controls.Add(this.searchBtn);
            this.tabPage1.Controls.Add(this.clearBtn);
            this.tabPage1.Controls.Add(this.butsurimeiTextBox);
            this.tabPage1.Controls.Add(this.tanitsuDataGridView);
            this.tabPage1.Controls.Add(this.ronrimei1TextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(737, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "単一登録";
            // 
            // registeredPairsCbx
            // 
            this.registeredPairsCbx.AutoSize = true;
            this.registeredPairsCbx.Location = new System.Drawing.Point(330, 70);
            this.registeredPairsCbx.Name = "registeredPairsCbx";
            this.registeredPairsCbx.Size = new System.Drawing.Size(89, 16);
            this.registeredPairsCbx.TabIndex = 27;
            this.registeredPairsCbx.Text = "対で登録する";
            this.registeredPairsCbx.UseVisualStyleBackColor = true;
            // 
            // dataTypeCbx
            // 
            this.dataTypeCbx.FormattingEnabled = true;
            this.dataTypeCbx.Items.AddRange(new object[] {
            "String",
            "Integer",
            "int",
            "Boolean",
            "boolean",
            "byte",
            "Byte",
            "short",
            "Short",
            "long",
            "Long",
            "char",
            "float",
            "Float",
            "double",
            "Double",
            ""});
            this.dataTypeCbx.Location = new System.Drawing.Point(163, 68);
            this.dataTypeCbx.Name = "dataTypeCbx";
            this.dataTypeCbx.Size = new System.Drawing.Size(131, 20);
            this.dataTypeCbx.TabIndex = 26;
            this.dataTypeCbx.Validated += new System.EventHandler(this.dataTypeCbx_Validated);
            // 
            // kensu
            // 
            this.kensu.AutoSize = true;
            this.kensu.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kensu.Location = new System.Drawing.Point(640, 118);
            this.kensu.Name = "kensu";
            this.kensu.Size = new System.Drawing.Size(0, 17);
            this.kensu.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(602, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "件数：";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(87, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "物理名";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(87, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "データ型";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(87, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "論理名";
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.delete.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.delete.Location = new System.Drawing.Point(374, 399);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(142, 27);
            this.delete.TabIndex = 20;
            this.delete.Text = "削除";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.addBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.addBtn.Location = new System.Drawing.Point(416, 103);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(96, 23);
            this.addBtn.TabIndex = 17;
            this.addBtn.Text = "追加";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // registBtn
            // 
            this.registBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.registBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.registBtn.Location = new System.Drawing.Point(199, 399);
            this.registBtn.Name = "registBtn";
            this.registBtn.Size = new System.Drawing.Size(142, 27);
            this.registBtn.TabIndex = 19;
            this.registBtn.Text = "登録";
            this.registBtn.UseVisualStyleBackColor = false;
            this.registBtn.Click += new System.EventHandler(this.registBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.searchBtn.Location = new System.Drawing.Point(192, 103);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(96, 23);
            this.searchBtn.TabIndex = 15;
            this.searchBtn.Text = "検索";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.clearBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clearBtn.Location = new System.Drawing.Point(304, 103);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(96, 23);
            this.clearBtn.TabIndex = 16;
            this.clearBtn.Text = "クリア";
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // butsurimeiTextBox
            // 
            this.butsurimeiTextBox.Location = new System.Drawing.Point(163, 41);
            this.butsurimeiTextBox.Name = "butsurimeiTextBox";
            this.butsurimeiTextBox.Size = new System.Drawing.Size(417, 19);
            this.butsurimeiTextBox.TabIndex = 14;
            this.butsurimeiTextBox.Validated += new System.EventHandler(this.butsurimeiTextBox_Validated);
            // 
            // tanitsuDataGridView
            // 
            this.tanitsuDataGridView.AllowUserToResizeColumns = false;
            this.tanitsuDataGridView.AllowUserToResizeRows = false;
            this.tanitsuDataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("メイリオ", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tanitsuDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.tanitsuDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tanitsuDataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.tanitsuDataGridView.Location = new System.Drawing.Point(26, 139);
            this.tanitsuDataGridView.Name = "tanitsuDataGridView";
            this.tanitsuDataGridView.RowHeadersVisible = false;
            this.tanitsuDataGridView.RowTemplate.Height = 21;
            this.tanitsuDataGridView.Size = new System.Drawing.Size(670, 240);
            this.tanitsuDataGridView.TabIndex = 18;
            this.tanitsuDataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.tanitsuDataGridView_CellValidated);
            this.tanitsuDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.tanitsuDataGridView_CellValidating);
            this.tanitsuDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tanitsuDataGridView_CellValueChanged);
            this.tanitsuDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.tanitsuDataGridView_CurrentCellDirtyStateChanged);
            // 
            // ronrimei1TextBox
            // 
            this.ronrimei1TextBox.Location = new System.Drawing.Point(163, 14);
            this.ronrimei1TextBox.Name = "ronrimei1TextBox";
            this.ronrimei1TextBox.Size = new System.Drawing.Size(417, 19);
            this.ronrimei1TextBox.TabIndex = 12;
            this.ronrimei1TextBox.Validated += new System.EventHandler(this.ronrimei1TextBox_Validated);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage2.Controls.Add(this.kensuIkkatsu);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.ikkatsuRegistBtn);
            this.tabPage2.Controls.Add(this.ikkatsuDataGridView);
            this.tabPage2.Controls.Add(this.readFile);
            this.tabPage2.Controls.Add(this.openFile);
            this.tabPage2.Controls.Add(this.filePath);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(737, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "一括登録";
            // 
            // kensuIkkatsu
            // 
            this.kensuIkkatsu.AutoSize = true;
            this.kensuIkkatsu.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kensuIkkatsu.Location = new System.Drawing.Point(640, 118);
            this.kensuIkkatsu.Name = "kensuIkkatsu";
            this.kensuIkkatsu.Size = new System.Drawing.Size(0, 17);
            this.kensuIkkatsu.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(602, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "件数：";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(103, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "ファイルパス";
            // 
            // ikkatsuRegistBtn
            // 
            this.ikkatsuRegistBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ikkatsuRegistBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ikkatsuRegistBtn.Location = new System.Drawing.Point(270, 398);
            this.ikkatsuRegistBtn.Name = "ikkatsuRegistBtn";
            this.ikkatsuRegistBtn.Size = new System.Drawing.Size(177, 30);
            this.ikkatsuRegistBtn.TabIndex = 15;
            this.ikkatsuRegistBtn.Text = "登録";
            this.ikkatsuRegistBtn.UseVisualStyleBackColor = false;
            this.ikkatsuRegistBtn.Click += new System.EventHandler(this.ikkatsuRegistBtn_Click);
            // 
            // ikkatsuDataGridView
            // 
            this.ikkatsuDataGridView.AllowUserToResizeColumns = false;
            this.ikkatsuDataGridView.AllowUserToResizeRows = false;
            this.ikkatsuDataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("メイリオ", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ikkatsuDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.ikkatsuDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ikkatsuDataGridView.DefaultCellStyle = dataGridViewCellStyle9;
            this.ikkatsuDataGridView.Location = new System.Drawing.Point(26, 139);
            this.ikkatsuDataGridView.Name = "ikkatsuDataGridView";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ikkatsuDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.ikkatsuDataGridView.RowHeadersVisible = false;
            this.ikkatsuDataGridView.RowTemplate.Height = 21;
            this.ikkatsuDataGridView.Size = new System.Drawing.Size(670, 240);
            this.ikkatsuDataGridView.TabIndex = 12;
            // 
            // readFile
            // 
            this.readFile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.readFile.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.readFile.Location = new System.Drawing.Point(121, 78);
            this.readFile.Name = "readFile";
            this.readFile.Size = new System.Drawing.Size(101, 27);
            this.readFile.TabIndex = 11;
            this.readFile.Text = "読み込み";
            this.readFile.UseVisualStyleBackColor = false;
            this.readFile.Click += new System.EventHandler(this.readFile_Click);
            // 
            // openFile
            // 
            this.openFile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.openFile.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.openFile.Location = new System.Drawing.Point(511, 44);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(107, 25);
            this.openFile.TabIndex = 10;
            this.openFile.Text = "開く";
            this.openFile.UseVisualStyleBackColor = false;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(109, 47);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(379, 19);
            this.filePath.TabIndex = 9;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage3.Controls.Add(this.orSettingBtn);
            this.tabPage3.Controls.Add(this.orSetthingDataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(737, 450);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ORマッピング";
            // 
            // orSettingBtn
            // 
            this.orSettingBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.orSettingBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.orSettingBtn.Location = new System.Drawing.Point(281, 382);
            this.orSettingBtn.Name = "orSettingBtn";
            this.orSettingBtn.Size = new System.Drawing.Size(177, 30);
            this.orSettingBtn.TabIndex = 1;
            this.orSettingBtn.Text = "登録";
            this.orSettingBtn.UseVisualStyleBackColor = false;
            this.orSettingBtn.Click += new System.EventHandler(this.orSettingBtn_Click);
            // 
            // orSetthingDataGridView1
            // 
            this.orSetthingDataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.orSetthingDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orSetthingDataGridView1.Location = new System.Drawing.Point(63, 68);
            this.orSetthingDataGridView1.Name = "orSetthingDataGridView1";
            this.orSetthingDataGridView1.RowTemplate.Height = 21;
            this.orSetthingDataGridView1.Size = new System.Drawing.Size(611, 287);
            this.orSetthingDataGridView1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Henshu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(745, 485);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Henshu";
            this.Opacity = 0.98D;
            this.Text = "編集";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Henshu_FormClosing);
            this.Load += new System.EventHandler(this.Henshu_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tanitsuDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ikkatsuDataGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orSetthingDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button registBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.TextBox ronrimei1TextBox;
        private System.Windows.Forms.TextBox butsurimeiTextBox;
        private System.Windows.Forms.DataGridView tanitsuDataGridView;
        private System.Windows.Forms.Button ikkatsuRegistBtn;
        private System.Windows.Forms.DataGridView ikkatsuDataGridView;
        private System.Windows.Forms.Button readFile;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label5;
        private Label kensu;
        private Label kensuIkkatsu;
        private Label label7;
        private Label label2;
        private ComboBox dataTypeCbx;
        private CheckBox registeredPairsCbx;
        private TabPage tabPage3;
        private DataGridView orSetthingDataGridView1;
        private Button orSettingBtn;
    }
}