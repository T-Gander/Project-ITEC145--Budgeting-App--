﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_ITEC145__Budgeting_App__
{
    internal class Buttons
    {
        static public BudgetSheet budgetForm;
        static public MainMenu menuForm;                                    //So the buttons class can keep track of forms
        static public CategoryFieldForm categoryFieldForm;
        static public BudgetSheetNameForm budgetSheetNameForm;

        private int _width;
        private int _height;
        private string _name;
        private Font _font;
        private string _text;
        private Size _size;
        private Point _location;
        public bool anyCategories = false;

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }


        public Buttons(int width, int height, string name, Font font, int locationx, int locationy)
        {
            string fullname = "";
            List<string> nameparts = new List<string>();
            nameparts.AddRange(name.Split(' '));

            foreach (string namepart in nameparts)
            {
                fullname += namepart;
            }

            _width = width;
            _height = height;
            _name = fullname;
            _font = font;
            _location = new Point(locationx - (_width / 2), locationy);
            _text = name;
        }

        public Button MakeButton(EventHandler clickHandler, List<Button> buttonList)         //Pain to figure this out
        {
            Button button = new Button();
            button.Name = _name;
            button.Font = _font;
            button.Text = _text;
            button.Size = new Size(_width, _height);
            button.Location = _location;
            button.Click += clickHandler;                           //Found this hint on stackoverflow
            buttonList.Add(button);
            return button;
        }

        public Button MakeButton(EventHandler clickHandler)         //Pain to figure this out (without adding to list)
        {
            Button button = new Button();
            button.Name = _name;
            button.Font = _font;
            button.Text = _text;
            button.Size = new Size(_width, _height);
            button.Location = _location;
            button.Click += clickHandler;                           //Found this hint on stackoverflow
            return button;
        }


        //Click events for initialized buttons

        public void doNothing_Click(object sender, EventArgs e)
        {
            //For testing
        }
        public void nameForm_Click(object sender, EventArgs e)
        {
            Buttons.budgetForm.name = true;
            Buttons.budgetForm.Text = Buttons.budgetSheetNameForm.txtBudgetName.Text;
            Buttons.budgetSheetNameForm.Close();
        }
        public void menuClose_Click(object sender, EventArgs e)     
        {
            Buttons.menuForm.Close();
        }
        public void openBudgetSheet_Click(object sender, EventArgs e)
        {
            Buttons.menuForm.Hide();
            BudgetSheet budgetSheet = new BudgetSheet();
            budgetSheet.Show();
        }
        public void addCategory_Click(object sender, EventArgs e)
        {
            CategoryFieldForm form = new CategoryFieldForm();
            form.Show();
        }
        public void addCategoryFieldForm_Click(object sender, EventArgs e)
        {
            //Add Category to budget sheet
            string CategoryName = Buttons.categoryFieldForm.txtCategoryName.Text;
            Category newCategory = new Category(CategoryName,ref budgetForm.lastLocation, ref anyCategories);
            Buttons.categoryFieldForm.Close();

        }
        public void cancelCategoryFieldForm_Click(object sender, EventArgs e)
        {
            Buttons.categoryFieldForm.Close();
        }

    }
}
