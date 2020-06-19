using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using MediaBazaarSolution.DTO;
using MediaBazaarSolution.DAO;

namespace MediaBazaarSolution
{
    class StatisticsScreen
    {
        public SeriesCollection pieseriesCollection = new SeriesCollection();
        public SeriesCollection graphseriesCollection = new SeriesCollection();
        private List<String> categories = new List<String>();


        public StatisticsScreen()
        {
            /* Dummy Data for presentation Week 12
            SeriesCollection series = new SeriesCollection();
            string[] categoryNames = new string[6] { "Computer", "Home Appliances", "Television", "Camera", "Mobile", "Gaming" };
            int[] categoryNumbers = new int[6] { 50, 30, 57, 134, 264, 80 };
            for (int i = 0; i < 6; i++)
            {
                series.Add(new PieSeries() { Title = categoryNames[i], Values = new ChartValues<int> { categoryNumbers[i] }, DataLabels = true, LabelPoint = label });
            }
            SalesPieChart.Series = series;
            SalesPieChart.Text = "Category Sales";
            SalesPieChart.LegendLocation = LegendLocation.Right;

            SalesPieChart.Refresh();
            */
            


            UpdateGraphchart();
            UpdatePiechart();
        }


        public void UpdatePiechart()
        {
            // Updates the values for the categories
            categories.Clear();
            foreach (Item item in ItemDAO.Instance.LoadAllItems())
            {
                if (!categories.Contains(item.Category))
                {
                    categories.Add(item.Category);
                }
            }


            
        }

        public void UpdateGraphchart()
        {

        }

        // Dummy methods for statistics page
        Func<ChartPoint, string> label = chartpoint => String.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

        public string[] GetCategories()
        {
            UpdatePiechart();
            return categories.ToArray();
        }
    }
}
