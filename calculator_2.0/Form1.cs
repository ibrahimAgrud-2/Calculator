using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            data.operationType = operationType.noOperation;
        }


        string number = "";

        enum operationType { sum = '+', subtract = '-', multiply = 'x', divide = '÷', squareRoot = '√', noOperation ='='};

        struct sData
        {
            public float firstNumber;
            public operationType operationType;
            public float secondNumber;
        }

        sData data = new sData();
        string calculate(sData data)
        {
            switch (data.operationType)
            {
                case operationType.sum:

                    return (data.firstNumber + data.secondNumber).ToString();


                case operationType.subtract:

                    return(data.firstNumber - data.secondNumber).ToString();

                case operationType.multiply:

                    return(data.firstNumber * data.secondNumber).ToString();

                case operationType.divide:

                    if (data.secondNumber==0)
                    {
                      
                        return "cant divide by zero";
                    }
                    else
                    {
                        return  (data.firstNumber / data.secondNumber).ToString();

                    }

                default:
                    return data.secondNumber.ToString();

            }
        }


      

        private void numberButtonClick(object sender, EventArgs e)
        {
           Button button = (Button)sender;
            number+=button.Text;
            textBox1.Text=number;

        }


      
        void setOperation(operationType opType)
        {
           
            if (number != "")
            {
                data.firstNumber = (float)Convert.ToDouble(textBox1.Text);
                data.operationType = opType;

                textBox2.Text = data.firstNumber + " " + (char)data.operationType;
                number = "";
                button18.Enabled = true;

            }
        }

       
        private void button11_Click(object sender, EventArgs e)
        {
           if (number=="")
 {
     return;
 }
 data.secondNumber = (float)Convert.ToDouble(number);
 if (data.operationType == operationType.divide && data.secondNumber == 0)
 {
     number = "";
     textBox1.Text = "cant divide by zero";
     textBox2.Text = "";
     data.operationType = operationType.noOperation;
 }

 else if (data.operationType != operationType.noOperation)
 {
     

     textBox2.Text = data.firstNumber + " " + (char)data.operationType + " " + data.secondNumber + " =";

     textBox1.Text = calculate(data);

     data.firstNumber = (float)Convert.ToDouble(calculate(data));

 }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (number.Length - 1 >= 0)
            {
                number = number.Remove(number.Length - 1, 1);
             
                textBox1.Text = number;
            }
        }

   

        private void button14_Click(object sender, EventArgs e)
        {
            number = "";
            data.firstNumber = 0;
            data.secondNumber = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            data.operationType= operationType.noOperation;
            button18.Enabled = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (number != "")
            {
                double result = Math.Sqrt(Convert.ToDouble(number));
                textBox2.Text = "√(" + number + ")"+" = ";
                textBox1.Text = result.ToString();
                
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {

            if (this.BackColor == Color.LightSlateGray)
            {
                this.BackColor = Color.Black;
                button19.Text = "Light Mode";

            }
            else
            {
                this.BackColor = Color.LightSlateGray;
                button19.Text = "Dark Mode";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

            if (number != "")
            {
                number += ",";
                textBox1.Text = number;  
               
            }
           button18.Enabled= false;
        }



      

        private void button12_Click(object sender, EventArgs e)
        {
            setOperation(operationType.multiply);
        }
      

        private void button15_Click(object sender, EventArgs e)
        {
            setOperation(operationType.sum);
        }

        private void button16_Click(object sender, EventArgs e) 
        {
            setOperation(operationType.divide);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            setOperation(operationType.subtract);
        }

      
    }




}
