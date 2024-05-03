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
    internal class TestFunctions
    {
        /*
        public void loadDisplayedContenetToScreen(int x, int y, String folderPath, Folder f)
        {
            if (f.displayContent == true && f.getFoldarDoc().Count == 0) {
                // file paths
                string[] files = Directory.GetFiles(folderPath);
                foreach (string file in files) {

                    // create a file info object to get information about size of each file
                    FileInfo fileInfo = new FileInfo(file);
                    // using a file paths to get files names and extension
                    String currFileName = Path.GetFileNameWithoutExtension(file);
                    long currFileSize = fileInfo.Length;
                    String currFileExt = Path.GetExtension(file);
                    // create a temp file for each file in the given path
                    File tempFile = new File(currFileName, currFileSize, currFileExt);
                    // set File position and File position and its file icon must be the same
                    tempFile.setFilePosition(new Point(x, y));
                    f.getFoldarDoc().Add(tempFile);
                    // create a file icon for each file in the given path
                    PictureBox fileICon = tempFile.DisplayImage("C:\\Users\\faris\\OneDrive\\Desktop\\232\\SWE-316\\google-docs.png");
                    fileICon.Size = new Size(20, 20);
                    fileICon.Location = tempFile.getFilePosition();
                    System.Windows.Forms.Label fileLabel = new System.Windows.Forms.Label();
                    fileLabel.Size = new Size(210, 15);
                    fileLabel.Location = new Point(fileICon.Location.X + 20, fileICon.Location.Y + 3);
                    fileLabel.Text = tempFile.getInfo();
                    f.getFoldarDoc().Add(tempFile);
                    f.GetPictureBoxes().Add(fileICon);
                    f.getLabelList().Add(fileLabel);
                    y += 40;
                }
                // get the path of each subfolder
                    string[] subFolders = Directory.GetDirectories(folderPath);
                    foreach (string subFolder in subFolders) {
                        // getting the name of each sub folder using path and creatig a new folder
                        string subfolderName = System.IO.Path.GetFileName(subFolder);
                        Folder tempFolder = new Folder(subfolderName);
                    if (f.getFoldarDoc().Contains(tempFolder))
                    {
                        int tempFolderIndex = f.getFoldarDoc().IndexOf(tempFolder);
                        if (((Folder)f.getFoldarDoc()[tempFolderIndex]).getDisplayContentFlag())
                        {
                            loadDisplayedContenetToScreen(((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X + 20, ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y + 40, subFolder, ((Folder)f.getFoldarDoc()[tempFolderIndex]));
                            y = ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y + 40 * ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFoldarDoc().Count;
                        }
                        else {
                            if (((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y < y) {
                                y += 40;
                                ((Folder)f.getFoldarDoc()[tempFolderIndex]).setFoldePosition(new Point(((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X, y));
                                (f.GetPictureBoxes()[tempFolderIndex]).Location = ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition();
                                (f.getLabelList()[tempFolderIndex]).Location = new Point(((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X+20, ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y);
                            }
                        
                        }
                    }
                    else {
                        // set the position of tempFolder
                        tempFolder.setFoldePosition(new Point(x,y));
                        y += 40;
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
                        f.getFoldarDoc().Add(tempFolder);
                        // add the foldericon to the parent list of icons
                        f.GetPictureBoxes().Add(folderIcon);
                        // add the folderlabel to the parent list of labels
                        f.getLabelList().Add(foldertLabel);


                    }
                }


            }
            
        }

        ...............................................

          public void loadDisplayedContenetToScreen(int x, int y, String folderPath, Folder f)
        {
            if (f.displayContent == true)
            {
                if (f.getFoldarDoc().Count == 0) {

                    // file paths
                    string[] files = Directory.GetFiles(folderPath);
                    foreach (string file in files)
                    {

                        // create a file info object to get information about size of each file
                        FileInfo fileInfo = new FileInfo(file);
                        // using a file paths to get files names and extension
                        String currFileName = Path.GetFileNameWithoutExtension(file);
                        long currFileSize = fileInfo.Length;
                        String currFileExt = Path.GetExtension(file);
                        // create a temp file for each file in the given path
                        File tempFile = new File(currFileName, currFileSize, currFileExt);
                        // set File position and File position and its file icon must be the same
                        tempFile.setFilePosition(new Point(x, y));
                        f.getFoldarDoc().Add(tempFile);
                        // create a file icon for each file in the given path
                        PictureBox fileICon = tempFile.DisplayImage("C:\\Users\\faris\\OneDrive\\Desktop\\232\\SWE-316\\google-docs.png");
                        fileICon.Size = new Size(20, 20);
                        fileICon.Location = tempFile.getFilePosition();
                        System.Windows.Forms.Label fileLabel = new System.Windows.Forms.Label();
                        fileLabel.Size = new Size(210, 15);
                        fileLabel.Location = new Point(fileICon.Location.X + 20, fileICon.Location.Y + 3);
                        fileLabel.Text = tempFile.getInfo();
                        f.GetPictureBoxes().Add(fileICon);
                        f.getLabelList().Add(fileLabel);
                        y += 40;
                    }


                }


                // get the path of each subfolder
                string[] subFolders = Directory.GetDirectories(folderPath);
                foreach (string subFolder in subFolders)
                {
                    // Console.WriteLine("SF1");
                    //Console.WriteLine(subFolders.Length);
                    // getting the name of each sub folder using path and creatig a new folder
                    string subfolderName = System.IO.Path.GetFileName(subFolder);
                    //  Console.WriteLine("tempfolder name"+subfolderName);
                    Folder tempFolder = new Folder(subfolderName);
                    if (f.getFoldarDoc().Contains(tempFolder))
                    {
                        //   Console.WriteLine("************* folder already exist"+tempFolder.name+ "*************");
                        // Console.WriteLine("Entering");
                        int tempFolderIndex = f.getFoldarDoc().IndexOf(tempFolder);
                        if (((Folder)f.getFoldarDoc()[tempFolderIndex]).getDisplayContentFlag())
                        {

                            Console.WriteLine("Recersion");
                            loadDisplayedContenetToScreen(((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X + 20, ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y + 40, subFolder, ((Folder)f.getFoldarDoc()[tempFolderIndex]));
                            if ((f.getFoldarDoc()[tempFolderIndex - 1]) is Folder && (((Folder)f.getFoldarDoc()[tempFolderIndex - 1]).getDisplayContentFlag()) && ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFoldarDoc().Count > 0)
                            {
                                y = Math.Min(y, ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y + 40 * ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFoldarDoc().Count);
                                if ((f.getFoldarDoc()[tempFolderIndex - 1]) is Folder && ((Folder)f.getFoldarDoc()[tempFolderIndex - 1]).getDisplayContentFlag())
                                {
                                    if (((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y <= y)
                                    {

                                        Console.WriteLine("Enter");
                                        Console.WriteLine(((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y);
                                        y += 40;
                                        ((Folder)f.getFoldarDoc()[tempFolderIndex]).setFoldePosition(new Point(((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X, y));
                                        (f.GetPictureBoxes()[tempFolderIndex]).Location = ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition();
                                        (f.getLabelList()[tempFolderIndex]).Location = new Point(((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X + 20, ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y);
                                    }
                                    Console.WriteLine("21");
                                    y = ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y + 40 * ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFoldarDoc().Count + 1;


                                }

                            }
                            else {
                                y = Math.Max(y, ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y + 40 * ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFoldarDoc().Count);
                                if ((f.getFoldarDoc()[tempFolderIndex - 1]) is Folder && ((Folder)f.getFoldarDoc()[tempFolderIndex - 1]).getDisplayContentFlag())
                                {
                                    if (((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y < y && (f.getFoldarDoc()).Count - 1 != tempFolderIndex)
                                    {

                                        Console.WriteLine("Enter");
                                        Console.WriteLine(((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y);
                                        y += 40;
                                        ((Folder)f.getFoldarDoc()[tempFolderIndex]).setFoldePosition(new Point(((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X, y));
                                        (f.GetPictureBoxes()[tempFolderIndex]).Location = ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition();
                                        (f.getLabelList()[tempFolderIndex]).Location = new Point(((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X + 20, ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y);
                                    }

                                }
                            }





                        }
                        else
                        {
                            if (((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y <= y)
                            {
                                y += 40;
                                Console.WriteLine("!!!!");
                                ((Folder)f.getFoldarDoc()[tempFolderIndex]).setFoldePosition(new Point(((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X, y));
                                (f.GetPictureBoxes()[tempFolderIndex]).Location = ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition();
                                (f.getLabelList()[tempFolderIndex]).Location = new Point(((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().X + 20, ((Folder)f.getFoldarDoc()[tempFolderIndex]).getFolderPosition().Y);
                            }

                        }
                    }
                    else
                    {

                        // set the position of tempFolder
                        tempFolder.setFoldePosition(new Point(x, y));
                        y += 40;
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
                        f.getFoldarDoc().Add(tempFolder);
                        // add the foldericon to the parent list of icons
                        f.GetPictureBoxes().Add(folderIcon);
                        // add the folderlabel to the parent list of labels
                        f.getLabelList().Add(foldertLabel);
                        // Console.WriteLine(f.GetPictureBoxes().Count);
                        // Console.WriteLine(f.getFoldarDoc().Count);
                    }



                }
            }
        }
        */


    }
}
