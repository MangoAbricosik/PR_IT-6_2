using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_IT_6_2
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    int maxV = int.MinValue, maxVSec = int.MinValue, minV = int.MaxValue, minVSec = int.MaxValue;        int firstV = 0, twoV = 0;
    int i = 0, j = 0;                                                                                    int threeV = 0, fourV = 0;
    int value = -101, valueSec = -101, cout = 0, coutSec = 0, coutTh = 0;

    public void DefAll()
    {
      maxV = int.MinValue; maxVSec = int.MinValue; minV = int.MaxValue; minVSec = int.MaxValue;          firstV = 0; twoV = 0;
      i = 0; j = 0;                                                                                      threeV = 0; fourV = 0;
      value = -101; valueSec = -101; cout = 0; coutSec = 0;
    }
    private void button1_Click(object sender, EventArgs e)
    {
      button2.Hide();
      DefAll();

      dataGridView1.RowCount = 5;
      dataGridView1.ColumnCount = 5;

      int[,] massiv = new int[5, 5];

      Random rand = new Random();

      for (int i = 0; i < 5; i++)
      {
        for (int j = 0; j < 5; j++)
        {
          massiv[i, j] = rand.Next(-100, 100);
          dataGridView1.Rows[i].Cells[j].Value = Convert.ToString(massiv[i, j]);
        }
      }

      RadC(massiv);
    }

    public void RadC(int [,] massiv)
    {
      int n = 0;

      if (radioButton1.Checked) n = 2;
      if (radioButton2.Checked) n = 3;
      if (radioButton3.Checked) n = 4;
      if (radioButton4.Checked) n = 5;
      if (radioButton5.Checked) n = 6;

      if (n == 0) label1.Text = "Выберетие вариант!";

      Start(n , massiv);
    }
    public void Start(int n, int[,] massiv)
    {
      switch (n)
      {
        case 2:
          DefAll();
          j = 4;
          for (i = 0; i <= 4; i++)
          {
              if (maxV < massiv[i, j])
              maxV = massiv[i, j];
              j--;
          }
          label1.Text = "Максимальный элемент побочной диагонили = " + maxV.ToString();
          break;
        case 3:
          DefAll();
          for (i = 0; i < 5; i++)
          {
            for (j = 0; j < 5; j++)
            {
              if (minV > massiv[i,j])
              {
                minV = massiv[i, j];
                firstV = i; twoV = j;
              }
              if (maxV < massiv[i,j])
              {
                maxV = massiv[i, j];
                threeV = i; fourV = j;
              }
            }
          }
          button2.Show();
          label1.Text = "Максиманое значение - " + maxV.ToString() + " Минимальное значение - " + minV.ToString();
          break;
        case 4:
          DefAll();
          for (int i = 0; i < 5; i++)
          {
            for (int j = 0; j < 5; j++)
            {
              if (minV > massiv[i, j])
              {
                minV = massiv[i, j];
                firstV = i; twoV = j;
              }
            }
            if (value < minV)
            {
              value = minV;
              threeV = firstV; fourV = twoV;
            }
            dataGridView1.Rows[firstV].Cells[twoV].Style.BackColor = Color.DarkBlue;

            minV = int.MaxValue;
          }
          dataGridView1.Rows[threeV].Cells[fourV].Style.BackColor = Color.DarkRed;
          break;
        case 5:
          DefAll();
          for (int i = 0; i < 5; i++)
          {
            for (int j = 0; j < 5; j++)
            {
              coutTh += massiv[i, j];
            }
            if (maxV < coutTh)
            {
              maxV = coutTh;
              cout = i;
            }
            if (minV > coutTh)
            {
              minV = coutTh;
              coutSec = i;
            }
            coutTh = 0;
          }
          label1.Text = "Максимальная строка = " + cout.ToString() + " Минимальная строка = " + coutSec.ToString();
          break;
        case 6:
          DefAll();
          for (int i = 1; i < 5; i++)
          {
            for (int j = 5 - i; j < 5; j++)
            {
              cout += massiv[i, j];
            }
          }
          label1.Text = "Сумма элементов ниже побочной диагонали - " + cout.ToString();
          break;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      dataGridView1.Rows[firstV].Cells[twoV].Value = Convert.ToString(maxV);
      dataGridView1.Rows[threeV].Cells[fourV].Value = Convert.ToString(minV);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      button2.Hide();
    }
  }
}
