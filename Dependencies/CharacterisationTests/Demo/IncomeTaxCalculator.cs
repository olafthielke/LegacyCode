using System;

namespace Dependencies.CharacterisationTests.Demo
{
    // TODO: Modify CalculateTax():
    // 1. Introduce a tax ceiling for married persons of $500,000.
    // In other words, if you're married you'll pay no more than $500,000 in income tax.
    // 2. Introduce a tax ceiling for unmarried persons of $1,000,000.
    // In other words, if you're unmarried you'll pay no more than $1,000,000 in income tax.
    // All other taxes must not change!

    public class IncomeTaxCalculator
    {
        public double CalculateTax(int income, int age, bool isMarried, int numberOfChildren)
        {
            double taxRate = 0.0;
            double deduction = 0.0;
            double childTaxCredit = 0.0;
            double incomeAdjustmentFactor = 1.0;
            double taxDue = 0.0;

            if (age < 25) deduction += 300;
            else if (age >= 25 && age <= 65) deduction += 1200;
            else deduction += 1700;

            if (isMarried) deduction += 2000;

            if (numberOfChildren > 0)
            {
                deduction += 1000 * numberOfChildren; // Base deduction per child
                if (isMarried) deduction += 500 * numberOfChildren;

                if (income < 50000)
                {
                    childTaxCredit = 500 * numberOfChildren;
                }
                else if (income >= 50000 && income <= 100000)
                {
                    childTaxCredit = 300 * numberOfChildren;
                }
                else
                {
                    childTaxCredit = 200 * numberOfChildren;
                    if (numberOfChildren >= 3) childTaxCredit += 500; // Bonus for large families
                }
            }

            if (age > 65 || isMarried) incomeAdjustmentFactor = 0.95;

            if (income <= 10000) taxRate = 0.05;
            else if (income > 10000 && income <= 50000) taxRate = 0.1;
            else if (income > 50000 && income <= 100000) taxRate = 0.2;
            else taxRate = 0.3;

            if (income > 100000 && numberOfChildren > 2) taxRate -= 0.02;

            double adjustedIncome = income * incomeAdjustmentFactor;
            double taxableIncome = adjustedIncome - deduction;
            if (taxableIncome < 0) taxableIncome = 0;

            taxDue = taxableIncome * taxRate;

            taxDue -= childTaxCredit;
            if (taxDue < 0) taxDue = 0;

            if (numberOfChildren >= 3 && isMarried && age > 50)
            {
                double specialFamilyDeduction = 1000;
                taxDue -= specialFamilyDeduction;
                if (taxDue < 0) taxDue = 0; // Ensure tax due isn't negative
            }

            if (income > 80000 && numberOfChildren == 1 && age < 30)
            {
                taxDue += 500;
            }

            return Math.Round(taxDue * 100) / 100;
        }
    }
}