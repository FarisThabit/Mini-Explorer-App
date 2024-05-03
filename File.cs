using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    internal class File : GeneralDocument
    {
        private double size;
        private String ext;
        private String name;
        private Point filePosition;
        public File() { }
        public File(String name, double size, String ext) {
            this.size = size;
            this.ext = ext;
            this.name = name;
           
        }
        public  override string getInfo() { 
            return ( this.name+" _ " +Math.Round(this.size,2) +" MB"+ " _ " + this.ext);
        }
        

        public string getInfoForVisArea()
        {
            return "( " + Math.Round(this.size, 2) + " MB "+ " ) " + this.name+"."+this.ext;
        }

        public string getInfoForVisAreaPieChart()
        {
            return this.name + "." + this.ext + ", " + Math.Round(this.size, 2) + " MB";
        }

        public double getSize()
        {
            return this.size;
        }

        
        public PictureBox DisplayImage(string imagePath)
        {
            // Check if the image file exists
            if (!System.IO.File.Exists(imagePath))
            {
                throw new FileNotFoundException("The image file was not found.", imagePath);
            }

            // Load the image from the file
            System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);

            // Create a new PictureBox
            PictureBox pictureBox = new PictureBox();

            // Set the PictureBox size mode
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            // Set the PictureBox image
            pictureBox.Image = image;

            // Add the PictureBox to the form
            return pictureBox;
        }

        public void setFilePosition(Point tempPoint)
        {
            this.filePosition = tempPoint;
        }

        public Point getFilePosition()
        {
            return this.filePosition;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            File file = (File)obj;
            return name == file.name;


        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
    
}
