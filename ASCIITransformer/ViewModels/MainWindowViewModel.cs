using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using System.Globalization;

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

        public DelegateCommand ASCIIToString { get; set; }
        void _ASCIIToString()
        {            
            if (Flag)
            {
                try
                {
                    Flag = false;
                    Stringtemp = TextBoxASCIICode.Replace(" ", "");
                    string str1 = string.Empty;
                    for (i = 0; i < Stringtemp.Length; i += 2)
                    {
                        Byte j = Byte.Parse(Stringtemp.Substring(i, 2), NumberStyles.HexNumber);
                        str1 += Encoding.ASCII.GetString(new byte[] { j });
                    }
                    TextBoxStringCode = str1;
                }catch (Exception) { ;}                
            }           
        }

        private byte[] Bytestring;
        private int i;
        private string asciicode;
        private string Stringtemp = string.Empty;


        public DelegateCommand StringToASCII { get; set; }
        void _StringToASCII()
        {            
            if(Flag)
            {
                Flag = false;
                try
                {
                    Stringtemp = TextBoxStringCode.Replace(" ", "");
                    Bytestring = System.Text.Encoding.ASCII.GetBytes(Stringtemp);
                    asciicode = "";
                    for (i = 0; i < Stringtemp.Length; i++)
                    {
                        asciicode += Bytestring[i].ToString("X2");
                        if (IsCheckBoxSpace)
                            asciicode += " ";
                    }                          
                    TextBoxASCIICode = asciicode;                    
                }
                catch (Exception) { ;}               
            } 
        }

        public DelegateCommand SetupFlag { get; set; }
        private void _SetupFlag()
        {
            Flag = true;
        }
        public MainWindowViewModel()
        {
            SetupFlag = new DelegateCommand(_SetupFlag);
            StringToASCII = new DelegateCommand(_StringToASCII);
            ASCIIToString = new DelegateCommand(_ASCIIToString);
        }
      
    }
}
