﻿/*
 * Copyright (c) 2017 Matthew Wright.
 * Licensed under MIT License. See LICENSE.txt for further details.
 * 
 * This software should be distributed with a LICENSE.TXT file in the solution root.
 * Alternatively  you can find a copy of the license in the github repository:
 * https://github.com/wiganlatics/arithmetic-tester.
 * The MIT License text is also available at: https://choosealicense.com/licenses/mit/.
 */

using System;
using System.Windows.Forms;
using ArithmeticTester.Controllers;
using ArithmeticTester.Models;

namespace ArithmeticTester.Views
{
    /// <summary>
    /// Form to display a table of answers 
    /// </summary>
    public partial class frmAnswersTable : Form
    {
        /// <summary>
        /// The width of columns in the data grid.
        /// </summary>
        private const int colWidth = 30;
        /// <summary>
        /// The arithmetic operator table to display.
        /// </summary>
        private ArithmeticOperator arithmeticOperator;
        /// <summary>
        /// The divisor - only applicable for division operator.
        /// </summary>
        private byte divisor;

        /// <summary>
        /// Form Constructor.
        /// </summary>
        /// <param name="arithmeticOperator">Display table for this arithmetic operator.</param>
        /// <param name="divisor">Optional. Defaults to 1. The divisor to use if displaying division table.</param>
        public frmAnswersTable(ArithmeticOperator arithmeticOperator, byte divisor = 1)
        {
            InitializeComponent();

            this.arithmeticOperator = arithmeticOperator;
            this.divisor = divisor;

            Initialise();
        }

        /// <summary>
        /// Initialise the form.
        /// </summary>
        private void Initialise()
        {
            switch (arithmeticOperator)
            {
                case ArithmeticOperator.Add:
                    AdditionTable();
                    break;
                case ArithmeticOperator.Divide:
                    DivisionTable();
                    break;
                case ArithmeticOperator.Multiply:
                    MultiplicationTable();
                    break;
                case ArithmeticOperator.Subtract:
                    SubtractionTable();
                    break;
            }
        }

        /// <summary>
        /// Populates the table with the answers for addition questions.
        /// </summary>
        private void AdditionTable()
        {
            for (byte b = Arithmetic.minFactorValue; b <= Arithmetic.maxFactorValue; b++)
            {
                // Create columns and rows
                grdAnswersTable.Columns.Add(b.ToString(), b.ToString());
                grdAnswersTable.Columns[b - 1].Width = colWidth;
                grdAnswersTable.Rows.Add();
                grdAnswersTable.Rows[b - 1].HeaderCell.Value = b.ToString();

                // Populate cells
                for (byte c = Arithmetic.minFactorValue; c < b; c++)
                {
                    grdAnswersTable[c - 1, b - 1].Value = Arithmetic.Add(c, b);
                    grdAnswersTable[b - 1, c - 1].Value = grdAnswersTable[c - 1, b - 1].Value;
                }
                grdAnswersTable[b - 1, b - 1].Value = Arithmetic.Add(b, b);
            }
        }

        /// <summary>
        /// Populates the table with the answers for division questions.
        /// </summary>
        private void DivisionTable()
        {
            for (byte b = Arithmetic.minFactorValue; b <= Arithmetic.maxFactorValue; b++)
            {
                // Create columns and rows
                byte colHeader = (byte)Arithmetic.Multiply(b, divisor);
                grdAnswersTable.Columns.Add(colHeader.ToString(), colHeader.ToString());
                grdAnswersTable.Columns[b - 1].Width = colWidth;
                grdAnswersTable.Rows.Add();
                grdAnswersTable.Rows[b - 1].HeaderCell.Value = b.ToString();

                // Populate cells
                for (byte c = Arithmetic.minFactorValue; c < b; c++)
                {
                    if (colHeader % c == 0 && colHeader / c >= Arithmetic.minFactorValue && colHeader / c <= Arithmetic.maxFactorValue)
                    {
                        grdAnswersTable[b - 1, c - 1].Value = Arithmetic.Divide(colHeader, c).ToString();
                    }
                    else
                    {
                        grdAnswersTable[b - 1, c - 1].Value = "-";
                    }

                    byte curColHeader = byte.Parse(grdAnswersTable.Columns[c - 1].HeaderCell.Value.ToString());
                    if (curColHeader % b == 0 && curColHeader / b >= Arithmetic.minFactorValue && curColHeader / b <= Arithmetic.maxFactorValue)
                    {
                        grdAnswersTable[c - 1, b - 1].Value = Arithmetic.Divide(curColHeader, b).ToString();
                    }
                    else
                    {
                        grdAnswersTable[c - 1, b - 1].Value = "-";
                    }
                }

                grdAnswersTable[b - 1, b - 1].Value = divisor;
            }
        }

        /// <summary>
        /// Populates the table with the answers for multiplication questions.
        /// </summary>
        private void MultiplicationTable()
        {
            for (byte b = Arithmetic.minFactorValue; b <= Arithmetic.maxFactorValue; b++)
            {
                // Create columns and rows
                grdAnswersTable.Columns.Add(b.ToString(), b.ToString());
                grdAnswersTable.Columns[b - 1].Width = colWidth;
                grdAnswersTable.Rows.Add();
                grdAnswersTable.Rows[b - 1].HeaderCell.Value = b.ToString();

                // Populate cells
                for (byte c = Arithmetic.minFactorValue; c < b; c++)
                {
                    grdAnswersTable[c - 1, b - 1].Value = Arithmetic.Multiply(c, b);
                    grdAnswersTable[b - 1, c - 1].Value = grdAnswersTable[c - 1, b - 1].Value;
                }
                grdAnswersTable[b - 1, b - 1].Value = Arithmetic.Multiply(b, b);
            }
        }

        /// <summary>
        /// Populates the table with the answers for subtraction questions.
        /// </summary>
        private void SubtractionTable()
        {
            for (byte b = Arithmetic.minFactorValue; b <= Arithmetic.maxFactorValue; b++)
            {
                // Create columns and rows
                grdAnswersTable.Columns.Add(b.ToString(), b.ToString());
                grdAnswersTable.Columns[b - 1].Width = colWidth;
                grdAnswersTable.Rows.Add();
                grdAnswersTable.Rows[b - 1].HeaderCell.Value = b.ToString();

                // Populate cells
                for (byte c = Arithmetic.minFactorValue; c < b; c++)
                {
                    grdAnswersTable[c - 1, b - 1].Value = Arithmetic.Subtract(c, b);
                    grdAnswersTable[b - 1, c - 1].Value = Arithmetic.Subtract(b, c);
                }
                grdAnswersTable[b - 1, b - 1].Value = 0;
            }
        }

        /// <summary>
        /// Eventhandler for the form load event.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The parameters.</param>
        private void frmAnswersTable_Load(object sender, EventArgs e)
        {
            // Don't want any cells highlighted
            grdAnswersTable.ClearSelection();
        }
    }
}
