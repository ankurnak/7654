using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LinkedListExample
{
    public partial class Form1 : Form
    {
        private LinkedList<string> linkedList;
        public Form1()
        {
            InitializeComponent();
            linkedList = new LinkedList<string>();
            System.Windows.Forms.Button addButton = new System.Windows.Forms.Button();
            System.Windows.Forms.Button removeButton = new System.Windows.Forms.Button();
            System.Windows.Forms.Button displayButton = new System.Windows.Forms.Button();
            System.Windows.Forms.Button clearButton = new System.Windows.Forms.Button();
            System.Windows.Forms.Button countButton = new System.Windows.Forms.Button();
            System.Windows.Forms.TextBox textBox1 = new System.Windows.Forms.TextBox();
            System.Windows.Forms.ListBox listBox1 = new System.Windows.Forms.ListBox();

            // Настройки кнопок
            addButton.Text = "Add";
            addButton.Font = new Font("Arial", 10, FontStyle.Bold);
            addButton.BackColor = Color.Green;
            addButton.ForeColor = Color.White;

            removeButton.Text = "Remove";
            removeButton.Font = new Font("Arial", 10, FontStyle.Bold);
            removeButton.BackColor = Color.Red;
            removeButton.ForeColor = Color.White;

            displayButton.Text = "Display";
            displayButton.Font = new Font("Arial", 10, FontStyle.Bold);
            displayButton.BackColor = Color.Blue;
            displayButton.ForeColor = Color.White;

            clearButton.Text = "Clear";
            clearButton.Font = new Font("Arial", 10, FontStyle.Bold);
            clearButton.BackColor = Color.Yellow;
            clearButton.ForeColor = Color.Black;

            countButton.Text = "Count";
            countButton.Font = new Font("Arial", 10, FontStyle.Bold);
            countButton.BackColor = Color.Orange;
            countButton.ForeColor = Color.White;

            // Настройки текстового поля
            textBox1.Font = new Font("Arial", 10);

            // Настройки ListBox
            listBox1.Font = new Font("Arial", 10);

            // Размещение элементов управления на форме
            Controls.Add(addButton);
            Controls.Add(removeButton);
            Controls.Add(displayButton);
            Controls.Add(clearButton);
            Controls.Add(countButton);
            Controls.Add(textBox1);
            Controls.Add(listBox1);

            // Дополнительные настройки формы
            Text = "LinkedList Example";
            Size = new Size(400, 300);
        }

        private void add_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;

            if (!string.IsNullOrEmpty(inputText))
            {
                linkedList.AddLast(inputText);
                textBox1.Clear();
                listBox1.Items.Add(inputText); // Add the entry to listBox1
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (linkedList.Count > 0)
            {
                linkedList.RemoveFirst();
                listBox1.Items.RemoveAt(0); // Remove the first entry from listBox1
            }
        }

        private void display_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (string item in linkedList)
            {
                listBox1.Items.Add(item);
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            linkedList.Clear();
            listBox1.Items.Clear();
        }

        private void count_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Number of items in the linked list: " + linkedList.Count);
            listBox1.SelectedIndex = -1; // Clear the selection in listBox1
        }

    }
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public LinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            Count++;
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("LinkedList is empty.");
            }

            head = head.Next;

            if (head == null)
            {
                tail = null;
            }

            Count--;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
