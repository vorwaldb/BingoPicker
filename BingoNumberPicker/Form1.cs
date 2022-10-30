using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BingoNumberPicker
{
    public partial class frmBingoPicker : Form
    {
        List<int> bingoBnums = new List<int>();
        List<int> bingoInums = new List<int>();
        List<int> bingoNnums = new List<int>();
        List<int> bingoGnums = new List<int>();
        List<int> bingoOnums = new List<int>();

        Dictionary<int, Control> bingoBtextBoxes = new Dictionary<int, Control>();
        Dictionary<int, Control> bingoItextBoxes = new Dictionary<int, Control>();
        Dictionary<int, Control> bingoNtextBoxes = new Dictionary<int, Control>();
        Dictionary<int, Control> bingoGtextBoxes = new Dictionary<int, Control>();
        Dictionary<int, Control> bingoOtextBoxes = new Dictionary<int, Control>();

        int totalSum;
        bool isFull = false;

        public frmBingoPicker()
        {
            InitializeComponent();
            PopulateTextBoxDictionaries();
        }

        private void btnNewNumber_Click(object sender, EventArgs e)
        {
            string bingoNum = GetBingoNumber();

            if (isFull)
            {
                MessageBox.Show("Game Over.", "Bingo Picker Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                StartOver();
            }
            else
            {
                txtCurrentNumber.Text = bingoNum;
            }
        }

        private string GetBingoNumber()
        {
            Random randNumber = new Random();
            int newNum;
            bool isUsed = true;

            do
            {
                do
                {
                    newNum = randNumber.Next(0, 76);

                } while (newNum == 0 || newNum == 76);

                isUsed = CheckExistence(newNum);
                int total = CalculateListSums();
                if (total >= 2850)
                    isFull = true;

            } while (isUsed && !isFull);

                AddToArray(newNum);
                AddToTracker(newNum);
                return BingoNumber.CreateBingoNumber(newNum);
        }

        private void AddToTracker(int number)
        {
            if (number < 16)
            {
                foreach (var item in bingoBtextBoxes)
                {
                    if (item.Key == number)
                    {
                        item.Value.Text = number.ToString();
                        break;
                    }
                }
            }
            else if (number < 31)
            {
                foreach (var item in bingoItextBoxes)
                {
                    if (item.Key == number)
                    {
                        item.Value.Text = number.ToString();
                        break;
                    }
                }
            }
            else if (number < 46)
            {
                foreach (var item in bingoNtextBoxes)
                {
                    if (item.Key == number)
                    {
                        item.Value.Text = number.ToString();
                        break;
                    }
                }
            }
            else if (number < 61)
            {
                foreach (var item in bingoGtextBoxes)
                {
                    if (item.Key == number)
                    {
                        item.Value.Text = number.ToString();
                        break;
                    }
                }
            }
            else 
            {
                foreach (var item in bingoOtextBoxes)
                {
                    if (item.Key == number)
                    {
                        item.Value.Text = number.ToString();
                        break;
                    }
                }
            }

        }

        private bool CheckExistence(int number)
        {
            foreach (int num in bingoBnums)
            {
                if (num == number)
                {
                    return true;
                }
            }

            foreach (int num in bingoInums)
            {
                if (num == number)
                {
                    return true;
                }
            }

            foreach (int num in bingoNnums)
            {
                if (num == number)
                {
                    return true;
                }
            }

            foreach (int num in bingoGnums)
            {
                if (num == number)
                {
                    return true;
                }
            }

            foreach (int num in bingoOnums)
            {
                if (num == number)
                {
                    return true;
                }
            }

            return false;
        }

        private void AddToArray(int number)
        {
            if (number < 16)
                bingoBnums.Add(number);
            else if (number < 31)
                bingoInums.Add(number);
            else if (number < 46)
                bingoNnums.Add(number);
            else if (number < 61)
                bingoGnums.Add(number);
            else
                bingoOnums.Add(number);
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("Are you sure you want to start a new game?", "Bingo Picker Pro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (button == DialogResult.Yes)
            {
                StartOver();
            }
        }

        private void PopulateTextBoxDictionaries()
        {
            //Textboxes for letter B
            bingoBtextBoxes.Clear();
            bingoBtextBoxes.Add(1, txtB1);
            bingoBtextBoxes.Add(2, txtB2);
            bingoBtextBoxes.Add(3, txtB3);
            bingoBtextBoxes.Add(4, txtB4);
            bingoBtextBoxes.Add(5, txtB5);
            bingoBtextBoxes.Add(6, txtB6);
            bingoBtextBoxes.Add(7, txtB7);
            bingoBtextBoxes.Add(8, txtB8);
            bingoBtextBoxes.Add(9, txtB9);
            bingoBtextBoxes.Add(10, txtB10);
            bingoBtextBoxes.Add(11, txtB11);
            bingoBtextBoxes.Add(12, txtB12);
            bingoBtextBoxes.Add(13, txtB13);
            bingoBtextBoxes.Add(14, txtB14);
            bingoBtextBoxes.Add(15, txtB15);

            //Textboxes for letter I
            bingoItextBoxes.Clear();
            bingoItextBoxes.Add(16, txtI16);
            bingoItextBoxes.Add(17, txtI17);
            bingoItextBoxes.Add(18, txtI18);
            bingoItextBoxes.Add(19, txtI19);
            bingoItextBoxes.Add(20, txtI20);
            bingoItextBoxes.Add(21, txtI21);
            bingoItextBoxes.Add(22, txtI22);
            bingoItextBoxes.Add(23, txtI23);
            bingoItextBoxes.Add(24, txtI24);
            bingoItextBoxes.Add(25, txtI25);
            bingoItextBoxes.Add(26, txtI26);
            bingoItextBoxes.Add(27, txtI27);
            bingoItextBoxes.Add(28, txtI28);
            bingoItextBoxes.Add(29, txtI29);
            bingoItextBoxes.Add(30, txtI30);

            //Textboxes for letter N
            bingoNtextBoxes.Clear();
            bingoNtextBoxes.Add(31, txtN31);
            bingoNtextBoxes.Add(32, txtN32);
            bingoNtextBoxes.Add(33, txtN33);
            bingoNtextBoxes.Add(34, txtN34);
            bingoNtextBoxes.Add(35, txtN35);
            bingoNtextBoxes.Add(36, txtN36);
            bingoNtextBoxes.Add(37, txtN37);
            bingoNtextBoxes.Add(38, txtN38);
            bingoNtextBoxes.Add(39, txtN39);
            bingoNtextBoxes.Add(40, txtN40);
            bingoNtextBoxes.Add(41, txtN41);
            bingoNtextBoxes.Add(42, txtN42);
            bingoNtextBoxes.Add(43, txtN43);
            bingoNtextBoxes.Add(44, txtN44);
            bingoNtextBoxes.Add(45, txtN45);

            //Textboxes for letter G
            bingoGtextBoxes.Clear();
            bingoGtextBoxes.Add(46, txtG46);
            bingoGtextBoxes.Add(47, txtG47);
            bingoGtextBoxes.Add(48, txtG48);
            bingoGtextBoxes.Add(49, txtG49);
            bingoGtextBoxes.Add(50, txtG50);
            bingoGtextBoxes.Add(51, txtG51);
            bingoGtextBoxes.Add(52, txtG52);
            bingoGtextBoxes.Add(53, txtG53);
            bingoGtextBoxes.Add(54, txtG54);
            bingoGtextBoxes.Add(55, txtG55);
            bingoGtextBoxes.Add(56, txtG56);
            bingoGtextBoxes.Add(57, txtG57);
            bingoGtextBoxes.Add(58, txtG58);
            bingoGtextBoxes.Add(59, txtG59);
            bingoGtextBoxes.Add(60, txtG60);

            //Textboxes for letter O
            bingoOtextBoxes.Clear();
            bingoOtextBoxes.Add(61, txtO61);
            bingoOtextBoxes.Add(62, txtO62);
            bingoOtextBoxes.Add(63, txtO63);
            bingoOtextBoxes.Add(64, txtO64);
            bingoOtextBoxes.Add(65, txtO65);
            bingoOtextBoxes.Add(66, txtO66);
            bingoOtextBoxes.Add(67, txtO67);
            bingoOtextBoxes.Add(68, txtO68);
            bingoOtextBoxes.Add(69, txtO69);
            bingoOtextBoxes.Add(70, txtO70);
            bingoOtextBoxes.Add(71, txtO71);
            bingoOtextBoxes.Add(72, txtO72);
            bingoOtextBoxes.Add(73, txtO73);
            bingoOtextBoxes.Add(74, txtO74);
            bingoOtextBoxes.Add(75, txtO75);
        }

        private void StartOver()
        {
            bingoBnums.Clear();
            bingoInums.Clear();
            bingoNnums.Clear();
            bingoGnums.Clear();
            bingoOnums.Clear();

            foreach (var item in bingoBtextBoxes)
            {
                item.Value.Text = string.Empty;
            }

            foreach (var item in bingoItextBoxes)
            {
                item.Value.Text = string.Empty;
            }

            foreach (var item in bingoNtextBoxes)
            {
                item.Value.Text = string.Empty;
            }

            foreach (var item in bingoGtextBoxes)
            {
                item.Value.Text = string.Empty;
            }

            foreach (var item in bingoOtextBoxes)
            {
                item.Value.Text = string.Empty;
            }

            txtCurrentNumber.Text = string.Empty;
            isFull = false;
        } 

        private int CalculateListSums()
        {
            totalSum = AddListIntItems(bingoBnums) + AddListIntItems(bingoInums) + AddListIntItems(bingoNnums) + AddListIntItems(bingoGnums) + AddListIntItems(bingoOnums);
            return totalSum;
        }

        private int AddListIntItems(List<int> numList)
        {
            int total = 0;

            foreach (var num in numList)
            {
                total += num;
            }

            return total;
        }

    }
}
