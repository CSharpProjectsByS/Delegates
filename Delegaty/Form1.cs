using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delegaty
{
    public partial class SortTypeGroupBox : Form
    {
        private List<ComplexNumber<float>> complexNumbers = new List<ComplexNumber<float>>();
        
        ComplexNumberListService<float> cNumberListService =
            new ComplexNumberListService<float>(new AdderComplexNumber<float>());

        private bool isAddOneValue = true;
        private bool isAddMoreValue = false;

        private bool isSortAscending = true;
        private bool isSortDescending = false;



        public SortTypeGroupBox()
        {
            InitializeComponent();
        }

        private void SortTypeGroupBox_Load(object sender, EventArgs e)
        {

        }

        private void AddOneByOneButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AddOneByOneButton.Checked)
            {
                isAddOneValue = true;
                isAddMoreValue = false;
            }
        }

        private void AddRandomValuesButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AddRandomValuesButton.Checked)
            {
                isAddMoreValue = true;
                isAddOneValue = false;
            }
        }

        private void SortAscendingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SortAscendingRadioButton.Checked)
            {
                isSortAscending = true;
                isSortDescending = false;
            }
        }

        private void SortDescendingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SortDescendingRadioButton.Checked)
            {
                isSortDescending = true;
                isSortAscending = false;
            }
        }

        private void AddComplexNumberButton_Click(object sender, EventArgs e)
        {
            AddValuesToListComlexNumber();
            showComplexNumbers();
        }

        private void AddValuesToListComlexNumber( )
        {
            if (isAddOneValue)
            {
                complexNumbers = cNumberListService.AddOneValue(complexNumbers, ReValueTextBox, 
                    ImValueTextBox);    
            }
            else if (isAddMoreValue)
            {
                complexNumbers = cNumberListService.AddMoreValue(complexNumbers, NumberOfValues);
            }
        }

        

        private void ResetTableButton_Click(object sender, EventArgs e)
        {
            complexNumbers.Clear();
            ComplexNumbersView.Items.Clear();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            sortComplexNumber();
            showComplexNumbers();
        }

        private void sortComplexNumber()
        {
            if (isSortAscending)
            {
                sortAscendingComplexNumbers();
            }   
            else if (isSortDescending)
            {
                sortDescendingComplexNumbers();
            }
        }

        private void sortAscendingComplexNumbers()
        {
              complexNumbers =  cNumberListService.sortAscendingDD.Invoke(complexNumbers,
                cNumberListService.comparisonTypeD);
        }

        private void sortDescendingComplexNumbers()
        {
            complexNumbers = cNumberListService.sortDescendingD(complexNumbers,
                cNumberListService.comparisonTypeD);
        }

        private void showComplexNumbers()
        {
            ComplexNumbersView.Items.Clear();
            ComplexNumbersView.Items.AddRange(complexNumbers.ToArray());
        }
    }
}
