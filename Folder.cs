using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace HW2
{
    internal class Folder : GeneralDocument
    {
        private List<GeneralDocument> docList = new List<GeneralDocument>();
        // The list of picture box will display the icon of each element in 
        // the genral document list
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        // labeleList will display the name of each eleement in GeneralDocument list
        private List<System.Windows.Forms.Label> labelList = new List<System.Windows.Forms.Label>();
        private String initialPath;
        private String name;
        // the folder position must be equal to its picture box position
        // the initial folder must not have any position becuase it want has
        // picture box icen
        private Point folderPosition;
        // the initial value of displayContent is false except for the initial
        // folder it will be true
        private bool displayContent = false;
        // Initial documents position on screen
        private int screenDocyPos;
        private double size;


        public Folder(String name, String path)
        {
            this.name = name;
            this.initialPath = path;

        }
        public Folder(String name, String path, double size)
        {
            this.name = name;
            this.initialPath = path;
            this.size = size;   
        }
        public Folder(String name, String path, bool displayContent, Point folderPosition)
        {
            this.name = name;
            this.initialPath = path;
            this.displayContent = displayContent;
            this.folderPosition = folderPosition;

        }
        
        public string getInfoForVisAreaPieChart()
        {
            return this.name + ", " + Math.Round(this.size,2)+" MB";
        }
        public void setScreenDocyPos(int pos) 
        {
            this.screenDocyPos = pos;
        }
        public Point getFolderPosition()
        {
            return folderPosition;
        }
        
        public List<PictureBox> GetPictureBoxes()
        {
            return pictureBoxes;
        }
        public override string getInfo()
        {
            return this.name;
        }
        public double getSize()
        {
            return this.size;
        }

        public string getInfoForVisArea() {
            return "( " + Math.Round(this.size, 2) + " MB " + " ) " + this.name;
        }

        public string getPath()
        {
            return this.initialPath;
        }
        public List<GeneralDocument> getFoldarDoc()
        {
            return docList;
        }

        public List<System.Windows.Forms.Label> getLabelList()
        {
            return this.labelList;
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


        public void setFoldePosition(Point tempPoint)
        {
            this.folderPosition = tempPoint;
        }
        public void setFoldePath(String path)
        {
            this.initialPath = path;
        }
        public bool getDisplayContentFlag()
        {
            return this.displayContent;
        }
        public void setDisplayContentFlag(bool flag)
        {
            this.displayContent = flag;
        }
        // public Point getFolderLabelPosition()
        // {
        // return this.folderlabelPosition;
        // }

        private long getAllFolderSizes(String path)
        {
            long totalSize = 0;
            DirectoryInfo folder = new DirectoryInfo(path);

            // Calculate the size of all files in the folder.
            FileInfo[] allFiles = folder.GetFiles();
            foreach (FileInfo file in allFiles)
            {
                totalSize += file.Length;
            }

            // If a subdirectory is found, calculate its size recursively.
            DirectoryInfo[] subfolders = folder.GetDirectories();
            foreach (DirectoryInfo subfolder in subfolders)
            {
                totalSize += getAllFolderSizes(subfolder.FullName);
            }

            return totalSize;

        }

        public List<GeneralDocument> Search(List<GeneralDocument> gDList, Point p)
        {
            for (int i = 0; i < gDList.Count; i++)
            {
                if (gDList[i] is Folder)
                {
                    if ((((Folder)gDList[i]).getFolderPosition().X).Equals(p.X) && (((Folder)gDList[i]).getFolderPosition().Y).Equals(p.Y))
                    {
                        // Console.WriteLine("Found");
                        return ((Folder)gDList[i]).getFoldarDoc();
                    }
                    else
                    {
                        // Console.WriteLine("not found but it is a folder");
                        //Console.WriteLine(((Folder)gDList[i]).getFolderLabelPosition());
                        Search(((Folder)gDList[i]).getFoldarDoc(), p);
                    }
                }
                else
                {
                    //Console.WriteLine("not found but it is a file");
                }
            }
            return new List<GeneralDocument>() { };


        }




        public void turnOnDisplayContentflag(Point folderPosition, Folder parentFolder) {
            for (int i = 0; i < parentFolder.getFoldarDoc().Count && parentFolder.getFoldarDoc().Count != 0; i++) {
                if (parentFolder.getFoldarDoc()[i] is Folder) {
                    //Console.WriteLine("Running...");
                    //if ((((Folder)getFoldarDoc()[i]).getFolderPosition().X).Equals(folderPosition.X) && (((Folder)getFoldarDoc()[i]).getFolderPosition().Y).Equals(folderPosition.Y))
                    if (((((Folder)parentFolder.getFoldarDoc()[i]).getFolderPosition().X).Equals(folderPosition.X) && (((Folder)parentFolder.getFoldarDoc()[i]).getFolderPosition().Y).Equals(folderPosition.Y)))
                    {
                        //Console.WriteLine("Found");
                        ((Folder)parentFolder.getFoldarDoc()[i]).displayContent = true;
                    }
                    else {
                        turnOnDisplayContentflag(folderPosition, ((Folder)parentFolder.getFoldarDoc()[i]));
                    }
                }
            }

        }
        // contains methode extensions

      
      public void loadDisplayedContenetToScreenUV(int screenXPos, Folder parentFolder)
      {
            if (parentFolder.getDisplayContentFlag())
            {
                // file paths
                string[] filePaths = Directory.GetFiles(parentFolder.getPath());
                foreach (string filePath in filePaths)
                {
                    
                    // create a file info object to get information about size of each file
                    FileInfo fileInfo = new FileInfo(filePath);
                    // using a file paths to get files names and extension
                    String currFileName = Path.GetFileNameWithoutExtension(filePath);
                    double currFileSize = (fileInfo.Length/ 1024f)/ 1024f;
                    String currFileExt = Path.GetExtension(filePath);
                    // create a temp file for each file in the given path
                    File tempFile = new File(currFileName, currFileSize, currFileExt);
                    //Console.WriteLine("initial subfile  "+ screenDocyPos);
                    tempFile.setFilePosition(new Point(screenXPos, screenDocyPos));
                    /*
                    if (parentFolder.getFoldarDoc().Contains(tempFile)) {
                        int subFolderInd = parentFolder.getFoldarDoc().IndexOf(tempFile);
                        if (((File)parentFolder.getFoldarDoc()[subFolderInd]).getFilePosition().Y < screenDocyPos) {
                            Console.WriteLine("Yes");
                            ((File)parentFolder.getFoldarDoc()[subFolderInd]).setFilePosition(new Point(((File)parentFolder.getFoldarDoc()[subFolderInd]).getFilePosition().X, screenDocyPos));
                            parentFolder.GetPictureBoxes()[subFolderInd].Location = new Point(((File)parentFolder.getFoldarDoc()[subFolderInd]).getFilePosition().X, screenXPos);
                            parentFolder.getLabelList()[subFolderInd].Location = new Point(parentFolder.GetPictureBoxes()[subFolderInd].Location.X + 20, parentFolder.GetPictureBoxes()[subFolderInd].Location.Y);
                        }
                    }
                    */
                    PictureBox fileICon = tempFile.DisplayImage("C:\\Users\\faris\\OneDrive\\Desktop\\232\\SWE-316\\google-docs.png");
                    fileICon.Size = new Size(20, 20);
                    fileICon.Location = tempFile.getFilePosition();
                    System.Windows.Forms.Label fileLabel = new System.Windows.Forms.Label();
                    fileLabel.Size = new Size(210, 15);
                    fileLabel.Location = new Point(fileICon.Location.X + 20, fileICon.Location.Y + 3);
                    fileLabel.Text = tempFile.getInfo();
                    if (parentFolder.getFoldarDoc().Count < filePaths.Length)
                    {
                        parentFolder.getFoldarDoc().Add(tempFile);
                        parentFolder.GetPictureBoxes().Add(fileICon);
                        parentFolder.getLabelList().Add(fileLabel);
                    }
                    screenDocyPos += 40;
                    
                    
                }
                    // get the path of each subfolder
                    string[] subFoldersPaths = Directory.GetDirectories(parentFolder.getPath());
                    foreach (string subFolderPath in subFoldersPaths)
                    {
                        // getting the name of each sub folder using path and creatig a new folder
                        string subfolderName = System.IO.Path.GetFileName(subFolderPath);
                        String currentSubFolderPath = subFolderPath;
                        Console.WriteLine(currentSubFolderPath);
                        double size = (GetDirectorySize(currentSubFolderPath)/ 1024f)/ 1024f;
                        Folder tempFolder = new Folder(subfolderName, currentSubFolderPath, size);
                        if (parentFolder.getFoldarDoc().Contains(tempFolder)) 
                        {
                            int tempFolderIndex = parentFolder.getFoldarDoc().IndexOf(tempFolder);
                            if (((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).getDisplayContentFlag())
                            {
                                if ((parentFolder.getFoldarDoc()[tempFolderIndex - 1]) is Folder && (((Folder)parentFolder.getFoldarDoc()[tempFolderIndex - 1]).getDisplayContentFlag()))
                                
                                {
                                    if (((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y < screenDocyPos)
                                    {
                                    ((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).setFoldePosition(new Point(((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X, screenDocyPos));
                                        (parentFolder.GetPictureBoxes()[tempFolderIndex]).Location = ((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).getFolderPosition();
                                        (parentFolder.getLabelList()[tempFolderIndex]).Location = new Point(((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X + 20, ((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y);
                                    }
                                }
                                screenDocyPos += 40;
                                loadDisplayedContenetToScreenUV(((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X + 20, ((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]));


                            }
                            else
                            {
                                if (((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y < screenDocyPos)
                                {
                                    ((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).setFoldePosition(new Point(((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X, screenDocyPos));
                                    (parentFolder.GetPictureBoxes()[tempFolderIndex]).Location = ((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).getFolderPosition();
                                    (parentFolder.getLabelList()[tempFolderIndex]).Location = new Point(((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X + 20, ((Folder)parentFolder.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y);
                                    
                                }
                                screenDocyPos += 40;
                            }

                        }
                        else
                        {

                        // set the position of tempFolder
                            tempFolder.setFoldePosition(new Point(screenXPos, screenDocyPos));
                            // create folder icon for each subfolder in the parent folder
                            PictureBox folderIcon = tempFolder.DisplayImage("C:\\Users\\faris\\OneDrive\\Desktop\\232\\SWE-316\\folder.png");
                            // set the size of each picturebox
                            folderIcon.Size = new Size(20, 20);
                            // set the picturebox position and the picturebox position should be equal to the subfolderPosition
                            folderIcon.Location = tempFolder.getFolderPosition();
                            System.Windows.Forms.Label foldertLabel = new System.Windows.Forms.Label();
                            foldertLabel.Size = new Size(210, 15);
                            foldertLabel.Text = subfolderName;
                            foldertLabel.Location = new Point(folderIcon.Location.X + 20, folderIcon.Location.Y + 3);
                            // add the subFolder to the parent list of documnets
                            parentFolder.getFoldarDoc().Add(tempFolder);
                             Console.WriteLine(tempFolder.size);
                            screenDocyPos += 40;
                            // add the foldericon to the parent list of icons
                            parentFolder.GetPictureBoxes().Add(folderIcon);
                            // add the folderlabel to the parent list of labels
                            parentFolder.getLabelList().Add(foldertLabel);

                        }

                    }
                }


            }
        private long GetDirectorySize(string folderPath)
        {
            long size = 0;
            // Get array of all file names.
            string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            // Calculate total bytes of all files in a loop.
            foreach (string name in files)
            {
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                size += info.Length;
            }
            // Return total size
            return size;
        }
        


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
          
                Folder folder = (Folder)obj;
                return name == folder.name;
            
            
        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }


    }
                        }

