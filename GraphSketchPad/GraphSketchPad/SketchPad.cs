using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphSketchPad
{
    public partial class frmSketchPad : Form
    {
        MouseState mouseStatus = MouseState.Select;
        MouseState previousMouseStatus = MouseState.Unknown;
        int vertexRadius = 10;
        int loopDiameter = 30;
        int edgeWidth = 2;
        int parallelOffset = 5;
        private Point dragOffset;
        private Point dragTrap;

        private myVertex activeVertex;
        private myVertex selectedVertex;
        private myEdge selectedEdge;
        private List<myVertex> myVertices = new List<myVertex>();
        private List<myEdge> myEdges = new List<myEdge>();
        private List<myEdge> drawnEdges = new List<myEdge>(); //keep a track of drawn edges for parallel lines
        private int vCounter = 0;
        private Stack<List<myEdge>> undoEdges = new Stack<List<myEdge>>();
        private Stack<List<myEdge>> redoEdges = new Stack<List<myEdge>>();
        private Stack<List<myVertex>> undoVertices = new Stack<List<myVertex>>();
        private Stack<List<myVertex>> redoVertices = new Stack<List<myVertex>>();


        public frmSketchPad()
        {
            InitializeComponent();
            updateMouseStatusText();
            btnBackToggle.BackColor = Color.White;
            btnBackToggle.ForeColor = Color.Black;
            pictureBox1.BackColor = btnBackToggle.BackColor;
            SaveState();
            cboDH_Type.Items.Clear();
            foreach (GraphType type in (GraphType[])Enum.GetValues(typeof(GraphType)))
            {
                cboDH_Type.Items.Add(type.ToString());
            }
            //Temp();
        }

        private void Temp()
        {
            List<double> myX = new List<double>();
            List<double> myY = new List<double>();

            myX.Add(-0.37);
            myX.Add(0);
            myX.Add(-0.6);
            myX.Add(0);
            myX.Add(0.6);
            myX.Add(0.37);
            myX.Add(0);

            myY.Add(-0.21);
            myY.Add(0.43);
            myY.Add(-0.35);
            myY.Add(0.69);
            myY.Add(-0.35);
            myY.Add(-0.21);
            myY.Add(0);

            for (int i = 0; i < 7; i++)
            {
                int pX = 250 + Convert.ToInt32(myX[i] * 250);
                int pY = 250 + Convert.ToInt32(myY[i] * 250);
                addNewVertex(new Point(pX, pY));
            }
            pictureBox1.Invalidate();
        }

        enum MouseState
        {
            Unknown,
            Select,
            DrawingVertex,
            DrawingEdge,
            Dragging,
            DrawHelper,
            StickyColor
        }

        enum GraphType
        {
            Circle_Cn,
            Complete_Kn,
            Disconnected_Vertices,
            Binary_Tree,
            Complete_Bipartite,
            Random
        }

        private void tstrDrawVertex_Click(object sender, EventArgs e)
        {
            activeVertex = null;
            if (mouseStatus == MouseState.DrawingVertex)
            {
                goToPreviousMouseStatus();
            }
            else
            {
                updateMouseStatus(MouseState.DrawingVertex);
            }
        }

        private void SketchPad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                updateMouseStatus(MouseState.Select);
            }
            else if (e.KeyCode == Keys.N)
            {
                chbVertexName.Checked = !chbVertexName.Checked;
                chbVertexName_CheckedChanged(sender, e);
            }
            else if(e.KeyCode == Keys.W)
            {
                chbWeights.Checked = !chbWeights.Checked;
                chbWeights_CheckedChanged(sender, e);
            }
            else if (e.KeyCode == Keys.D)
            {
                chbVertexDegree.Checked = !chbVertexDegree.Checked;
                chbVertexDegree_CheckedChanged(sender, e);
            }
            else if (e.KeyCode == Keys.E)
            {
                chbEdgeDirection.Checked = !chbEdgeDirection.Checked;
                chbEdgeDirection_CheckedChanged(sender, e);
            }
            else if(e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                DeleteSelectedItem();
            }
        }

        public void UpdateCount()
        {
            int n = myVertices.Count;
            int m = myEdges.Count;
            stsVertices.Text = "n = " + n;
            stsEdges.Text = "m = " + m;
            int nComp = NoOfComponents(myVertices, myEdges);
            stsGeneric.Text = "Components = " + nComp;
            StringBuilder sb = new StringBuilder();

            //Connectedness
            if (n == 0)
                sb.AppendLine("Graph is Empty");
            else if (n == 1)
                sb.AppendLine("Graph is Trivial");
            else if (nComp == 1)
                sb.AppendLine("Graph is Connected");
            else
                sb.AppendLine("Graph is Disconnected");

            //Bipartite
            if (isGraphBipartite())
                sb.AppendLine("Graph is Bipartitie");
            else
                sb.AppendLine("Graph is Not Bipartitie");


            lblChecks.Text = sb.ToString();

        }

        public void UpdateMatrices()
        {
            int n = myVertices.Count();
            int m = myEdges.Count();
            var M = Matrix<double>.Build;
            txtMatrices.Text = "";

            if (cboAdjacency.Checked & n != 0)
            {

                var Adjacency = M.Dense(n, n, 0);

                for (int i = 0; i < n; i++)
                {
                    for (int j = i; j < n; j++)
                    {
                        if (i == j)
                            continue;
                        myVertex v = myVertices[i];
                        myVertex u = myVertices[j];
                        int noOfE = myEdges.Count(x => (x.VertexA.Name == v.Name & x.VertexB.Name == u.Name || x.VertexA.Name == u.Name & x.VertexB.Name == v.Name));
                        Adjacency[i, j] = noOfE;
                        Adjacency[j, i] = noOfE;
                    }
                }
                txtMatrices.Text += "Adjacency Matrix: \r\n";
                txtMatrices.Text += Adjacency.ToMatrixString();
                txtMatrices.Text += "\r\n";
            }

            if (cboIncidence.Checked & m != 0 & n != 0)
            {
                var Incidence = M.Dense(n, m, 0);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (myEdges[j].VertexA.Name == myVertices[i].Name || myEdges[j].VertexB.Name == myVertices[i].Name)
                            Incidence[i, j] = 1;
                    }
                }

                txtMatrices.Text += "Incidence Matrix: \r\n";
                txtMatrices.Text += Incidence.ToMatrixString();
                txtMatrices.Text += "\r\n";
            }

            if (chbDegreeMatrix.Checked & n != 0)
            {
                var Degree = M.Dense(n, n, 0);
                for (int i = 0; i < n; i++)
                {
                    Degree[i, i] = getDegree(myVertices[i]);
                }

                txtMatrices.Text += "Degree Matrix: \r\n";
                txtMatrices.Text += Degree.ToMatrixString();
                txtMatrices.Text += "\r\n";
            }

            if (chbIdentityMatrix.Checked & n != 0)
            {
                var Identity = M.Dense(n, n, 0);
                for (int i = 0; i < n; i++)
                {
                    Identity[i, i] = 1;
                }

                txtMatrices.Text += "Identity Matrix: \r\n";
                txtMatrices.Text += Identity.ToMatrixString();
                txtMatrices.Text += "\r\n";
            }


            if ((chbIncidenceD.Checked || chbIncidenceTD.Checked || chbLaplacian.Checked || chbEigen.Checked) & m != 0 & n != 0)
            {
                var IncidenceD = M.Dense(n, m, 0);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (myEdges[j].VertexA.Name == myVertices[i].Name)
                            IncidenceD[i, j] = 1;
                        else if (myEdges[j].VertexB.Name == myVertices[i].Name)
                            IncidenceD[i, j] = -1;
                    }
                }

                if (chbIncidenceD.Checked)
                {
                    txtMatrices.Text += "Incidence Matrix (Directed): \r\n";
                    txtMatrices.Text += IncidenceD.ToMatrixString();
                    txtMatrices.Text += "\r\n";
                }
                if (chbIncidenceTD.Checked || chbLaplacian.Checked || chbEigen.Checked)
                {
                    var IncidenceTD = IncidenceD.Transpose();

                    if (chbIncidenceTD.Checked)
                    {
                        txtMatrices.Text += "Incidence Matrix (Directed) Transpose: \r\n";
                        txtMatrices.Text += IncidenceTD.ToMatrixString();
                        txtMatrices.Text += "\r\n";
                    }
                    Matrix<double> LPM = M.Dense(n, m, 0);
                    if (chbLaplacian.Checked || chbEigen.Checked)
                    {
                        LPM = IncidenceD * IncidenceTD;
                    }

                    if (chbLaplacian.Checked)
                    {
                        txtMatrices.Text += "Laplacian Matrix: \r\n";
                        txtMatrices.Text += LPM.ToMatrixString();
                        txtMatrices.Text += "\r\n";
                    }
                    if (chbEigen.Checked)
                    { 
                        var mEvd = LPM.Evd(Symmetricity.Symmetric);
                        txtMatrices.AppendText("Engenvalues:" + Environment.NewLine);

                        txtMatrices.AppendText(mEvd.EigenValues.ToRowMatrix().ToString());
                        txtMatrices.AppendText(Environment.NewLine);
                        txtMatrices.AppendText("Engenvectors:" + Environment.NewLine);
                        txtMatrices.AppendText(mEvd.EigenVectors.ToMatrixString());
                        

                    }
                }
            }
        }

        public class myVertex : ICloneable
        {
            public Point Point { get; set; }
            public float Radius { get; set; }
            public string Name { get; set; }
            public Color vColor { get; set; }
            public int ColorPart { get; set; }
            public myVertex(Point point, float radius, string name, Color vcolor)
            {
                Point = point;
                Radius = radius;
                Name = name;
                vColor = vcolor;
                ColorPart = 0;
            }

            public myVertex() { }

            public object Clone()
            {
                return new myVertex
                {
                    Point = this.Point,
                    Radius = this.Radius,
                    Name = this.Name,
                    vColor = this.vColor,
                    ColorPart = this.ColorPart
                };
            }
        }

        public class myEdge : ICloneable
        {
            public myVertex VertexA { get; set; }
            public myVertex VertexB { get; set; }
            public Point center { get; set; } //for loops
            public int Diameter { get; set; } //for loops
            public Color eColor { get; set; }
            public Point PointA { get; set; }
            public Point PointB { get; set; }
            public Point ArrowPoint { get; set; }
            public int Weight { get; set; }
            public myEdge(myVertex A, myVertex B, Color ecolor)
            {
                VertexA = A;
                VertexB = B;
                eColor = ecolor;
                Weight = 1;
            }

            public myEdge() { }

            public object Clone()
            {
                return new myEdge
                {
                    VertexA = (myVertex)this.VertexA.Clone(),
                    VertexB = (myVertex)this.VertexB.Clone(),
                    center = this.center,
                    Diameter = this.Diameter,
                    eColor = this.eColor,
                    PointA = this.PointA,
                    PointB = this.PointB,
                    Weight = this.Weight,
                    ArrowPoint = this.ArrowPoint
                };
            }

            public override string ToString()
            {
                return String.Format("{{{0}{1}}}", VertexA.Name, VertexB.Name);
            }
        }

        private myVertex CheckIfVertexClicked(Point point)
        {
            myVertex v = myVertices.FirstOrDefault(
                    vertex =>
                        Math.Abs(vertex.Point.X - point.X) < vertex.Radius &&
                        Math.Abs(vertex.Point.Y - point.Y) < vertex.Radius);
            if (chbSticky.Checked && v != null)
            {
                if (v.vColor != btnColor.BackColor)
                {
                    v.vColor = btnColor.BackColor;
                    SaveState();
                }
            }
            return v;
        }

        private myEdge CheckIfEdgeClicked(Point Pt)
        {
            myEdge e = null;
            foreach (var edge in myEdges)
            {
                if (edge.VertexA == edge.VertexB) //loops
                {
                    if (((Math.Abs(edge.center.X - Pt.X) < (edge.Diameter / 1)) && (Math.Abs(edge.center.Y - Pt.Y) < (edge.Diameter / 1))))
                        //&& !(Math.Abs(edge.center.X - Pt.X) < (edge.Diameter / 2 - edgeWidth) && Math.Abs(edge.center.Y - Pt.Y) < (edge.Diameter / 2 - edgeWidth)))
                    {
                        e = edge;
                    }
                }
                else //regular edges
                {
                    Point Start = edge.PointA;
                    Point End = edge.PointB;

                    //test if outside box of edge
                    if ((Pt.X < Start.X - 5 && Pt.X < End.X - 5) || (Pt.X > Start.X + 5 && Pt.X > End.X + 5) ||
                        (Pt.Y < Start.Y - 5 && Pt.Y < End.Y - 5) || (Pt.Y > Start.Y + 5 && Pt.Y > End.Y + 5))
                        continue; //skip to next one

                    //calc distance
                    float dy = End.Y - Start.Y;
                    float dx = End.X - Start.X;
                    float Z = dy * Pt.X - dx * Pt.Y + Start.Y * End.X - Start.X * End.Y;
                    float N = dy * dy + dx * dx;
                    float dist = (float)(Math.Abs(Z) / Math.Sqrt(N));
                    if (dist < edgeWidth * 3f)
                        e = edge;
                }
            }
            if (chbSticky.Checked && e != null)
            {
                if (e.eColor != btnColor.BackColor)
                {
                    e.eColor = btnColor.BackColor;
                    SaveState();
                }
            }

            btnContractEdge.Enabled = (e != null);
            btnChangeDirection.Enabled = (e != null && chbEdgeDirection.Checked);
            return e;
        }

        private Color WhiteToggler(Color mColor)
        {
            if (pictureBox1.BackColor == Color.White && mColor == Color.White)
                return Color.Black;
            else if (pictureBox1.BackColor == Color.Black && mColor == Color.Black)
                return Color.White;
            return mColor;
        }

        private bool updateEdgePoint(myEdge edge)
        {
            //check if this is the first edge occurence
            int edgeC = drawnEdges.Count(x => (x.VertexA.Name == edge.VertexA.Name && x.VertexB.Name == edge.VertexB.Name) ||
                                              (x.VertexB.Name == edge.VertexA.Name && x.VertexA.Name == edge.VertexB.Name));
            
            drawnEdges.Add(edge);

            if (edgeC == 0)
            {
                edge.PointA = myVertices.FirstOrDefault(x => x.Name == edge.VertexA.Name).Point;
                edge.PointB = myVertices.FirstOrDefault(x => x.Name == edge.VertexB.Name).Point;
            }
            else
            {
                if (chbSimple.Checked)
                {
                    return false;
                }
                else
                {
                    int multiplier = ((edgeC - 1) / 2) + 1;
                    //for uniform calculation - get first drawn edge's vertex points
                    myEdge origEdge = drawnEdges.First(x => (x.VertexA.Name == edge.VertexA.Name && x.VertexB.Name == edge.VertexB.Name) ||
                                                  (x.VertexB.Name == edge.VertexA.Name && x.VertexA.Name == edge.VertexB.Name));

                    Point PtA = origEdge.VertexA.Point;
                    Point PtB = origEdge.VertexB.Point;


                    int Ydiff = PtA.Y - PtB.Y;
                    int Xdiff = PtA.X - PtB.X;

                    double hypo = Math.Sqrt(Math.Pow(Ydiff, 2) + Math.Pow(Xdiff, 2));
                    double ang = Math.Atan2(Ydiff, Xdiff);
                    int Xoffset = Convert.ToInt32(Math.Sin(ang) * multiplier * parallelOffset);
                    int Yoffset = Convert.ToInt32(Math.Cos(ang) * multiplier * parallelOffset);
                    if (edgeC % 2 == 0) //even
                    {
                        PtA = new Point(PtA.X + Xoffset, PtA.Y - Yoffset);
                        PtB = new Point(PtB.X + Xoffset, PtB.Y - Yoffset);
                    }
                    else //odd
                    {
                        PtA = new Point(PtA.X - Xoffset, PtA.Y + Yoffset);
                        PtB = new Point(PtB.X - Xoffset, PtB.Y + Yoffset);
                    }
                    if (origEdge.VertexA.Name == edge.VertexA.Name)
                    {
                        edge.PointA = PtA;
                        edge.PointB = PtB;
                    }
                    else
                    {
                        edge.PointA = PtB;
                        edge.PointB = PtA;
                    }
                }
            }
            edge.ArrowPoint = new Point(edge.PointA.X + Convert.ToInt32((edge.PointB.X - edge.PointA.X) * 0.75), edge.PointA.Y + Convert.ToInt32((edge.PointB.Y - edge.PointA.Y) * 0.75));
            return true;
        }

        public void CheckVertexLocations()
        {
            foreach (var v in myVertices)
            {
                v.Point = new Point(Math.Min(Math.Max(0, v.Point.X), pictureBox1.Width), Math.Min(Math.Max(0, v.Point.Y), pictureBox1.Height));
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Graphics g = e.Graphics;
            g.Clear(pictureBox1.BackColor);

            CheckVertexLocations();

            List<myEdge> ToRemove = new List<myEdge>();

            //draw edges first so that vertices can stay on top of the edges
            drawnEdges.Clear();
            Pen edgePen = new Pen(Color.Black, edgeWidth);
            AdjustableArrowCap edgeArrow = new AdjustableArrowCap(6, 6);
            
            foreach (var edge in myEdges)
            {
                //updateEdgePoint(edge);
                edgePen.Color = WhiteToggler(edge.eColor);
                if (edge == selectedEdge)
                    edgePen.DashStyle = DashStyle.Dot;
                else
                    edgePen.DashStyle = DashStyle.Solid;

                if (edge.VertexA.Name == edge.VertexB.Name)
                {
                    if (chbSimple.Checked)
                    {
                        ToRemove.Add(edge);
                    }
                    else
                    {
                        UpdateLoopCenter(edge);
                        g.DrawEllipse(edgePen, edge.center.X, edge.center.Y, edge.Diameter, edge.Diameter);
                    }
                }
                else
                {
                    if (updateEdgePoint(edge)) //function checks if graph is simple
                    {
                        g.DrawLine(edgePen, edge.PointA, edge.PointB);
                        if (chbEdgeDirection.Checked)
                        {
                            edgePen.CustomEndCap = edgeArrow;
                            g.DrawLine(edgePen, edge.PointA, edge.ArrowPoint);
                        }
                    }
                    else
                    {
                        ToRemove.Add(edge);
                    }
                }
            }
            //Remove un-simple edges
            foreach (myEdge edge in ToRemove)
            {
                myEdges.Remove(edge);
            }
            if (ToRemove.Count() != 0)
                UpdateMatrices();


            //draw edge weights
            if (chbWeights.Checked)
            {
                Font eFont = new Font("Lucida Handwriting", 10);
                SolidBrush dbrush = new SolidBrush(WhiteToggler(Color.Black));
                foreach (var edge in myEdges)
                {
                    //find center of edge
                    Point pos = new Point(edge.PointB.X + ((edge.PointA.X - edge.PointB.X) / 2), edge.PointB.Y + ((edge.PointA.Y - edge.PointB.Y) / 2));
                    g.DrawString(edge.Weight.ToString(), eFont, dbrush, pos.X, pos.Y);
                }
            }


            // draw all vertices
            Pen vPen = new Pen(WhiteToggler(Color.Black), 4);
            SolidBrush vbrush = new SolidBrush(Color.Blue);
            foreach (var vertex in myVertices)
            {
                if (vertex == selectedVertex)
                {
                    vPen.DashStyle = DashStyle.Dot;
                    vPen.Width = 6;
                }
                else
                {
                    vPen.DashStyle = DashStyle.Solid;
                    vPen.Width = 4;
                }
                vbrush.Color = vertex.vColor;
                g.DrawEllipse(vPen, vertex.Point.X - vertex.Radius, vertex.Point.Y - vertex.Radius,
                    vertex.Radius * 2, vertex.Radius * 2);

                g.FillEllipse(vbrush, vertex.Point.X - vertex.Radius, vertex.Point.Y - vertex.Radius,
                    vertex.Radius * 2, vertex.Radius * 2);
            }


            Font tFont = new Font("Times New Roman", 10);
            // label the vertices
            if (chbVertexName.Checked)
            {
                SolidBrush tbrush = new SolidBrush(Color.Red); //get alternate of vertex color
                foreach (var vertex in myVertices)
                {
                    tbrush.Color = getAlternateColor(vertex.vColor);
                    float labelX;
                    int namelen = vertex.Name.Length;
                    if (namelen == 1)
                        labelX = vertex.Point.X - vertex.Radius + 4;
                    else if (namelen == 2)
                        labelX = vertex.Point.X - vertex.Radius + 2;
                    else
                        labelX = vertex.Point.X - vertex.Radius - 1;
                    g.DrawString(vertex.Name, tFont, tbrush, labelX, vertex.Point.Y - vertex.Radius + 4);
                }
            }

            //degree of the vertex
            if (chbVertexDegree.Checked)
            {
                SolidBrush dbrush = new SolidBrush(WhiteToggler(Color.Black));
                foreach (var vertex in myVertices)
                {
                    g.DrawString(getDegree(vertex).ToString(), tFont, dbrush, vertex.Point.X + vertex.Radius + 2, vertex.Point.Y - vertex.Radius - 4);
                }
            }

            //update undo/redo buttons
            tstUndo.Enabled = undoEdges.Count > 1;
            tstRedo.Enabled = redoEdges.Count > 0;
            //stsGeneric.Text = getGraphCenter().ToString();
            UpdateCount();
        }

        private void UpdateLoopCenter(myEdge edge)
        {
            //TODO: get approximate center of the graph and point loop away from center
            int edgeC = drawnEdges.Count(x => (x.VertexA.Name == edge.VertexA.Name && x.VertexB.Name == edge.VertexB.Name));

            if (edgeC == 0)
            {
                Point a = new Point
                {
                    X = (int)(edge.VertexA.Point.X - (2 * edge.VertexA.Radius)),
                    Y = edge.VertexA.Point.Y
                };
                edge.center = a;
                edge.Diameter = loopDiameter;
            }
            else
            {
                Point a = new Point
                {
                    X = (int)(edge.VertexA.Point.X - (2 * edge.VertexA.Radius)),
                    Y = edge.VertexA.Point.Y
                };
                edge.center = a;
                edge.Diameter = loopDiameter + (edgeC * parallelOffset);
            }

            drawnEdges.Add(edge);

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (mouseStatus == MouseState.DrawHelper)
            {
                DH_Draw(e.Location);
                goToPreviousMouseStatus();
                return;
            }
            selectedVertex = CheckIfVertexClicked(e.Location);
            if (selectedVertex != null)
            {
                pictureBox1.Invalidate();
            }
            if (selectedVertex == null)
            {
                //check for selected edge
                selectedEdge = CheckIfEdgeClicked(e.Location);
                if (selectedEdge != null)
                {
                    pictureBox1.Invalidate();
                }
            }
            if (selectedEdge == null && selectedVertex == null)
            {
                pictureBox1.Invalidate();
            }

            if (e.Button == MouseButtons.Right)
            {
                if (selectedVertex != null || selectedEdge != null)
                {
                    DeleteSelectedItem();
                }
                else
                {
                    updateMouseStatus(MouseState.Select);
                    chbSticky.Checked = false;
                }


            }

            switch (mouseStatus)
            {
                case MouseState.DrawingVertex:
                    addNewVertex(e.Location);
                    SaveState(); //for undo
                    pictureBox1.Invalidate();
                    break;
            }
        }

        public void DeleteSelectedItem()
        {
            if (selectedVertex != null)
            {
                //deleting the selected vertex
                DialogResult result = MessageBox.Show("Are you sure you want to delete vertex " + selectedVertex.Name + "?",
                    "Delete Vertex", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // remove edges
                    myEdges.RemoveAll(x => x.VertexA.Name == selectedVertex.Name);
                    myEdges.RemoveAll(x => x.VertexB.Name == selectedVertex.Name);
                    myVertices.RemoveAll(x => x.Name == selectedVertex.Name);
                    selectedVertex = null;
                    SaveState(); // for undo
                    pictureBox1.Invalidate();
                    UpdateMatrices();
                }
            }
            else if (selectedEdge != null)
            {
                //deleting the selected vertex
                string edgeOrLoop = "Edge ";
                if (selectedEdge.VertexA.Name == selectedEdge.VertexB.Name)
                    edgeOrLoop = "Loop ";
                DialogResult result = MessageBox.Show("Are you sure you want to delete " + edgeOrLoop + selectedEdge.ToString() + "?",
                    "Delete " + edgeOrLoop, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // remove edges
                    myEdges.RemoveAll(x => x == selectedEdge);
                    selectedEdge = null;
                    SaveState(); //for undo
                    pictureBox1.Invalidate();
                    UpdateMatrices();
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dragTrap = e.Location;
            if (mouseStatus == MouseState.DrawHelper)
                return;

            activeVertex = CheckIfVertexClicked(e.Location);
            if (activeVertex == null)
                return;
            else
            {
                if (mouseStatus != MouseState.DrawingEdge) //every other status should still drag
                {
                    updateMouseStatus(MouseState.Dragging);
                    dragOffset = new Point(activeVertex.Point.X - e.Location.X, activeVertex.Point.Y - e.Location.Y);
                }

            }
        }

        private void updateMouseStatus(MouseState status)
        {
            previousMouseStatus = mouseStatus;
            mouseStatus = status;
            updateMouseStatusText();

        }

        private void updateMouseStatusText()
        {
            switch (mouseStatus)
            {
                case MouseState.Select:
                    stsMouse.Text = "Idle";
                    break;
                case MouseState.DrawingVertex:
                    stsMouse.Text = "Drawing Vertex...";
                    break;
                case MouseState.DrawingEdge:
                    stsMouse.Text = "Drawing Edges...";
                    break;
                case MouseState.Dragging:
                    stsMouse.Text = "Moving Vertex...";
                    break;
                case MouseState.DrawHelper:
                    stsMouse.Text = "Click anywhere to draw the graph...";
                    break;
            }
            if (mouseStatus == MouseState.DrawHelper)
            {
                pictureBox1.Cursor = Cursors.Cross;
            }
            else
            {
                pictureBox1.Cursor = Cursors.Default;
            }
        }

        private void goToPreviousMouseStatus()
        {
            if (previousMouseStatus != MouseState.Unknown)
            {
                mouseStatus = previousMouseStatus;
                updateMouseStatusText();
                previousMouseStatus = MouseState.Unknown;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseStatus == MouseState.Dragging)
            {
                //cannot drag outside the picture box
                int Y = Math.Max(0, e.Location.Y);
                int X = Math.Max(0, e.Location.X);
                Y = Math.Min(Y, pictureBox1.Height);
                X = Math.Min(X, pictureBox1.Width);
                //update point
                activeVertex.Point = new Point(X + dragOffset.X, Y + dragOffset.Y);
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseStatus == MouseState.Dragging)
            {
                //activeVertex.Point = new Point(e.Location.X + dragOffset.X, e.Location.Y + dragOffset.Y);
                goToPreviousMouseStatus();
                if (dragTrap != e.Location)
                    SaveState(); //for undo
            }
            else if (mouseStatus == MouseState.DrawingEdge)
            {
                myVertex vertexA = activeVertex;
                myVertex vertexB = CheckIfVertexClicked(e.Location);
                if (vertexA == null || vertexB == null)
                    return;
                addNewEdge(vertexA, vertexB);
                //myEdges.Add(new myEdge(vertexA, vertexB, btnColor.BackColor));
                activeVertex = null;
                SaveState();
                pictureBox1.Invalidate();
            }
        }

        private void tstrDrawEdge_Click(object sender, EventArgs e)
        {
            activeVertex = null;
            if (mouseStatus == MouseState.DrawingEdge)
            {
                goToPreviousMouseStatus();
            }
            else
            {
                updateMouseStatus(MouseState.DrawingEdge);
            }
        }

        private void btnVertexColor_Click(object sender, EventArgs e)
        {
            UpdateSelectedColor(btnColor.BackColor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateSelectedColor(btnColor1.BackColor);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateSelectedColor(btnColor2.BackColor);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateSelectedColor(btnColor3.BackColor);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateSelectedColor(btnColor4.BackColor);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateSelectedColor(btnColor6.BackColor);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UpdateSelectedColor(btnColor7.BackColor);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UpdateSelectedColor(btnColor8.BackColor);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateSelectedColor(btnColor9.BackColor);
        }

        private void UpdateSelectedColor(Color mColor)
        {
            btnColor.BackColor = mColor;
            if (selectedVertex != null)
            {
                selectedVertex.vColor = mColor;
                SaveState();
                pictureBox1.Invalidate();
            }
            if (selectedEdge != null)
            {
                selectedEdge.eColor = mColor;
                SaveState();
                pictureBox1.Invalidate();
            }
        }

        private void btnBackToggle_Click(object sender, EventArgs e)
        {
            if (btnBackToggle.BackColor == Color.White)
            {
                btnBackToggle.BackColor = Color.Black;
                btnBackToggle.ForeColor = Color.White;
            }
            else
            {
                btnBackToggle.BackColor = Color.White;
                btnBackToggle.ForeColor = Color.Black;
            }
            pictureBox1.BackColor = btnBackToggle.BackColor;
            pictureBox1.Invalidate();
        }

        private void lnkCustom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog1.Color;
            }
        }


        private void SaveState()
        {
            redoEdges.Clear();
            redoVertices.Clear();

            List<myEdge> ee = new List<myEdge>();
            myEdges.ForEach(delegate (myEdge e)
            {
                ee.Add((myEdge)e.Clone());
            });
            undoEdges.Push(ee);


            List<myVertex> vv = new List<myVertex>();
            myVertices.ForEach(delegate (myVertex v)
            {
                vv.Add((myVertex)v.Clone());
            });
            undoVertices.Push(vv);
        }

        private void UndoForm()
        {
            if (undoEdges.Count > 0)
            {

                //save current state into redo
                List<myEdge> ee = new List<myEdge>();
                myEdges.ForEach(delegate (myEdge e)
                {
                    ee.Add((myEdge)e.Clone());
                });
                redoEdges.Push(ee);


                List<myVertex> vv = new List<myVertex>();
                myVertices.ForEach(delegate (myVertex v)
                {
                    vv.Add((myVertex)v.Clone());
                });
                redoVertices.Push(vv);

                //pop last state
                undoEdges.Pop();
                undoVertices.Pop();
                //peek into new state
                ee = new List<myEdge>();
                List<myEdge> eOld = undoEdges.Peek();
                eOld.ForEach(delegate (myEdge e)
                {
                    ee.Add((myEdge)e.Clone());
                });
                myEdges = ee;


                vv = new List<myVertex>();
                List<myVertex> vOld = undoVertices.Peek();
                vOld.ForEach(delegate (myVertex v)
                {
                    vv.Add((myVertex)v.Clone());
                });
                myVertices = vv;

                //redraw
                pictureBox1.Invalidate();
            }
            UpdateMatrices();
        }

        private void RedoForm()
        {
            if (redoEdges.Count > 0)
            {
                //pop redo state
                myEdges = redoEdges.Pop();
                myVertices = redoVertices.Pop();

                //save current state into undo
                List<myEdge> ee = new List<myEdge>();
                myEdges.ForEach(delegate (myEdge e)
                {
                    ee.Add((myEdge)e.Clone());
                });
                undoEdges.Push(ee);


                List<myVertex> vv = new List<myVertex>();
                myVertices.ForEach(delegate (myVertex v)
                {
                    vv.Add((myVertex)v.Clone());
                });
                undoVertices.Push(vv);


                //redraw
                pictureBox1.Invalidate();
                UpdateMatrices();
            }
        }

        private void tstUndo_Click(object sender, EventArgs e)
        {
            UndoForm();
        }

        private void tstRedo_Click(object sender, EventArgs e)
        {
            RedoForm();
        }

        private Color getAlternateColor(Color color)
        {
            return Color.FromArgb(color.ToArgb() ^ 0xffffff);
        }

        private Point getGraphCenter()
        {
            int cc = myVertices.Count();
            if (cc == 0)
            {
                return new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            }
            else
            {
                int X = 0; int Y = 0;
                foreach (var v in myVertices)
                {
                    X += v.Point.X;
                    Y += v.Point.Y;
                }
                X /= cc;
                Y /= cc;
                return new Point(X, Y);
            }
        }

        private int getDegree(myVertex vertex)
        {
            return myEdges.Count(x => x.VertexA.Name == vertex.Name || x.VertexB.Name == vertex.Name);
        }

        private void chbVertexName_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void chbVertexDegree_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void btnDeleteEdges_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete all edges?",
                        "Delete All Edges", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // remove edges
                myEdges.Clear();
                SaveState(); // for undo
                pictureBox1.Invalidate();
                UpdateMatrices();
            }
        }

        private void btnDeleteVertices_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear the graph?",
                        "Clear Graph", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // remove edges
                myEdges.Clear();
                myVertices.Clear();
                SaveState(); // for undo
                pictureBox1.Invalidate();
                UpdateMatrices();
            }
        }

        private void btnDeleteLoops_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear all loops?",
                        "Clear Loops", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // remove edges
                myEdges.RemoveAll(x => x.VertexB.Name == x.VertexA.Name);
                SaveState(); // for undo
                pictureBox1.Invalidate();
            }
        }

        private int NoOfComponents(List<myVertex> Vertices, List<myEdge> Edges)
        {
            List<myVertex> visited = new List<myVertex>();
            int myComp = 0;

            foreach (var v in Vertices)
            {
                if (visited.Count(x => x.Name == v.Name) == 0) // not visited yet
                {
                    visited.Add(v);
                    myComp += 1;
                    DFS(v, visited, Edges);
                }
            }
            return myComp;
        }

        private void DFS(myVertex v, List<myVertex> visited, List<myEdge> Edges)
        {
            myVertex u;

            foreach (var edge in Edges.Where(x => (x.VertexA.Name == v.Name || x.VertexB.Name == v.Name) && (x.VertexA.Name != x.VertexB.Name)))
            {
                if (edge.VertexA.Name == v.Name)
                    u = edge.VertexB;
                else
                    u = edge.VertexA;
                if (visited.Count(y => y.Name == u.Name) == 0) //not visited
                {
                    visited.Add(u);
                    DFS(u, visited, Edges);
                }
            }
        }

        private bool IsEdgeABridge(myEdge edge)
        {
            int aComp = NoOfComponents(myVertices, myEdges);

            //get a copy
            List<myEdge> ee = new List<myEdge>();
            myEdges.ForEach(delegate (myEdge e)
            {
                if (!(e.VertexA.Name == edge.VertexA.Name && e.VertexB.Name == edge.VertexB.Name))
                    ee.Add((myEdge)e.Clone());
            });

            int bComp = NoOfComponents(myVertices, ee);

            return (bComp > aComp);
        }

        private void btnShowBridges_Click(object sender, EventArgs e)
        {
            bool foundBridge = false;
            SaveState();
            foreach (var edge in myEdges.Where(x => x.VertexA.Name != x.VertexB.Name)) //no loops
            {
                if (IsEdgeABridge(edge))
                {
                    edge.eColor = Color.Red;
                    foundBridge = true;
                }
                else
                    edge.eColor = Color.Black;
            }
            if (!foundBridge)
            {
                MessageBox.Show("No Bridges found", "No Brigdes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            pictureBox1.Invalidate();
        }

        private bool updateBipartite(myVertex v, List<myVertex> visited, List<myVertex> PartX, List<myVertex> PartY)
        {
            bool vinVisited = (visited.Count(x => x.Name == v.Name) != 0);
            if (vinVisited)
                return true;

            bool vinX = (PartX.Count(x => x.Name == v.Name) != 0);
            bool vinY = (PartY.Count(x => x.Name == v.Name) != 0);

            visited.Add(v);
            if (!vinX && !vinY)
            {
                PartX.Add(v);
                vinX = true;
            }

            foreach (var edge in myEdges.Where(x => (x.VertexA.Name == v.Name || x.VertexB.Name == v.Name)))
            {
                if (edge.VertexA.Name == edge.VertexB.Name)
                    return false;

                myVertex u;
                if (edge.VertexA.Name == v.Name)
                    u = edge.VertexB;
                else
                    u = edge.VertexA;
                bool uinX = (PartX.Count(x => x.Name == u.Name) != 0);
                bool uinY = (PartY.Count(x => x.Name == u.Name) != 0);

                if (vinX)
                {
                    if (uinX) // exception
                        return false;
                    if (!uinY)
                        PartY.Add(u);
                }
                else if (vinY)
                {
                    if (uinY) // exception
                        return false;
                    if (!uinX)
                        PartX.Add(u);
                }

                if (updateBipartite(u, visited, PartX, PartY) == false)
                    return false;
            }
            return true;
        }
        private bool isGraphBipartite()
        {
            if (myVertices.Count() == 0)
                return false;

            List<myVertex> PartX = new List<myVertex>();
            List<myVertex> PartY = new List<myVertex>();
            List<myVertex> visited = new List<myVertex>();

            foreach (myVertex v in myVertices)
            {
                if (updateBipartite(v, visited, PartX, PartY) == false)
                    return false;
            }
            return true;
        }

        private void cboDH_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDHn.Text = "N:";
            lblDHN2.Visible = false;
            cboDH_N2.Visible = false;
            cboDH_N.Text = "";
            cboDH_N2.Text = "";
            lblDHn.Visible = true;
            cboDH_N.Visible = true;
            chbDH_Opt1.Visible = false;
            chbDH_K2.Visible = true;
            lblDHN3.Visible = false;
            cboDH_N3.Visible = false;

            if (cboDH_Type.Text == GraphType.Circle_Cn.ToString())
            {
                cboDH_N.Items.Clear();
                for (int i = 3; i < 16; i++)
                {
                    cboDH_N.Items.Add(i);
                }
            }
            else if (cboDH_Type.Text == GraphType.Complete_Kn.ToString())
            {
                cboDH_N.Items.Clear();
                for (int i = 2; i < 16; i++)
                {
                    cboDH_N.Items.Add(i);
                }
            }
            else if (cboDH_Type.Text == GraphType.Disconnected_Vertices.ToString())
            {
                cboDH_N.Items.Clear();
                for (int i = 2; i < 31; i++)
                {
                    cboDH_N.Items.Add(i);
                }
            }
            else if (cboDH_Type.Text == GraphType.Binary_Tree.ToString())
            {
                lblDHn.Text = "Levels:";
                cboDH_N.Items.Clear();
                for (int i = 1; i < 5; i++)
                {
                    cboDH_N.Items.Add(i);
                }
            }
            else if (cboDH_Type.Text == GraphType.Complete_Bipartite.ToString())
            {
                lblDHn.Text = "Part X:";
                lblDHN2.Text = "Part Y:";
                lblDHN2.Visible = true;
                cboDH_N2.Visible = true;
                cboDH_N.Items.Clear();
                cboDH_N2.Items.Clear();
                chbDH_Opt1.Visible = true;
                chbDH_Opt1.Checked = false;
                chbDH_Opt1.Text = "2-Color";
                for (int i = 2; i < 10; i++)
                {
                    cboDH_N.Items.Add(i);
                    cboDH_N2.Items.Add(i);
                }
                cboDH_N2.SelectedIndex = 0;
            }
            else if (cboDH_Type.Text == GraphType.Random.ToString())
            {
                chbDH_K2.Visible = false;
                chbDH_K2.Checked = false;
                lblDHn.Text = "N:";
                lblDHN2.Text = "Randomness:";
                lblDHN3.Text = "Parallel Lines Randomness:";
                lblDHN2.Visible = true;
                lblDHN3.Visible = true;
                cboDH_N2.Visible = true;
                cboDH_N3.Visible = true;
                cboDH_N.Items.Clear();
                cboDH_N2.Items.Clear();
                cboDH_N3.Items.Clear();
                cboDH_N.Items.Add("Random");
                for (int i = 1; i < 21; i++)
                {
                    cboDH_N.Items.Add(i);
                }
                for (int i = 1; i < 10; i++)
                {
                    cboDH_N2.Items.Add(i);
                    cboDH_N3.Items.Add(i);
                }
                cboDH_N2.SelectedIndex = 0;
                cboDH_N3.SelectedIndex = 0;
            }
            cboDH_N.SelectedIndex = 0;
        }



        private void btnDH_Draw_Click(object sender, EventArgs e)
        {
            if (cboDH_Type.Text == "")
            {
                MessageBox.Show("Please select type", "Error: Draw Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboDH_Type.Focus();
                return;
            }
            if (cboDH_N.Text == "")
            {
                MessageBox.Show("Please select number", "Error: Draw Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboDH_N.Focus();
                return;
            }
            if (cboDH_N2.Text == "" && cboDH_Type.Text == GraphType.Complete_Bipartite.ToString())
            {
                MessageBox.Show("Please select number", "Error: Draw Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboDH_N2.Focus();
                return;
            }
            updateMouseStatus(MouseState.DrawHelper);
        }

        private myVertex addNewVertex(Point Location, Color? vColor = null)
        {
            myVertex v = new myVertex(Location, vertexRadius, "" + vCounter++, vColor.GetValueOrDefault(btnColor.BackColor));
            myVertices.Add(v);
            UpdateMatrices();
            return v;
        }

        private myEdge addNewEdge(myVertex A, myVertex B, Color? eColor = null)
        {
            myEdge e = new myEdge(A, B, eColor.GetValueOrDefault(btnColor.BackColor));
            myEdges.Add(e);
            UpdateMatrices();
            return e;
        }

        private List<myVertex> GenerateDH_Graph(Point Location)
        {
            List<myVertex> ans = new List<myVertex>();

            if (cboDH_Type.Text == GraphType.Circle_Cn.ToString())
            {
                int N = Convert.ToInt32(cboDH_N.Text);
                int spaceRadius = -50 + (25 * N);

                myVertex first = null; myVertex previous = null;

                for (int i = 0; i < 360; i += (360 / N))
                {
                    if (360 - i < N)
                        continue; //uneven divisions create an extra vertex

                    double ang = i * Math.PI / 180;
                    int Xoffset = Convert.ToInt32(Math.Sin(ang) * spaceRadius) + Location.X;
                    int Yoffset = Convert.ToInt32(Math.Cos(ang) * spaceRadius) + Location.Y;
                    int X = Math.Min(Math.Max(0, Xoffset), pictureBox1.Width);
                    int Y = Math.Min(Math.Max(0, Yoffset), pictureBox1.Height);
                    myVertex v = addNewVertex(new Point(X, Y));
                    ans.Add(v);
                    if (first == null)
                        first = v;
                    if (previous == null)
                    {
                        previous = v;
                    }
                    else
                    {
                        addNewEdge(previous, v);
                        previous = v;
                    }
                }
                addNewEdge(previous, first);
            }
            else if (cboDH_Type.Text == GraphType.Complete_Kn.ToString())
            {
                int N = Convert.ToInt32(cboDH_N.Text);
                int spaceRadius = -50 + (25 * N);
                if (N == 2)
                    spaceRadius = 25;

                List<myVertex> vList = new List<myVertex>();

                for (int i = 0; i < 360; i += (360 / N))
                {
                    if (360 - i < N)
                        continue; //uneven divisions create an extra vertex

                    double ang = i * Math.PI / 180;
                    int Xoffset = Convert.ToInt32(Math.Sin(ang) * spaceRadius) + Location.X;
                    int Yoffset = Convert.ToInt32(Math.Cos(ang) * spaceRadius) + Location.Y;
                    int X = Math.Min(Math.Max(0, Xoffset), pictureBox1.Width);
                    int Y = Math.Min(Math.Max(0, Yoffset), pictureBox1.Height);
                    myVertex v = addNewVertex(new Point(X, Y));
                    ans.Add(v);
                    vList.Add(v);
                }

                //add the edges
                for (int i = 0; i < vList.Count() - 1; i++)
                {
                    for (int j = i + 1; j < vList.Count(); j++)
                    {
                        addNewEdge(vList[i], vList[j]);
                    }
                }

            }
            else if (cboDH_Type.Text == GraphType.Disconnected_Vertices.ToString())
            {
                int N = Convert.ToInt32(cboDH_N.Text);
                for (int i = 0; i < N; i++)
                {
                    int X = Location.X + (50 * (i % 3));
                    int Y = Location.Y + (50 * (i / 3));


                    //int X = rand.Next(5, pictureBox1.Width - 5);
                    //int Y = rand.Next(5, pictureBox1.Height - 5);
                    myVertex v = addNewVertex(new Point(X, Y));
                    ans.Add(v);
                }
            }
            else if (cboDH_Type.Text == GraphType.Binary_Tree.ToString())
            {
                int Level = Convert.ToInt32(cboDH_N.Text);
                myVertex r = addNewVertex(Location);
                ans.Add(r);
                for (int i = 0; i < 2; i++)
                { //Level 1
                    int Xoffset = 20 * Convert.ToInt32(Math.Pow(2, (Level - 1)));
                    int l1X = (i == 1) ? r.Point.X - Xoffset : r.Point.X + Xoffset;
                    myVertex l1 = addNewVertex(new Point(l1X, r.Point.Y + 60));
                    ans.Add(l1);
                    addNewEdge(r, l1);
                    if (Level > 1)
                    { //Level 2
                        for (int j = 0; j < 2; j++)
                        {
                            Xoffset = 20 * Convert.ToInt32(Math.Pow(2, (Level - 2)));
                            l1X = (j == 1) ? l1.Point.X - Xoffset : l1.Point.X + Xoffset;
                            myVertex l2 = addNewVertex(new Point(l1X, l1.Point.Y + 60));
                            ans.Add(l2);
                            addNewEdge(l1, l2);
                            if (Level > 2)
                            { // Level 3
                                for (int k = 0; k < 2; k++)
                                {
                                    Xoffset = 20 * Convert.ToInt32(Math.Pow(2, (Level - 3)));
                                    l1X = (k == 1) ? l2.Point.X - Xoffset : l2.Point.X + Xoffset;
                                    myVertex l3 = addNewVertex(new Point(l1X, l2.Point.Y + 60));
                                    ans.Add(l3);
                                    addNewEdge(l2, l3);
                                    if (Level > 3)
                                    { // Level 4
                                        for (int l = 0; l < 2; l++)
                                        {
                                            Xoffset = 20 * Convert.ToInt32(Math.Pow(2, (Level - 4)));
                                            l1X = (l == 1) ? l3.Point.X - Xoffset : l3.Point.X + Xoffset;
                                            myVertex l4 = addNewVertex(new Point(l1X, l3.Point.Y + 60));
                                            ans.Add(l4);
                                            addNewEdge(l3, l4);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (cboDH_Type.Text == GraphType.Complete_Bipartite.ToString())
            {
                int Nx = Convert.ToInt32(cboDH_N.Text);
                int Ny = Convert.ToInt32(cboDH_N2.Text);
                List<myVertex> PartX = new List<myVertex>();
                int offset = 10 * (Nx + Ny);
                for (int i = 0; i < Nx; i++)
                {
                    myVertex v = addNewVertex(new Point(Location.X, Location.Y + (i * 60)), (chbDH_Opt1.Checked) ? btnColor1.BackColor : btnColor.BackColor);
                    ans.Add(v);
                    PartX.Add(v);
                }
                for (int i = 0; i < Ny; i++)
                {
                    myVertex v2 = addNewVertex(new Point(Location.X + offset, Location.Y + (i * 60)), (chbDH_Opt1.Checked) ? btnColor2.BackColor : btnColor.BackColor);
                    ans.Add(v2);
                    //add edge to all of PartX
                    foreach (myVertex vX in PartX)
                    {
                        addNewEdge(v2, vX, (chbDH_Opt1.Checked) ? btnColor3.BackColor : btnColor.BackColor);
                    }
                }
            }
            else if (cboDH_Type.Text == GraphType.Random.ToString())
            {
                var rand = new Random();
                int N = 0;
                int R = Convert.ToInt32(cboDH_N2.Text);
                if (cboDH_N.Text == "Random")
                    N = rand.Next(4, 20);
                else
                    N = Convert.ToInt32(cboDH_N.Text);

                //generate random locations
                List<myVertex> RandVs = new List<myVertex>();
                for (int i = 0; i < N; i++)
                {
                    myVertex v = addNewVertex(new Point(rand.Next(100, pictureBox1.Width-100), rand.Next(100,pictureBox1.Height-100)));
                    RandVs.Add(v);
                }

                //generate random edges
                for(int i = 0; i < N; i++)
                {
                    myVertex myV = RandVs[i];
                    for(int j = i+1; j < N; j++)
                    {
                        // no of edges randomness
                        for (int k = 0; k < Convert.ToInt32(rand.Next(0, Convert.ToInt32(cboDH_N3.Text)))+1; k++)
                        {
                            myVertex myU = RandVs[j];
                            if (rand.Next() % R == 0)
                            {
                                if (rand.Next() % 2 == 0)
                                    addNewEdge(myV, myU);
                                else
                                    addNewEdge(myU, myV);
                            }
                        }
                    }
                }

            }
            return ans;
        }

        private void DH_Draw(Point Location)
        {
            List<myVertex> K1 = new List<myVertex>();
            List<myVertex> K2 = new List<myVertex>();

            K1 = GenerateDH_Graph(Location);
            if (chbDH_K2.Checked)
            {
                K2 = GenerateDH_Graph(new Point(Location.X + 100, Location.Y - 75));
                for (int i = 0; i < K1.Count; i++)
                {
                    addNewEdge(K1[i], K2[i]);
                }
            }
            SaveState();
            pictureBox1.Invalidate();
            UpdateMatrices();
        }

        private void btnContractEdge_Click(object sender, EventArgs e)
        {
            myEdge ee = selectedEdge;
            //move vertex A to midpoint
            ee.VertexA.Point = new Point((ee.VertexA.Point.X + ee.VertexB.Point.X) / 2, (ee.VertexA.Point.Y + ee.VertexB.Point.Y) / 2);
            //every vertex on B (that is not ee), move to A
            foreach (myEdge edge in myEdges)
            {
                if (edge == selectedEdge)
                    continue;
                if (edge.VertexA.Name == ee.VertexB.Name)
                {
                    edge.VertexA = ee.VertexA;
                }
                else if (edge.VertexB.Name == ee.VertexB.Name)
                {
                    edge.VertexB = ee.VertexA;
                }
            }
            // delete the edge and vertexB
            myEdges.RemoveAll(x => x.VertexA.Name == ee.VertexB.Name);
            myEdges.RemoveAll(x => x.VertexB.Name == ee.VertexB.Name);
            myVertices.RemoveAll(x => x.Name == ee.VertexB.Name);
            myEdges.RemoveAll(x => x == ee);
            selectedEdge = null;
            SaveState();
            pictureBox1.Invalidate();
            UpdateMatrices();
            UpdateMatrices();

        }

        private void btnColorGraph_Click(object sender, EventArgs e)
        {
            int gColors = 0;
            if (rdbGC1.Checked)
                gColors = 1;
            else if (rdbGC2.Checked)
                gColors = 2;
            else if (rdbGC3.Checked)
                gColors = 3;
            else if (rdbGC4.Checked)
                gColors = 4;
            else if (rdbGC5.Checked)
                gColors = 5;
            else if (rdbGC6.Checked)
                gColors = 6;
            else if (rdbGC7.Checked)
                gColors = 7;
            else if (rdbGC8.Checked)
                gColors = 8;
            else if (rdbGC9.Checked)
                gColors = 9;
            else if (rdbGC0.Checked)
                gColors = 10;

            if (gColors == 0)
            {
                MessageBox.Show("Please select number of colors...", "Error: Color Graph", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Define Graph Parts
            List<List<myVertex>> ColorParts = new List<List<myVertex>>(gColors);
            List<myVertex> visited = new List<myVertex>();
            for (int i = 0; i < gColors; i++)
            {
                ColorParts.Add(new List<myVertex>());
            }
            foreach (myVertex v in myVertices)
                v.ColorPart = 0; // reset all colors first

            foreach (myVertex v in myVertices)
            {
                if (SortIntoColorPart(v, visited, gColors) == false) // will return false if not colorable
                {
                    MessageBox.Show("Graph is not " + gColors + "-color colorable.");
                    return;
                }
            }
            // do the actual coloring
            foreach (myVertex v in myVertices)
            {
                if (v.ColorPart == 1)
                    v.vColor = btnColor1.BackColor;
                else if (v.ColorPart == 2)
                    v.vColor = btnColor2.BackColor;
                else if (v.ColorPart == 3)
                    v.vColor = btnColor3.BackColor;
                else if (v.ColorPart == 4)
                    v.vColor = btnColor4.BackColor;
                else if (v.ColorPart == 5)
                    v.vColor = btnColor5.BackColor;
                else if (v.ColorPart == 6)
                    v.vColor = btnColor6.BackColor;
                else if (v.ColorPart == 7)
                    v.vColor = btnColor7.BackColor;
                else if (v.ColorPart == 8)
                    v.vColor = btnColor8.BackColor;
                else if (v.ColorPart == 9)
                    v.vColor = btnColor9.BackColor;
                else if (v.ColorPart == 10)
                    v.vColor = btnColor0.BackColor;
            }
            pictureBox1.Invalidate();
            SaveState();

        }

        private bool SortIntoColorPart(myVertex v, List<myVertex> visited, int numColors, bool Initial = true)
        {
            if (visited.Count(x => x.Name == v.Name) != 0)
                return true;

            visited.Add(v);

            List<myVertex> adjVertices = GetAdjacentVertices(v);
            List<int> nextColorPart = new List<int>();

            if (Initial) // if it's not already visited, then it's a first
            {
                v.ColorPart = 1;
            }
            else
            {
                // check all neighbours and select best next color part
                List<myVertex> coloredNeighbours = adjVertices.Where(x => x.ColorPart != 0).ToList();
                nextColorPart.Clear();
                for (int i = 0; i < numColors; i++)
                {
                    nextColorPart.Add(i + 1);
                }
                foreach (myVertex cN in coloredNeighbours)
                {
                    nextColorPart.RemoveAll(x => x == cN.ColorPart);
                }
                if (nextColorPart.Count() == 0)
                    return false;
                v.ColorPart = nextColorPart.First();
            }

            foreach (myVertex nV in adjVertices)
            {
                if (SortIntoColorPart(nV, visited, numColors, false) == false)
                    return false;
            }
            return true;
        }

        private List<myVertex> GetAdjacentVertices(myVertex v)
        {
            List<myVertex> adjVertices = new List<myVertex>();
            foreach (var edge in myEdges.Where(x => (x.VertexA.Name == v.Name || x.VertexB.Name == v.Name)))
            {
                if (edge.VertexA.Name == edge.VertexB.Name)
                    continue; // ignore loops

                myVertex u;
                if (edge.VertexA.Name == v.Name)
                    u = myVertices.FirstOrDefault(x => x.Name == edge.VertexB.Name);
                else
                    u = myVertices.FirstOrDefault(x => x.Name == edge.VertexA.Name);
                adjVertices.Add(u);
            }

            return adjVertices;
        }

        private void btnCurrentK2_Click(object sender, EventArgs e)
        {
            if (myVertices.Count() == 0)
            {
                MessageBox.Show("Graph is Empty.", "K2 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("The graph showing on the drawpad will become G x K2. Are you sure you want to proceed?",
                        "G x K2", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int cc = myVertices.Count;
                List<myVertex> K2s = new List<myVertex>();
                Dictionary<string, string> vMatch = new Dictionary<string, string>();
                //recreate the vertices
                for (int i = 0; i < cc; i++)
                {
                    myVertex v = myVertices[i];
                    myVertex u = addNewVertex(new Point(v.Point.X + 75, v.Point.Y - 75), v.vColor);
                    vMatch.Add(v.Name, u.Name);
                    K2s.Add(u);
                }
                //recreate the edges
                int ecc = myEdges.Count;
                for (int i = 0; i < ecc; i++)
                {
                    myEdge eg = myEdges[i];
                    myVertex v = myVertices.FirstOrDefault(x => x.Name == vMatch[eg.VertexA.Name]);
                    myVertex u = myVertices.FirstOrDefault(x => x.Name == vMatch[eg.VertexB.Name]);
                    addNewEdge(v, u, eg.eColor);
                }

                //connect K1 to K2
                for (int i = 0; i < cc; i++)
                {
                    addNewEdge(myVertices[i], K2s[i]);
                }
            }
        }

        private void chbSimple_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSimple.Checked)
            {
                pictureBox1.Invalidate();
            }
        }

        private void chbWeights_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void btnSetSelected_Click(object sender, EventArgs e)
        {
            if (cboWeight.Text == "")
            {
                MessageBox.Show("Please select a weight", "Weight ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboWeight.Focus();
                return;
            }
            else if (selectedEdge == null)
            {
                MessageBox.Show("Please select an edge", "Weight ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            selectedEdge.Weight = Convert.ToInt32(cboWeight.Text);
            pictureBox1.Invalidate();
            SaveState();
        }

        private void btnSetAll_Click(object sender, EventArgs e)
        {
            if (cboWeight.Text == "")
            {
                MessageBox.Show("Please select a weight", "Weight ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboWeight.Focus();
                return;
            }
            foreach (var edge in myEdges)
            {
                edge.Weight = Convert.ToInt32(cboWeight.Text);
            }
            pictureBox1.Invalidate();
            SaveState();
        }

        private void btnDoubleSelected_Click(object sender, EventArgs e)
        {
            if (selectedEdge == null)
            {
                MessageBox.Show("Please select an edge", "Weight ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            selectedEdge.Weight = selectedEdge.Weight * 2;
            pictureBox1.Invalidate();
            SaveState();
        }

        private void btnDoubleAll_Click(object sender, EventArgs e)
        {
            foreach (var edge in myEdges)
            {
                edge.Weight = edge.Weight * 2;
            }
            pictureBox1.Invalidate();
            SaveState();
        }

        private void btnChangeDirection_Click(object sender, EventArgs e)
        {
            if (selectedEdge == null)
                return;

            myVertex a = selectedEdge.VertexA;
            myVertex b = selectedEdge.VertexB;
            selectedEdge.VertexA = b;
            selectedEdge.VertexB = a;
            pictureBox1.Invalidate();
            UpdateMatrices();
            SaveState();
        }

        private void chbEdgeDirection_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void cboAdjacency_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMatrices();
        }

        private void cboIncidence_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMatrices();
        }

        private void chbDegreeMatrix_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMatrices();
        }

        private void chbIdentityMatrix_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMatrices();
        }

        private void chbIncidenceD_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMatrices();
        }

        private void chbIncidenceTD_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMatrices();
        }

        private void chbLaplacian_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMatrices();
        }

        private void chbEigen_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMatrices();
        }
    }
}
