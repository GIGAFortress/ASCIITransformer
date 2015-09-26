using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows;
using Microsoft.Practices.Prism.Commands;

namespace ASCIITransformer.ViewModels
{
    class MainWindowViewModel: BindableBase
    {
        private string _TextBoxASCIICode;
        public string TextBoxASCIICode
        {
            get { return _TextBoxASCIICode; }
            set { _TextBoxASCIICode = value; OnPropertyChanged("TextBoxASCIICode"); }
        }

        private string _TextBoxStringCode;
	    public string TextBoxStringCode
	    {
		    get { return _TextBoxStringCode;}
            set { _TextBoxStringCode = value; OnPropertyChanged("TextBoxStringCode"); }
	    }
	
        private Boolean _IsCheckBoxSpace;
	    public Boolean IsCheckBoxSpace
	    {
		    get { return _IsCheckBoxSpace;}
            set { _IsCheckBoxSpace = value; OnPropertyChanged("IsCheckBoxSpace"); }
	    }

        private int _LabelASCIILength = 0;
        public int LabelASCIILength
        {
            get { return _LabelASCIILength; }
            set { _LabelASCIILength = value; OnPropertyChanged("LabelASCIILength"); }
        }

        private int _LabelStringLength = 0;
        public int LabelStringLength
        {
            get { return _LabelStringLength; }
            set { _LabelStringLength = value; OnPropertyChanged("LabelStringLength"); }
        }

        private Boolean Flag = true;

        void ASCIIToString()
        {
            MessageBox.Show("Hello");
            if (Flag)
            {
                Flag = false;
                Stringtemp = TextBoxASCIICode.Replace(" ", "");
                for (i = 0; i < Stringtemp.Length; i++)
                {
                    if (Stringtemp[i] > 127) { Flag1 = false; }
                }
                if(Flag1)
                {

                }
            }
           
        }

        private byte[] Bytestring;
        private int i;
        private bool Flag1;
        private string asciicode;
        private string Stringtemp;

        //    private string tempstring1;
        void StringToASCII()
        {
            if(Flag)
            {
                Flag = false;
                Stringtemp = TextBoxStringCode.Replace(" ","");
                for (i = 0; i < Stringtemp.Length; i++)
                {
                    if (Stringtemp[i] > 127) { Flag1 = false; }
                }
                Bytestring = System.Text.Encoding.ASCII.GetBytes(Stringtemp);
                asciicode = "";                
                if (Flag1)
                {                                        
                    for(i = 0;i < Stringtemp.Length; i++)
                    {                    
                        asciicode += Bytestring[i].ToString("X2");
                        if(IsCheckBoxSpace)
                        asciicode += " ";
                    }
                }
                if (asciicode != "")
                    TextBoxASCIICode = asciicode;
                else
                    TextBoxASCIICode = "";
            }            
        }

        public DelegateCommand SetupFlag { get; set; }
        private void _SetupFlag()
        {
            Flag = true;
            Flag1 = true;
        }
        public MainWindowViewModel()
        {
            SetupFlag = new DelegateCommand(_SetupFlag);
            for(i = 1; i < 30; i++)
            {
                TextBoxASCIICode += string.Format("{0:F2}", i);
                TextBoxASCIICode += " ";
            }
        }
      
    }
}
