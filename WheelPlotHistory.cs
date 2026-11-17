using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Bounded per-band history, retaining the original Z values so existing
    /// points can be recolored/reclassified when chart settings change.
    /// </summary>
    internal sealed class WheelPlotHistory
    {
        private struct HistorySample
        {
            public readonly float X;
            public readonly float Y;
            public readonly float Z;
            public readonly long Order;

            public HistorySample(float x, float y, float z, long order)
            {
                X = x;
                Y = y;
                Z = z;
                Order = order;
            }
        }

        private readonly Queue<HistorySample>[] samplesByBand;
        private long nextOrder;
        private bool hasCurrentPoint;
        private float currentX;
        private float currentY;

        public int BandCount { get; }

        public WheelPlotHistory(int bandCount)
        {
            if (bandCount < 1) throw new ArgumentOutOfRangeException(nameof(bandCount));
            BandCount = bandCount;
            samplesByBand = new Queue<HistorySample>[bandCount + 1];
            for (int i = 1; i <= bandCount; i++)
                samplesByBand[i] = new Queue<HistorySample>();
        }

        public void Clear()
        {
            for (int band = 1; band < samplesByBand.Length; band++)
                samplesByBand[band].Clear();
            hasCurrentPoint = false;
        }

        /// <summary>
        /// Preserve and reclassify previously displayed points using the new
        /// range/band count; also reapply the history cap to each new bucket.
        /// This is called when rebuilding the chart, not on each sample.
        /// </summary>
        public WheelPlotHistory Rebucket(int newBandCount, float minimumZ,
                                          float maximumZ, int maxHistoryPoints)
        {
            var updated = new WheelPlotHistory(newBandCount)
            {
                nextOrder = this.nextOrder,
                hasCurrentPoint = this.hasCurrentPoint,
                currentX = this.currentX,
                currentY = this.currentY
            };

            var orderedSamples = samplesByBand.Skip(1)
                .SelectMany(band => band)
                .OrderBy(sample => sample.Order);

            foreach (HistorySample sample in orderedSamples)
                updated.AppendSample(sample, minimumZ, maximumZ, maxHistoryPoints);

            return updated;
        }

        private void AppendSample(HistorySample sample, float minimumZ,
                                  float maximumZ, int maxHistoryPoints)
        {
            if (maxHistoryPoints <= 0) return;

            int band = GradientPalette.GetBand(sample.Z, minimumZ, maximumZ, BandCount);
            Queue<HistorySample> history = samplesByBand[band];
            history.Enqueue(sample);
            while (history.Count > maxHistoryPoints)
                history.Dequeue();
        }

        public void BindAll(Chart chart, string seriesName, Color markerColor)
        {
            for (int band = 1; band <= BandCount; band++)
                BindBand(chart, seriesName, band);
            BindCurrent(chart, seriesName, markerColor);
        }

        private void BindBand(Chart chart, string seriesName, int band)
        {
            Queue<HistorySample> history = samplesByBand[band];
            // DataBindXY with deferred LINQ enumerables caused a
            // NotImplementedException in the WinForms chart control.
            // Populate the collection directly using the supported AddXY API.
            Series series = chart.Series[seriesName + GradientPalette.SeriesSuffix(band)];
            series.Points.Clear();
            foreach (HistorySample sample in history)
                series.Points.AddXY(sample.X, sample.Y);
        }

        private void BindCurrent(Chart chart, string seriesName, Color markerColor)
        {
            Series current = chart.Series[seriesName];
            current.Color = markerColor;
            current.MarkerColor = markerColor;
            current.Points.Clear();

            if (!hasCurrentPoint) return;

            int pointIndex = current.Points.AddXY(currentX, currentY);
            DataPoint point = current.Points[pointIndex];
            point.Color = markerColor;
            point.MarkerColor = markerColor;
            point.MarkerSize = 8;
            point.IsValueShownAsLabel = false;
        }

        public void Add(Chart chart, string seriesName, float x, float y, float z,
                        float minimumZ, float maximumZ, int maxHistoryPoints,
                        Color currentMarkerColor)
        {
            hasCurrentPoint = true;
            currentX = x;
            currentY = y;

            var sample = new HistorySample(x, y, z, nextOrder++);
            AppendSample(sample, minimumZ, maximumZ, maxHistoryPoints);

            BindCurrent(chart, seriesName, currentMarkerColor);
            int band = GradientPalette.GetBand(z, minimumZ, maximumZ, BandCount);
            Series historySeries = chart.Series[seriesName + GradientPalette.SeriesSuffix(band)];
            if (maxHistoryPoints > 0)
            {
                // An ordinary live update appends only one point. Keep the
                // visible collection in sync with the bounded history queue.
                historySeries.Points.AddXY(x, y);
                while (historySeries.Points.Count > samplesByBand[band].Count)
                    historySeries.Points.RemoveAt(0);
            }
            else
                historySeries.Points.Clear();
        }
    }
}
