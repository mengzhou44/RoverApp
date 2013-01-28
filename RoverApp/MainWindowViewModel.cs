using System;
using System.IO;
using System.Text;
using System.Windows.Input;
using Microsoft.Win32;
using RoverApp.Business;

namespace RoverApp
{
    public class MainWindowViewModel: ObservableObject
    {

        private string instructionFile;

        private string instructions;

        private string result;

        private string[] lines;
        private bool runInstructionsEnabled = false; 


        private ICommand  getInstructionsCommand;
        private ICommand  runInstructionsCommand;

 
        public string InstructionFile
        {
             get { return instructionFile;  }

             set
             {
                 if (instructionFile !=value)
                 {
                     instructionFile = value;

                     OnPropertyChanged("InstructionFile"); 

                 }

             }

        }


        public string Instructions
        {
            get { return instructions; }

            set
            {
                if (instructions != value)
                {
                    instructions = value;

                    OnPropertyChanged("Instructions");

                }

            }

        }


        public string Result
        {
            get { return result; }

            set
            {
                if (result != value)
                {
                    result = value;

                    OnPropertyChanged("Result");

                }

            }

        }


        public ICommand GetInstructionsCommand
        {
            get
            {
                if ( getInstructionsCommand == null)
                {
                     getInstructionsCommand = new RelayCommand(
                        param => GetInstructions(),
                        param => true
                    );
                }
                return getInstructionsCommand;
            }
        }


        private void GetInstructions()
        {

            var dialog = new OpenFileDialog();


            dialog.DefaultExt = ".txt";

            dialog.Filter = "Text documents (.txt)|*.txt";



            if (dialog.ShowDialog() == true)
            {

                InstructionFile = dialog.FileName;

                Instructions = ReadFile(dialog.FileName);

                runInstructionsEnabled = true;
            }

        }

        private string ReadFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {

                string text = reader.ReadToEnd();

                lines = text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                return text;
            }
        }


        public ICommand RunInstructionsCommand
        {
            get
            {
                if (runInstructionsCommand == null)
                {
                    runInstructionsCommand = new RelayCommand(
                        param => RunInstructions(),
                        param => runInstructionsEnabled 
                    );
                }
                return runInstructionsCommand;
            }
        }
 
     
        private void RunInstructions()
        {


            try
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < lines.Length; i++)
                {

                    if (i == 0)
                    {
                       // Plateau.SetUp(lines[i]);

                    }

                    if (i % 2 == 1)
                    {
                        Rover rover = new Rover(lines[i]);

                        NasaCommander nasaCommander = new NasaCommander(rover);


                        string result = nasaCommander.SendInstructions(lines[i + 1]);

                        sb.AppendLine(result);

                    }

                }

               Result = sb.ToString();

                runInstructionsEnabled = false;

            }

            catch (Exception ex)
            {
                ErrorMessageBox.ShowException(ex);
            }
           
        }
    }
}
