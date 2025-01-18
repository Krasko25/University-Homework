namespace Семестр2_ЛР1
{
    partial class OrganiserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrganiserForm));
            this.tableLayoutPanelOrganiserView = new System.Windows.Forms.TableLayoutPanel();
            this.labelChooseCatergory = new System.Windows.Forms.Label();
            this.comboBoxTypeOfEvents = new System.Windows.Forms.ComboBox();
            this.radioButtonAllByCategory = new System.Windows.Forms.RadioButton();
            this.radioButtonAllEvents = new System.Windows.Forms.RadioButton();
            this.listViewOrganiser = new System.Windows.Forms.ListView();
            this.columnHeaderData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripForEachEvent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelOrganizerOperations = new System.Windows.Forms.TableLayoutPanel();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelOperations = new System.Windows.Forms.Label();
            this.buttonSort = new System.Windows.Forms.Button();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanelOrganiserView.SuspendLayout();
            this.contextMenuStripForEachEvent.SuspendLayout();
            this.tableLayoutPanelOrganizerOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelOrganiserView
            // 
            this.tableLayoutPanelOrganiserView.ColumnCount = 2;
            this.tableLayoutPanelOrganiserView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOrganiserView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOrganiserView.Controls.Add(this.labelChooseCatergory, 0, 0);
            this.tableLayoutPanelOrganiserView.Controls.Add(this.comboBoxTypeOfEvents, 1, 1);
            this.tableLayoutPanelOrganiserView.Controls.Add(this.radioButtonAllByCategory, 0, 1);
            this.tableLayoutPanelOrganiserView.Controls.Add(this.radioButtonAllEvents, 0, 2);
            this.tableLayoutPanelOrganiserView.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelOrganiserView.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelOrganiserView.Margin = new System.Windows.Forms.Padding(8, 16, 8, 8);
            this.tableLayoutPanelOrganiserView.Name = "tableLayoutPanelOrganiserView";
            this.tableLayoutPanelOrganiserView.RowCount = 3;
            this.tableLayoutPanelOrganiserView.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOrganiserView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOrganiserView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOrganiserView.Size = new System.Drawing.Size(446, 96);
            this.tableLayoutPanelOrganiserView.TabIndex = 0;
            // 
            // labelChooseCatergory
            // 
            this.labelChooseCatergory.AutoSize = true;
            this.labelChooseCatergory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChooseCatergory.Location = new System.Drawing.Point(8, 16);
            this.labelChooseCatergory.Margin = new System.Windows.Forms.Padding(8, 16, 8, 4);
            this.labelChooseCatergory.Name = "labelChooseCatergory";
            this.labelChooseCatergory.Size = new System.Drawing.Size(89, 17);
            this.labelChooseCatergory.TabIndex = 0;
            this.labelChooseCatergory.Text = "Отображать";
            // 
            // comboBoxTypeOfEvents
            // 
            this.comboBoxTypeOfEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTypeOfEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxTypeOfEvents.FormattingEnabled = true;
            this.comboBoxTypeOfEvents.Location = new System.Drawing.Point(227, 41);
            this.comboBoxTypeOfEvents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.comboBoxTypeOfEvents.Name = "comboBoxTypeOfEvents";
            this.comboBoxTypeOfEvents.Size = new System.Drawing.Size(215, 25);
            this.comboBoxTypeOfEvents.TabIndex = 1;
            this.comboBoxTypeOfEvents.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeOfEvents_SelectedIndexChanged);
            // 
            // radioButtonAllByCategory
            // 
            this.radioButtonAllByCategory.AutoSize = true;
            this.radioButtonAllByCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonAllByCategory.Location = new System.Drawing.Point(8, 41);
            this.radioButtonAllByCategory.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.radioButtonAllByCategory.Name = "radioButtonAllByCategory";
            this.radioButtonAllByCategory.Size = new System.Drawing.Size(115, 21);
            this.radioButtonAllByCategory.TabIndex = 2;
            this.radioButtonAllByCategory.TabStop = true;
            this.radioButtonAllByCategory.Text = "По категории";
            this.radioButtonAllByCategory.UseVisualStyleBackColor = true;
            this.radioButtonAllByCategory.CheckedChanged += new System.EventHandler(this.radioButtonAllByCategory_CheckedChanged);
            // 
            // radioButtonAllEvents
            // 
            this.radioButtonAllEvents.AutoSize = true;
            this.radioButtonAllEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonAllEvents.Location = new System.Drawing.Point(8, 70);
            this.radioButtonAllEvents.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.radioButtonAllEvents.Name = "radioButtonAllEvents";
            this.radioButtonAllEvents.Size = new System.Drawing.Size(110, 21);
            this.radioButtonAllEvents.TabIndex = 3;
            this.radioButtonAllEvents.TabStop = true;
            this.radioButtonAllEvents.Text = "Все события";
            this.radioButtonAllEvents.UseVisualStyleBackColor = true;
            this.radioButtonAllEvents.CheckedChanged += new System.EventHandler(this.radioButtonAllEvents_CheckedChanged);
            // 
            // listViewOrganiser
            // 
            this.listViewOrganiser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderData,
            this.columnHeaderTime,
            this.columnHeaderEvent,
            this.columnHeaderCategory});
            this.listViewOrganiser.ContextMenuStrip = this.contextMenuStripForEachEvent;
            this.listViewOrganiser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewOrganiser.FullRowSelect = true;
            this.listViewOrganiser.GridLines = true;
            this.listViewOrganiser.HideSelection = false;
            this.listViewOrganiser.Location = new System.Drawing.Point(0, 96);
            this.listViewOrganiser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listViewOrganiser.MultiSelect = false;
            this.listViewOrganiser.Name = "listViewOrganiser";
            this.listViewOrganiser.Size = new System.Drawing.Size(446, 495);
            this.listViewOrganiser.SmallImageList = this.imageList;
            this.listViewOrganiser.TabIndex = 1;
            this.listViewOrganiser.UseCompatibleStateImageBehavior = false;
            this.listViewOrganiser.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderData
            // 
            this.columnHeaderData.Text = "Дата";
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Время";
            // 
            // columnHeaderEvent
            // 
            this.columnHeaderEvent.Text = "Событие";
            this.columnHeaderEvent.Width = 212;
            // 
            // columnHeaderCategory
            // 
            this.columnHeaderCategory.Text = "Категория";
            this.columnHeaderCategory.Width = 107;
            // 
            // contextMenuStripForEachEvent
            // 
            this.contextMenuStripForEachEvent.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripForEachEvent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditEvent,
            this.DeleteEvent});
            this.contextMenuStripForEachEvent.Name = "contextMenuStripForEachEvent";
            this.contextMenuStripForEachEvent.Size = new System.Drawing.Size(155, 48);
            this.contextMenuStripForEachEvent.Click += new System.EventHandler(this.contextMenuStripForEachEvent_Click);
            // 
            // EditEvent
            // 
            this.EditEvent.Name = "EditEvent";
            this.EditEvent.Size = new System.Drawing.Size(154, 22);
            this.EditEvent.Text = "Редактировать";
            this.EditEvent.Click += new System.EventHandler(this.EditEvent_Click);
            // 
            // DeleteEvent
            // 
            this.DeleteEvent.Name = "DeleteEvent";
            this.DeleteEvent.Size = new System.Drawing.Size(154, 22);
            this.DeleteEvent.Text = "Удалить";
            this.DeleteEvent.Click += new System.EventHandler(this.DeleteEvent_Click);
            // 
            // tableLayoutPanelOrganizerOperations
            // 
            this.tableLayoutPanelOrganizerOperations.ColumnCount = 4;
            this.tableLayoutPanelOrganizerOperations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.32096F));
            this.tableLayoutPanelOrganizerOperations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.22016F));
            this.tableLayoutPanelOrganizerOperations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.45889F));
            this.tableLayoutPanelOrganizerOperations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOrganizerOperations.Controls.Add(this.buttonFind, 3, 1);
            this.tableLayoutPanelOrganizerOperations.Controls.Add(this.buttonAdd, 1, 1);
            this.tableLayoutPanelOrganizerOperations.Controls.Add(this.labelOperations, 0, 0);
            this.tableLayoutPanelOrganizerOperations.Controls.Add(this.buttonSort, 0, 1);
            this.tableLayoutPanelOrganizerOperations.Controls.Add(this.textBoxQuery, 2, 1);
            this.tableLayoutPanelOrganizerOperations.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanelOrganizerOperations.Location = new System.Drawing.Point(0, 487);
            this.tableLayoutPanelOrganizerOperations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 16);
            this.tableLayoutPanelOrganizerOperations.Name = "tableLayoutPanelOrganizerOperations";
            this.tableLayoutPanelOrganizerOperations.RowCount = 2;
            this.tableLayoutPanelOrganizerOperations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanelOrganizerOperations.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOrganizerOperations.Size = new System.Drawing.Size(446, 104);
            this.tableLayoutPanelOrganizerOperations.TabIndex = 2;
            this.tableLayoutPanelOrganizerOperations.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanelOrganizerOperations_Paint);
            // 
            // buttonFind
            // 
            this.buttonFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFind.Image = global::Семестр2_ЛР1.Properties.Resources.search_icon1;
            this.buttonFind.Location = new System.Drawing.Point(402, 41);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(4, 4, 8, 16);
            this.buttonFind.MaximumSize = new System.Drawing.Size(35, 35);
            this.buttonFind.MinimumSize = new System.Drawing.Size(35, 35);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(35, 35);
            this.buttonFind.TabIndex = 12;
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdd.Location = new System.Drawing.Point(113, 41);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 27);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(76, 37);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelOperations
            // 
            this.labelOperations.AutoSize = true;
            this.labelOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOperations.Location = new System.Drawing.Point(8, 16);
            this.labelOperations.Margin = new System.Windows.Forms.Padding(8, 16, 8, 4);
            this.labelOperations.Name = "labelOperations";
            this.labelOperations.Size = new System.Drawing.Size(75, 17);
            this.labelOperations.TabIndex = 1;
            this.labelOperations.Text = "Операции";
            // 
            // buttonSort
            // 
            this.buttonSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSort.Location = new System.Drawing.Point(8, 41);
            this.buttonSort.Margin = new System.Windows.Forms.Padding(8, 4, 4, 27);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(97, 37);
            this.buttonSort.TabIndex = 2;
            this.buttonSort.Text = "Сортировать по алфавиту";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxQuery.Location = new System.Drawing.Point(197, 48);
            this.textBoxQuery.Margin = new System.Windows.Forms.Padding(4, 11, 4, 4);
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.Size = new System.Drawing.Size(197, 22);
            this.textBoxQuery.TabIndex = 13;
            this.textBoxQuery.TextChanged += new System.EventHandler(this.textBoxQuery_TextChanged);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            this.saveFileDialog.Title = "Сохранить файл";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            this.openFileDialog.Title = "Выберите файл с событиями";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Meeting");
            this.imageList.Images.SetKeyName(1, "Reminder");
            this.imageList.Images.SetKeyName(2, "Task");
            // 
            // OrganiserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 591);
            this.Controls.Add(this.tableLayoutPanelOrganizerOperations);
            this.Controls.Add(this.listViewOrganiser);
            this.Controls.Add(this.tableLayoutPanelOrganiserView);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(458, 552);
            this.Name = "OrganiserForm";
            this.Text = "Календарь событий";
            this.Load += new System.EventHandler(this.OrganiserForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrganiserForm_KeyDown);
            this.tableLayoutPanelOrganiserView.ResumeLayout(false);
            this.tableLayoutPanelOrganiserView.PerformLayout();
            this.contextMenuStripForEachEvent.ResumeLayout(false);
            this.tableLayoutPanelOrganizerOperations.ResumeLayout(false);
            this.tableLayoutPanelOrganizerOperations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOrganiserView;
        private System.Windows.Forms.Label labelChooseCatergory;
        private System.Windows.Forms.ComboBox comboBoxTypeOfEvents;
        private System.Windows.Forms.RadioButton radioButtonAllByCategory;
        private System.Windows.Forms.RadioButton radioButtonAllEvents;
        private System.Windows.Forms.ListView listViewOrganiser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOrganizerOperations;
        private System.Windows.Forms.Label labelOperations;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ColumnHeader columnHeaderData;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderEvent;
        private System.Windows.Forms.ColumnHeader columnHeaderCategory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForEachEvent;
        private System.Windows.Forms.ToolStripMenuItem EditEvent;
        private System.Windows.Forms.ToolStripMenuItem DeleteEvent;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ImageList imageList;
    }
}