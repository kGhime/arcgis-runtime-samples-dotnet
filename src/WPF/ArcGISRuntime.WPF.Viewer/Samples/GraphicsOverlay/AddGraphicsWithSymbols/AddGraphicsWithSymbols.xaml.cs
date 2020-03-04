// Copyright 2018 Esri.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at: http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific
// language governing permissions and limitations under the License.

using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using System.Drawing;

namespace ArcGISRuntime.WPF.Samples.AddGraphicsWithSymbols
{
    [ArcGISRuntime.Samples.Shared.Attributes.Sample(
        "Add graphics with symbols",
        "GraphicsOverlay",
        "This sample demonstrates how to add various types of graphics to a `GraphicsOverlay`.",
        "")]
    public partial class AddGraphicsWithSymbols
    {
        // Create the graphics overlay
        private readonly GraphicsOverlay _overlay = new GraphicsOverlay();

        public AddGraphicsWithSymbols()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            // Create the map
            Map myMap = new Map(Basemap.CreateOpenStreetMap());
            //Map myMap = new Map(BasemapType.Oceans, 34.0536200, -117.1836500, 14);
            //Map myMap = new Map(BasemapType.Oceans, 56.075844, -2.681572, 14);

            // Add the map to the map view
            MyMapView.Map = myMap;

            // Add the graphics overlay to the map view
            MyMapView.GraphicsOverlays.Add(_overlay);

            // Call functions to create the graphics
            CreatePoints();
            //CreatePolygon();
            //CreatePolyline();
            //CreateText();

            // Update the extent to encompass all of the symbols
            SetExtent();
        }

        private void CreatePoints()
        {
            // Create a red circle simple marker symbol
            SimpleMarkerSymbol redCircleSymbol = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Circle, Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), 10);

            // Create graphics and add them to graphics overlay

            //var text1 = new TextSymbol("AAAA", Color.FromArgb(255, 0, 0, 230), 20, Esri.ArcGISRuntime.Symbology.HorizontalAlignment.Left,
            //                     Esri.ArcGISRuntime.Symbology.VerticalAlignment.Bottom);
            //var text2 = new TextSymbol("BBBB", Color.FromArgb(255, 0, 0, 230), 20, Esri.ArcGISRuntime.Symbology.HorizontalAlignment.Left,
            //                     Esri.ArcGISRuntime.Symbology.VerticalAlignment.Bottom);
            //var text3 = new TextSymbol("CCCC", Color.FromArgb(255, 0, 0, 230), 20, Esri.ArcGISRuntime.Symbology.HorizontalAlignment.Left,
            //                     Esri.ArcGISRuntime.Symbology.VerticalAlignment.Bottom);
            //var text4 = new TextSymbol("DDDD", Color.FromArgb(255, 0, 0, 230), 20, Esri.ArcGISRuntime.Symbology.HorizontalAlignment.Left,
            //                     Esri.ArcGISRuntime.Symbology.VerticalAlignment.Bottom);
            //var text5 = new TextSymbol("EEEE", Color.FromArgb(255, 0, 0, 230), 20, Esri.ArcGISRuntime.Symbology.HorizontalAlignment.Left,
            //                     Esri.ArcGISRuntime.Symbology.VerticalAlignment.Bottom);


            
            Graphic graphic = new Graphic(new MapPoint(-117.1842782, 34.0535806, SpatialReferences.Wgs84), redCircleSymbol);
            _overlay.Graphics.Add(graphic);
            
            graphic = new Graphic(new MapPoint(-117.1839386, 34.0526897, SpatialReferences.Wgs84), redCircleSymbol);
            _overlay.Graphics.Add(graphic);

            graphic = new Graphic(new MapPoint(-117.1827502, 34.0529242, SpatialReferences.Wgs84), redCircleSymbol);
            _overlay.Graphics.Add(graphic);

            graphic = new Graphic(new MapPoint(-117.1822409, 34.0530648, SpatialReferences.Wgs84), redCircleSymbol);
            _overlay.Graphics.Add(graphic);

            graphic = new Graphic(new MapPoint(-117.1816750, 34.0529710, SpatialReferences.Wgs84), redCircleSymbol);
            _overlay.Graphics.Add(graphic);
        }

        private void CreatePolyline()
        {
            // Create a purple simple line symbol
            SimpleLineSymbol lineSymbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Dash, Color.FromArgb(0xFF, 0x80, 0x00, 0x80), 4);

            // Create a new point collection for polyline
            Esri.ArcGISRuntime.Geometry.PointCollection points = new Esri.ArcGISRuntime.Geometry.PointCollection(SpatialReferences.Wgs84)
            {
                // Create and add points to the point collection
                new MapPoint(-2.715, 56.061),
                new MapPoint(-2.6438, 56.079),
                new MapPoint(-2.638, 56.079),
                new MapPoint(-2.636, 56.078),
                new MapPoint(-2.636, 56.077),
                new MapPoint(-2.637, 56.076),
                new MapPoint(-2.715, 56.061)
            };

            // Create the polyline from the point collection
            Polyline polyline = new Polyline(points);

            // Create the graphic with polyline and symbol
            Graphic graphic = new Graphic(polyline, lineSymbol);

            // Add graphic to the graphics overlay
            _overlay.Graphics.Add(graphic);
        }

        private void CreatePolygon()
        {
            // Create a green simple line symbol
            SimpleLineSymbol outlineSymbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Dash, Color.FromArgb(0xFF, 0x00, 0x50, 0x00), 1);

            // Create a green mesh simple fill symbol
            SimpleFillSymbol fillSymbol = new SimpleFillSymbol(SimpleFillSymbolStyle.DiagonalCross, Color.FromArgb(0xFF, 0x00, 0x50, 0x00), outlineSymbol);

            // Create a new point collection for polygon
            Esri.ArcGISRuntime.Geometry.PointCollection points = new Esri.ArcGISRuntime.Geometry.PointCollection(SpatialReferences.Wgs84)
            {
                // Create and add points to the point collection
                new MapPoint(-2.6425, 56.0784),
                new MapPoint(-2.6430, 56.0763),
                new MapPoint(-2.6410, 56.0759),
                new MapPoint(-2.6380, 56.0765),
                new MapPoint(-2.6380, 56.0784),
                new MapPoint(-2.6410, 56.0786)
            };

            // Create the polyline from the point collection
            Polygon polygon = new Polygon(points);

            // Create the graphic with polyline and symbol
            Graphic graphic = new Graphic(polygon, fillSymbol);

            // Add graphic to the graphics overlay
            _overlay.Graphics.Add(graphic);
        }

        private void CreateText()
        {
            // Create two text symbols
            TextSymbol bassRockTextSymbol = new TextSymbol("Black Rock", Color.Blue, 10,
                Esri.ArcGISRuntime.Symbology.HorizontalAlignment.Left, Esri.ArcGISRuntime.Symbology.VerticalAlignment.Bottom);

            TextSymbol craigleithTextSymbol = new TextSymbol("Craigleith", Color.Blue, 10,
                Esri.ArcGISRuntime.Symbology.HorizontalAlignment.Right, Esri.ArcGISRuntime.Symbology.VerticalAlignment.Top);

            // Create two points
            MapPoint bassPoint = new MapPoint(-2.64, 56.079, SpatialReferences.Wgs84);
            MapPoint craigleithPoint = new MapPoint(-2.72, 56.076, SpatialReferences.Wgs84);

            // Create two graphics from the points and symbols
            Graphic bassRockGraphic = new Graphic(bassPoint, bassRockTextSymbol);
            Graphic craigleithGraphic = new Graphic(craigleithPoint, craigleithTextSymbol);

            // Add graphics to the graphics overlay
            _overlay.Graphics.Add(bassRockGraphic);
            _overlay.Graphics.Add(craigleithGraphic);
        }

        private void SetExtent()
        {
            // Get all of the graphics contained in the graphics overlay
            GraphicCollection myGraphicCollection = _overlay.Graphics;

            // Create a new envelope builder using the same spatial reference as the graphics
            //EnvelopeBuilder myEnvelopeBuilder = new EnvelopeBuilder(SpatialReferences.Wgs84);

            EnvelopeBuilder myEnvelopeBuilder = new EnvelopeBuilder(-117.208662237806, 34.0728534762229, -117.156880975828, 34.0321082319642, SpatialReferences.Wgs84);

            // Loop through each graphic in the graphic collection
            foreach (Graphic oneGraphic in myGraphicCollection)
            {
                // Union the extent of each graphic in the envelope builder
                myEnvelopeBuilder.UnionOf(oneGraphic.Geometry.Extent);
            }

            // Expand the envelope builder by 30%
            //myEnvelopeBuilder.Expand(1.3);

            // Adjust the viewable area of the map to encompass all of the graphics in the
            // graphics overlay plus an extra 30% margin for better viewing
            MyMapView.SetViewpointAsync(new Viewpoint(myEnvelopeBuilder.Extent));


            //Envelope initialLocation = new Envelope(
            //    4038588.66806427, -13047608.5968734, -13041844.3331573, 4033114.19246949,
            //    SpatialReferences.Wgs84);

            //MyMapView.SetViewpointAsync(new Viewpoint(initialLocation));
        }
    }
}