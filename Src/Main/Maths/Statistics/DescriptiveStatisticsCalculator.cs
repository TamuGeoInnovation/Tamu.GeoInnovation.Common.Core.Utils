using System;
using System.Collections.Generic;
using System.Data;
using USC.GISResearchLab.Common.Utils.Numbers;

namespace USC.GISResearchLab.Common.Core.Maths.Statistics
{
    public class DescriptiveStatisticsCalculator
    {

        #region Properties

        private bool _IsCalculated { get; set; }
        private List<double> _Values;
        private DataTable _StatisticsDataTable;

        private double _Minimum;
        public double Minimum { get { return GetStatistic("Minimum"); } }

        private double _Maximum;
        public double Maximum { get { return GetStatistic("Maximum"); } }

        private double _Sum;
        public double Sum { get { return GetStatistic("Sum"); } }

        private double _StdDev;
        public double StdDev { get { return GetStatistic("StdDev"); } }

        private double _Average;
        public double Average { get { return GetStatistic("Average"); } }

        private double _Variance;
        public double Variance { get { return GetStatistic("Variance"); } }

        private double _Count;
        public double Count { get { return GetStatistic("Count"); } }

        private double[] _QuartileValues;
        public double[] QuartileValues { get { return _QuartileValues; } }
        private double[] _QuartileCounts;
        public double[] QuartileCounts { get { return _QuartileCounts; } }

        #endregion


        public DescriptiveStatisticsCalculator()
        {
            _Values = new List<double>();
            _QuartileValues = new double[4];
            _QuartileCounts = new double[4];
        }

        public DescriptiveStatisticsCalculator(double[] values)
        {
            _Values = new List<double>(values);
            _QuartileValues = new double[4];
            _QuartileCounts = new double[4];
        }

        public void AddValue(double value)
        {

            _IsCalculated = false;
            _Values.Add(value);

        }

        public void AddValues(double[] values)
        {

            _IsCalculated = false;
            _Values.AddRange(values);

        }

        private double GetStatistic(string name)
        {

            double ret = 0;
            if (_IsCalculated)
            {
                ret = Convert.ToDouble(_StatisticsDataTable.Rows[0][name]);
            }
            else
            {
                throw new Exception("Statistics have not been calculated yet - call CalculateStatistics() ");
            }
            return ret;
        }



        public DataTable CalculateStatistics()
        {

            DataTable ret = null;

            if (_Values.Count > 0)
            {
                ret = new DataTable();
                ret.Columns.Add("Minimum", typeof(double));
                ret.Columns.Add("Maximum", typeof(double));
                ret.Columns.Add("Average", typeof(double));
                ret.Columns.Add("StdDev", typeof(double));
                ret.Columns.Add("Sum", typeof(double));
                ret.Columns.Add("Count", typeof(double));
                ret.Columns.Add("Variance", typeof(double));

                _Values.Sort();
                _Count = _Values.Count;
                _Minimum = _Values[0];
                _Maximum = _Values[_Values.Count - 1];

                for (int i = 0; i < _Values.Count; i++)
                {
                    _Sum += _Values[i];
                }

                _Average = _Sum / _Count;

                CalculateVariance();
                _StdDev = Math.Sqrt(_Variance);


                if (_Values.Count >= 4)
                {
                    CalculateQuartiles();
                    CalculateQuartileCounts();
                }


                DataRow row = ret.NewRow();
                row["Maximum"] = _Maximum;
                row["Minimum"] = _Minimum;
                row["Average"] = _Average;
                row["StdDev"] = _StdDev;
                row["Sum"] = _Sum;
                row["Count"] = _Count;
                row["Variance"] = _Variance;
                ret.Rows.Add(row);
            }

            _StatisticsDataTable = ret;
            _IsCalculated = true;

            return ret;
        }

        private void CalculateQuartiles()
        {
            int quartilePostitionQ1 = Convert.ToInt32(Math.Round(0.25 * _Count));
            int quartilePostitionQ3 = Convert.ToInt32(Math.Round(0.75 * _Count));

            QuartileValues[0] = _Values[quartilePostitionQ1];
            QuartileValues[2] = _Values[quartilePostitionQ3];
            QuartileValues[3] = _Maximum;

            if (NumberUtils.IsEven(_Count))
            {
                double nOver2 = _Values[(int)_Count / 2];
                double nOver2Plus1 = _Values[((int)_Count / 2) + 1];
                QuartileValues[1] = CalculateAverage(new double[] { nOver2, nOver2Plus1 });
            }
            else
            {
                double nPlus1Over2 = _Values[((int)_Count + 1) / 2];
                QuartileValues[1] = nPlus1Over2;
            }

        }

        private void CalculateQuartileCounts()
        {
            for (int i = 0; i < _Values.Count; i++)
            {
                if (_Values[i] <= QuartileValues[0])
                {
                    QuartileCounts[0]++;
                }
                else if (_Values[i] > QuartileValues[0] && _Values[i] <= QuartileValues[1])
                {
                    QuartileCounts[1]++;
                }
                else if (_Values[i] > QuartileValues[1] && _Values[i] <= QuartileValues[2])
                {
                    QuartileCounts[2]++;
                }
                else if (_Values[i] > QuartileValues[2] && _Values[i] <= QuartileValues[3])
                {
                    QuartileCounts[3]++;
                }
            }
        }

        private void CalculateVariance()
        {
            double runningSum = 0;

            for (int i = 0; i < _Values.Count; i++)
            {
                runningSum += Math.Pow((_Values[i] - _Average), 2);
            }

            _Variance = runningSum / _Values.Count;
        }

        public List<double> GetValues()
        {
            return _Values;
        }

        public override string ToString()
        {
            string output = "";
            output += " Minimum = " + _Minimum;
            output += ", Maximum = " + _Maximum;
            output += ", Average = " + _Average;
            output += ", StdDev = " + _StdDev;
            output += ", Sum = " + _Sum;
            output += ", Count = " + _Count;
            output += ", Variance = " + _Variance;
            return output;
        }

        public double[] ToDoubleArray()
        {
            return new double[] { _Minimum, _Maximum, _Average, _StdDev, _Sum, _Count, _Variance };
        }

        public double CalculateAverage(double[] values)
        {
            double ret = -1;
            double sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }

            ret = sum / values.Length;
            return ret;
        }
    }
}

