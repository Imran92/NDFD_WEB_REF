using GoogleMaps.LocationServices;
using NDFD_WEB_REF.gov.weather.graphical;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDFD_WEB_REF
{
    public partial class Form1 : Form
    {
        double lat;
        double lon;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getLongitudeLatitudeFromAddress();
            ndfdXML ndfd = new ndfdXML();
            ndfd.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.1700.107 Safari/537.36";
            outputBox.Text = ndfd.NDFDgen(Convert.ToDecimal(lat), Convert.ToDecimal(lon), "time-series", DateTime.Now.Date, DateTime.Now.Date, string.Empty, null);
        }
        private void getLongitudeLatitudeFromAddress()
        {
            var locationService = new GoogleLocationService();
            var address = inputBox.Text;
            var point = locationService.GetLatLongFromAddress(address);

            lat = point.Latitude;
            lon = point.Longitude;
        }
    }
}
