using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public partial class Form1 : Form
    {
        private Folder initialFolder = new Folder("232", "C:\\Users\\faris\\OneDrive\\Desktop\\Test Folder A", true, new Point(0, 0));
        private List<GeneralDocument> gDoc;
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private Timer scrollTimer = new Timer();
        private Dictionary<int, int> subfolderCount = new Dictionary<int, int>();
        private List<int> subFoldersYcordinates = new List<int>();
        private static int previousSubFolder = 0;
        private bool isMouseDown = false;
        private Dictionary<PictureBox, bool> pictureBoxesWithHandlers = new Dictionary<PictureBox, bool>();
        private Rectangle? lastRectangle = null;
        private bool barChartFlag = true;
        private int initialYpos = 15;
        private bool barhasDrawn = false;
        private bool pieHasDrawn = false;
        public Form1()
        {
            InitializeComponent();
            initialFolder.setScreenDocyPos(5);
            initialFolder.loadDisplayedContenetToScreenUV(5, initialFolder);
            loadContentToScreen(initialFolder);
            //DrawBarAndPieCharts();
        }

        private void Panel1_Scroll(object sender, ScrollEventArgs e)
        {
            scrollTimer.Stop();
            scrollTimer.Start();
        }
        // SCROLL HANDLER
        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
           // mousePosition.Text = "SCROLLE HANDLER RUNNING";
            scrollTimer.Stop();
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                if (gDoc[i] is Folder)
                {
                    PictureBox pictureBox = pictureBoxes[i];
                }
                else
                {
                    PictureBox pictureBox = pictureBoxes[i];

                }
            }


        }

        private void FolderArea2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        // picturebox click handler
        private void FolderAreaMouseClicked(object sender, MouseEventArgs e)
        {

            isMouseDown = true;
            if (isMouseDown)
            {
                PictureBox pb = sender as PictureBox;
                Point position = pb.Location;
                // position of a parent folde
               // mousePosition.Text = "Run..." + pb.Location.X + " " + pb.Location.Y;
                initialFolder.turnOnDisplayContentflag(new Point(pb.Location.X, pb.Location.Y), initialFolder);
                initialFolder.setScreenDocyPos(5);
                initialFolder.loadDisplayedContenetToScreenUV(5, initialFolder);
                loadContentToScreen(initialFolder);
                highlate(pb.Location);


            }


        }

        private void loadContentToScreen(Folder f)
        {
            //    FolderArea.Controls.Clear();
            //    FolderArea.Controls.Clear();
            if (f.getDisplayContentFlag())
            {
                for (int i = 0; i < f.getFoldarDoc().Count; i++)
                {
                    FolderArea2.Controls.Add(f.GetPictureBoxes()[i]);
                    FolderArea2.Controls.Add(f.getLabelList()[i]);

                    if (!(f.getFoldarDoc()[i] is File))
                    {
                        if (!pictureBoxesWithHandlers.ContainsKey(f.GetPictureBoxes()[i]))
                        {
                            pictureBoxesWithHandlers[f.GetPictureBoxes()[i]] = true;
                            f.GetPictureBoxes()[i].MouseDown -= new System.Windows.Forms.MouseEventHandler(this.FolderAreaMouseClicked);
                            f.GetPictureBoxes()[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.FolderAreaMouseClicked);
                        }
                        loadContentToScreen(((Folder)f.getFoldarDoc()[i]));
                    }
                }
            }

        }

        

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    FolderArea2.Controls.Clear();
                   // Console.WriteLine(fbd.SelectedPath);
                    initialFolder = new Folder("New Folder 2", fbd.SelectedPath);
                    initialFolder.setDisplayContentFlag(true);
                    //Console.WriteLine("Hello");
                   // Console.WriteLine(initialFolder.getPath());
                    initialFolder.loadDisplayedContenetToScreenUV(5, initialFolder);
                    loadContentToScreen(initialFolder);
                    highlate(new Point(0, 0));
                    barhasDrawn = false;
                    initialYpos = 15;
                    DrawingArea.Controls.Clear();
                    DrawingArea.Invalidate();

                }
            }
        }
        //var rectangle = new Rectangle(point.X-3, point.Y-3, 250, 25);
        private void highlate(Point position)
        {

            // Get the point where the mouse was clicked.
            var point = position;
            Rectangle rectangle;

            // Define the rectangle that contains the point.
            if (position != new Point(0, 0))
            {
                 rectangle = new Rectangle(point.X - 3, point.Y - 3, 250, 25);
            }
            else {
                 rectangle = new Rectangle(point.X - 3, point.Y - 3, 0, 0);


            }



            // Create a Graphics object for the panel.
            using (var graphics = FolderArea2.CreateGraphics())
            {
                // If a rectangle was previously drawn, erase it by filling it with the panel's background color.
                if (lastRectangle.HasValue)
                {
                    using (var pen = new Pen(FolderArea2.BackColor))
                    {
                        graphics.DrawRectangle(pen, lastRectangle.Value);
                    }
                }

                // Draw the new rectangle.
                using (var pen = new Pen(Color.Black))
                {
                    graphics.DrawRectangle(pen, rectangle);
                }
            }

            // Store the new rectangle as the last rectangle drawn.
            lastRectangle = rectangle;

        }
        // bar chart button handler
        private void button1_Click(object sender, EventArgs e)
        {
            barChartFlag = true;
            barhasDrawn = false;
            initialYpos = 15;
            DrawingArea.Controls.Clear();
            DrawingArea.Invalidate();

        }

        private void Drawing_Area_Paint(object sender, PaintEventArgs e)
        {
            if (!barhasDrawn && barChartFlag)
            {
                Graphics g = DrawingArea.CreateGraphics();
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                foreach (GeneralDocument subDoc in initialFolder.getFoldarDoc())
                {
                    Brush brush;
                    int size = 0;

                    if (subDoc is File)
                    {
                        File tempFile = (File)subDoc;
                        brush = new SolidBrush(Color.Orange); // Fill color Orange for Files
                        if (tempFile.getSize() <= 1)
                        {
                            size = (int)(10 * ((tempFile.getSize())));
                        }
                        else {
                            size = (int)(tempFile.getSize()*2);
                        }
                        TransparentLabel fileLabel = new TransparentLabel();
                        fileLabel.Size = new Size(210, 15);
                        fileLabel.Location = new Point( size+30 , initialYpos + 12); // Position the label next to the rectangle
                        fileLabel.Text = tempFile.getInfoForVisArea();
                        DrawingArea.Controls.Add(fileLabel);
                    }
                    else
                    {
                        Folder tempFolder = (Folder)subDoc;
                        brush = new SolidBrush(Color.LightBlue); // Fill color LightBlue for Folders
                        if (tempFolder.getSize() <= 1)
                        {
                            size = (int)(10 * ((tempFolder.getSize())));
                        }
                        else
                        {
                            size = (int)(tempFolder.getSize()*2);
                        }
                      
                        TransparentLabel folderLabel = new TransparentLabel();
                        folderLabel.Size = new Size(210, 15);
                        folderLabel.Location = new Point( size + 30, initialYpos + 12); // Position the label next to the rectangle
                        folderLabel.Text = tempFolder.getInfoForVisArea();
                        DrawingArea.Controls.Add(folderLabel);
                    }

                    g.FillRectangle(brush, 25, initialYpos, size, 40);
                    initialYpos += 50;
                }

                barhasDrawn = true; // Set the flag to true after drawing
            }
            else if(pieHasDrawn)
            {
                Console.WriteLine("Hi");
                PieChart.Visible = true;
                foreach (GeneralDocument subDoc in initialFolder.getFoldarDoc())
                {
                    if (subDoc is File)
                    {
                        File file = (File)subDoc;
                        PieChart.Series["s1"].Points.AddXY(file.getInfoForVisAreaPieChart(), (file.getSize()) * 20);
                    }
                    else
                    {
                        Folder folder = (Folder)subDoc;
                        PieChart.Series["s1"].Points.AddXY(folder.getInfoForVisAreaPieChart(), (folder.getSize()) * 20);

                    }

                }
                pieHasDrawn = false;
            }
        }
    


        private void PieChartBtn_Click(object sender, EventArgs e)
        {
            //  PieChart.Series["s1"].Points.AddXY("l1",30);
            barChartFlag = false;
            pieHasDrawn = true;
            DrawingArea.Invalidate();
           

        }

        private void Drawing_Area_MouseDown(object sender, MouseEventArgs e)
        {
            //label2.Text = ""+e.Location;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
    

