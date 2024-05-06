namespace GMapMarkers
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gMapControl = new GMap.NET.WindowsForms.GMapControl();
            controlPanel = new Panel();
            saveCoordinatesButton = new Button();
            loadMarkersButton = new Button();
            clearMarkersButton = new Button();
            controlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // gMapControl
            // 
            gMapControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gMapControl.Bearing = 0F;
            gMapControl.CanDragMap = true;
            gMapControl.EmptyTileColor = Color.Navy;
            gMapControl.GrayScaleMode = false;
            gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMapControl.LevelsKeepInMemory = 5;
            gMapControl.Location = new Point(12, 12);
            gMapControl.MarkersEnabled = true;
            gMapControl.MaxZoom = 2;
            gMapControl.MinZoom = 2;
            gMapControl.MouseWheelZoomEnabled = true;
            gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl.Name = "gMapControl";
            gMapControl.NegativeMode = false;
            gMapControl.PolygonsEnabled = true;
            gMapControl.RetryLoadTile = 0;
            gMapControl.RoutesEnabled = true;
            gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gMapControl.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            gMapControl.ShowTileGridLines = false;
            gMapControl.Size = new Size(554, 537);
            gMapControl.TabIndex = 0;
            gMapControl.Zoom = 0D;
            gMapControl.OnMarkerEnter += gMapControl_OnMarkerEnter;
            gMapControl.OnMarkerLeave += gMapControl_OnMarkerLeave;
            gMapControl.Load += gMapControl_Load;
            gMapControl.MouseDown += gMapControl_MouseDown;
            gMapControl.MouseMove += gMapControl_MouseMove;
            gMapControl.MouseUp += gMapControl_MouseUp;
            // 
            // controlPanel
            // 
            controlPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlPanel.Controls.Add(saveCoordinatesButton);
            controlPanel.Controls.Add(loadMarkersButton);
            controlPanel.Controls.Add(clearMarkersButton);
            controlPanel.Location = new Point(589, 12);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(183, 88);
            controlPanel.TabIndex = 1;
            // 
            // saveCoordinatesButton
            // 
            saveCoordinatesButton.Location = new Point(3, 32);
            saveCoordinatesButton.Name = "saveCoordinatesButton";
            saveCoordinatesButton.Size = new Size(177, 23);
            saveCoordinatesButton.TabIndex = 7;
            saveCoordinatesButton.Text = "Сохранить координаты";
            saveCoordinatesButton.UseVisualStyleBackColor = true;
            saveCoordinatesButton.Click += saveCoordinatesButton_Click;
            // 
            // loadMarkersButton
            // 
            loadMarkersButton.Location = new Point(3, 3);
            loadMarkersButton.Name = "loadMarkersButton";
            loadMarkersButton.Size = new Size(177, 23);
            loadMarkersButton.TabIndex = 6;
            loadMarkersButton.Text = "Загрузить маркеры";
            loadMarkersButton.UseVisualStyleBackColor = true;
            loadMarkersButton.Click += loadMarkersButton_Click;
            // 
            // clearMarkersButton
            // 
            clearMarkersButton.Location = new Point(3, 61);
            clearMarkersButton.Name = "clearMarkersButton";
            clearMarkersButton.Size = new Size(177, 23);
            clearMarkersButton.TabIndex = 5;
            clearMarkersButton.Text = "Очистить карту";
            clearMarkersButton.UseVisualStyleBackColor = true;
            clearMarkersButton.Click += clearMarkersButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(controlPanel);
            Controls.Add(gMapControl);
            MinimumSize = new Size(800, 600);
            Name = "Form1";
            Text = "GMapMarkers";
            controlPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private Panel controlPanel;
        private Button clearMarkersButton;
        private Button loadMarkersButton;
        private Button saveCoordinatesButton;
    }
}