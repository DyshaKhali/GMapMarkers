using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Data.SqlClient;

namespace GMapMarkers
{
    public partial class Form1 : Form
    {
        private string connString = @"Data Source=DESKTOP-MQ7F80I\SQLEXPRESS; Initial Catalog=GMapMarkersDB; Integrated Security = True";
        private GMapOverlay markersOverlay;
        private bool isLeftButtonDown = false;
        private bool isMouseOnMarker = false;
        private GMarkerGoogle currentMarker;
        List<MarkerD> markersDB = new List<MarkerD>();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Form1()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
        }

        private void gMapControl_Load(object sender, EventArgs e)
        {
            gMapControl.Bearing = 0;
            gMapControl.GrayScaleMode = true;
            gMapControl.MarkersEnabled = true;
            gMapControl.NegativeMode = false;
            gMapControl.PolygonsEnabled = true;
            gMapControl.RoutesEnabled = true;
            gMapControl.CanDragMap = true;
            gMapControl.ShowCenter = false;
            gMapControl.ShowTileGridLines = false;
            gMapControl.Dock = DockStyle.Fill;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.MapProvider = GMapProviders.GoogleMap;

            gMapControl.MinZoom = 2;
            gMapControl.MaxZoom = 20;
            gMapControl.Zoom = 5;

            gMapControl.Position = new PointLatLng(57.15, 65.52);

            markersOverlay = new GMapOverlay("marker");
            gMapControl.Overlays.Add(markersOverlay);
        }

        private void clearMarkersButton_Click(object sender, EventArgs e)
        {
            markersDB = new List<MarkerD>();
            markersOverlay.Markers.Clear();
            markersOverlay.Clear();
        }

        private void loadMarkersButton_Click(object sender, EventArgs e)
        {
            List<MarkerD> markersDB = new List<MarkerD>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string getMarkersCommand = "SELECT marker_name, longitude, latitude FROM MarkersTable";

                using (SqlCommand cmd = new SqlCommand(getMarkersCommand, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MarkerD marker = new(
                                reader.GetString(0),
                                Convert.ToDouble(reader.GetString(1)),
                                Convert.ToDouble(reader.GetString(2)));
                            markersDB.Add(marker);
                        }
                    }
                }
                conn.Close();
            }

            foreach (MarkerD mark in markersDB)
            {
                PointLatLng point = new(mark.Latitude, mark.Longitude);
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = mark.MarkerName;
                markersOverlay.Markers.Add(marker);
            }
        }

        private void gMapControl_OnMarkerEnter(GMapMarker item)
        {
            currentMarker = (GMarkerGoogle)item;
            isMouseOnMarker = true;
        }

        private void gMapControl_OnMarkerLeave(GMapMarker item)
        {
            isMouseOnMarker = false;
        }

        private void gMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isLeftButtonDown = true;
        }

        private void gMapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isLeftButtonDown = false;
        }

        private void gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isLeftButtonDown && isMouseOnMarker)
            {
                if (currentMarker != null)
                {
                    PointLatLng point = gMapControl.FromLocalToLatLng(e.X, e.Y);
                    currentMarker.Position = point;
                }
            }
        }

        private void saveCoordinatesButton_Click(object sender, EventArgs e)
        {
            foreach (GMapMarker markerOnMap in markersOverlay.Markers)
            {
                if (markerOnMap != null)
                {
                    PointLatLng point = markerOnMap.Position;
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        string setMarkerCommand = "UPDATE MarkersTable " +
                            $"SET longitude = \'{point.Lng}\', latitude = \'{point.Lat}\' " +
                            $"WHERE marker_name = \'{markerOnMap.ToolTipText}\'";

                        using (SqlCommand cmd = new SqlCommand(setMarkerCommand, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
            }
        }
    }
}