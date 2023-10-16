/*
 * Author: Velasco Paola
 * Date: 18 February 2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Numerics;

namespace SalaryLib
{
    public class SalaryLib
    {

        public int CalculateAge(DateTime p_Dob)
        {
            // Method to Calculate age from Date of Birth in C#
            DateTime Today = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(p_Dob).Ticks).Year - 1;
            DateTime PastYearDate = p_Dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Today)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Today)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Today.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Today.Subtract(PastYearDate).Hours;
            int Minutes = Today.Subtract(PastYearDate).Minutes;
            int Seconds = Today.Subtract(PastYearDate).Seconds;

            return Years;
        }


        // Δημιουργία struct Employee
        public struct Employee
        {

            // Δήλωση μεταβλητών μέλη 
            public string category { get; set; }    // τιμές ΠΕ/PE ή ΤΕ/ΤΕ
            public string studies;          // τιμές Χωρίς Μεταπτυχιακό/NoMSc, Μεταπτυχιακό/MSc, Διδακτορικό/PhD
            public int workExperience;      // τιμές 0<=workExperience<=38
            public int children;            // τιμές 0<=children<=6

            // Δήλωση constructor 
            public Employee(string category, string studies, int workExperience, int children)
            {
                this.category = category;
                this.studies = studies;
                this.workExperience = workExperience;
                this.children = children;

            }

        }

        // Δημιουργία μεθόδου 1 validEmail() για τον έλεγχο του email 
        public bool validEMAIL(string email)
        {
            // Έλεγχος αν είναι άδειο το string
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }

        }

        // Δημιουργία μεθόδου 2 εγκυρότητας IBAN για ελληνίκό τραπεζικό λογαριασμό 
        public void CheckIBAN(string IBAN, ref bool validIBAN, ref string bank)
        {
            string iban = IBAN;
            string ibanCountryCode = null;
            string ibanCodeCheck = null;
            string bankCode = null;
            string ibanProcessed = null;
            BigInteger ibanNumber = 0;
            BigInteger result = 0;


            // Έλεγχος αν είναι άδειο το string
            if (string.IsNullOrWhiteSpace(iban))
            {
                validIBAN = false;
            }
            else
            {
                // Έλεγχος αν string έχει μήκος 27 
                if (iban.Length == 27)
                {
                    // Έλεγχος αν ανήκει σε ελληνική τράπεζα
                    ibanCountryCode = iban.Substring(0, 2); ; // Λήψη χαρακτήρων των GR 

                    // έλεγχος αν είναι GR
                    if (!ibanCountryCode.Equals("GR"))
                    {
                        validIBAN = false;
                    }
                    else
                    {
                        // Μετατροπή το GR σε αριθμούς 1627
                        ibanCountryCode = "1627";

                        ibanCodeCheck = iban.Substring(2, 2);   // Λήψη χαρακτήρων για ψηφία ελέγχου 

                        // επεξεργασία ΙΒΑΝ για έλεγχο 
                        ibanProcessed = iban.Substring(4) + ibanCountryCode + ibanCodeCheck;

                        // Μετατροπή string σε int 
                        try
                        {
                            ibanNumber = BigInteger.Parse(ibanProcessed);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Unable to convert the string '{0}' to a BigInteger value.", ibanProcessed);
                        }

                        //  Διαίρεση με το 97 και το υπόλοιπο πρέπει να είναι 1 
                        result = ibanNumber % 97;

                        //  Διαίρεση με το 97 και το υπόλοιπο πρέπει να είναι 1 
                        result = ibanNumber % 97;
                        if (result != 1)
                        {
                            validIBAN = false;
                        }
                        else
                        {
                            validIBAN = true;

                            // Εύρεση σε ποια τράπεζα ανήκει. 
                            bankCode = iban.Substring(4, 3);   // Λήψη χαρακτήρων για κωδικό τράπεζας

                            // alpha bank: 014 
                            if (bankCode.Equals("014"))
                            {
                                bank = "Alpha Bank";
                            }// national bank of Greece: 011
                            else if (bankCode.Equals("011"))
                            {
                                bank = "National Bank of Greece";
                            } // eurobank
                            else if (bankCode.Equals("026"))
                            {
                                bank = "Eurobank";
                            }
                            else
                            {
                                bank = "N/A";
                            }
                        }
                    }
                }
                else
                {
                    validIBAN = false;
                }
            }
        }

        // Δημιουργία μεθόδου 3 Calculate Salary
        public void CalculateSalary(Employee employee, ref double grossSalary, ref double netIncome)
        {

            string categoryEmployee = employee.category;
            string studiesEmployee = employee.studies;
            int workExperienceEmployee = employee.workExperience;
            int childrenEmployee = employee.children;

            double minimumWagePE = 1092;
            double minimumWageTE = 1037;
            double minimumWage = 0;

            int j = 2;
            int i = 0;


            // 1. Υπολογισμός βασικού μισθού
            for (i = 0; i < 38; i += 2)
            {
                if (workExperienceEmployee >= i && workExperienceEmployee < j)
                {
                    // Έλεγχος αν είναι PE
                    if (categoryEmployee.Equals("PE") || categoryEmployee.Equals("ΠΕ"))
                    {
                        minimumWage = minimumWagePE;
                    } // Έλεγχος αν είναι TE
                    else if (categoryEmployee.Equals("ΤΕ") || categoryEmployee.Equals("TE"))
                    {
                        minimumWage = minimumWageTE;
                    }
                    break;
                }
                else
                {
                    j = j + 2;

                    // Έλεγχος αν είναι PE
                    if (categoryEmployee.Equals("PE") || categoryEmployee.Equals("ΠΕ"))
                    {
                        minimumWagePE += 59;
                    } // Έλεγχος αν είναι TE
                    else if (categoryEmployee.Equals("ΤΕ") || categoryEmployee.Equals("TE"))
                    {
                        minimumWageTE += 55;

                    }
                }
            }

            // Έλεγχος πτυχίου που έχει, αλλιώς ξέρουμε by default ότι είναι χωρίς μεταπτυχιακό
            if (studiesEmployee.Equals("Μεταπτυχιακό") || studiesEmployee.Equals("MSc"))
            {
                // Έλεγχος αν είναι PE
                if (categoryEmployee.Equals("PE") || categoryEmployee.Equals("ΠΕ"))
                {
                    minimumWage += 2 * 59;
                } // Έλεγχος αν είναι TE
                else if (categoryEmployee.Equals("ΤΕ") || categoryEmployee.Equals("TE"))
                {
                    minimumWage += 2 * 55;
                }
            }
            else if (studiesEmployee.Equals("Διδακτορικό") || studiesEmployee.Equals("PhD"))
            {
                // Έλεγχος αν είναι PE
                if (categoryEmployee.Equals("PE") || categoryEmployee.Equals("ΠΕ"))
                {
                    minimumWage += 6 * 59;
                } // Έλεγχος αν είναι TE
                else if (categoryEmployee.Equals("ΤΕ") || categoryEmployee.Equals("TE"))
                {
                    minimumWage += 6 * 55;
                }
            }
            else if (studiesEmployee.Equals("Χωρίς Μεταπτυχιακό") || studiesEmployee.Equals("NoMSc"))
            {

            }
            //Console.WriteLine(minimumWage);

            // 2. Υπολογισμός Οικογενειακής παροχής και  Μικτές αποδοχές
            if (childrenEmployee != 0)
            {
                switch (childrenEmployee)
                {
                    case 1:
                        grossSalary = minimumWage + 50;
                        break;
                    case 2:
                        grossSalary = minimumWage + 70;
                        break;
                    case 3:
                        grossSalary = minimumWage + 120;
                        break;
                    case 4:
                        grossSalary = minimumWage + 170;
                        break;
                    case 5:
                        grossSalary = minimumWage + 240;
                        break;
                    default:
                        grossSalary = minimumWage + 310;
                        break;
                }
            }
            else
                grossSalary = minimumWage;
            //Console.WriteLine(grossSalary);

            // 3. Υπολογισμός κρατήσεων 
            double holdIka = grossSalary * 0.16;
            double holdOAED = grossSalary * 0.01;

            double hold = holdIka + holdOAED;
            //Console.WriteLine(hold);

            double katharesApodoxes = grossSalary - hold;
            double yearlyKatharesApodoxes = 12 * katharesApodoxes;
            //Console.WriteLine(yearlyKatharesApodoxes);

            double yearlyTax = 0;

            // 4. Υπολογισμός Φόρου 
            if (yearlyKatharesApodoxes <= 10000)
            {
                yearlyTax = 0.09 * yearlyKatharesApodoxes;
            }
            else if (yearlyKatharesApodoxes <= 20000)
            {
                yearlyTax = 0.22 * yearlyKatharesApodoxes;
            }
            else if (yearlyKatharesApodoxes <= 30000)
            {
                yearlyTax = 0.28 * yearlyKatharesApodoxes;
            }
            else if (yearlyKatharesApodoxes <= 40000)
            {
                yearlyTax = 0.36 * yearlyKatharesApodoxes;
            }
            else if (yearlyKatharesApodoxes > 40000)
            {
                yearlyTax = 0.44 * yearlyKatharesApodoxes;
            }
            else
            {
                // print error or something 
            }
            //Console.WriteLine(yearlyTax);


            int childlrenEmployeeTemp = 0;
            double yearlyFinalTax = 0;
            // αν είναι αρνητικός ο αριθμός παιδιών ;; 

            // 4.1 Υπολογισμός Φόρου έκπτωσης
            switch (childrenEmployee)
            {
                case 0:
                    yearlyFinalTax = yearlyTax - 777;
                    break;
                case 1:
                    yearlyFinalTax = yearlyTax - 810;
                    break;
                case 2:
                    yearlyFinalTax = yearlyTax - 900;
                    break;
                case 3:
                    yearlyFinalTax = yearlyTax - 1120;
                    break;
                case 4:
                    yearlyFinalTax = yearlyTax - 1340;
                    break;
                default:
                    childlrenEmployeeTemp = childrenEmployee - 4;
                    yearlyFinalTax = yearlyTax - (1340 + 220 * childlrenEmployeeTemp);
                    break;
            }
            //Console.WriteLine(yearlyFinalTax);

            // Φόρος το μήνα 
            double taxPerMonthFinal = yearlyFinalTax / 12;
            // Console.WriteLine(taxPerMonthFinal);

            // Καθαρό εισόδημα = μικτές αποδοχές - κρατήσεις - φόρος 
            netIncome = grossSalary - hold - taxPerMonthFinal;
            //Console.WriteLine(netIncome);

            /*Console.WriteLine("TESTCASEXX");
            Console.WriteLine(hold);
            Console.WriteLine(taxPerMonthFinal);
            Console.WriteLine(grossSalary);
            Console.WriteLine(netIncome);*/

        }


        // Δημιουργία μεθόδου 4 CalculateMK
        public void CalculateMK(string hiringDate, string studies, ref int MK, ref int ExcessYears, ref int ExcessMonths, ref int ExcessDays)
        {
            /**************Υπολογισμός χρόνος προϋπηρέσίας με ημερομηνία έως 2022/02/25 **************/

            DateTime dob = Convert.ToDateTime(hiringDate);
            // Method to Calculate age from given date in C#
            DateTime Today = Convert.ToDateTime("2022/02/25");
            int Years = new DateTime(Today.Subtract(dob).Ticks).Year - 1;
            DateTime PastYearDate = dob.AddYears(Years);
            int Months = 0;
            int i = 0;

            for (i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Today)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Today)
                {
                    Months = i - 1;
                    break;
                }
            }

            int Days = Today.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Today.Subtract(PastYearDate).Hours;
            int Minutes = Today.Subtract(PastYearDate).Minutes;
            int Seconds = Today.Subtract(PastYearDate).Seconds;


            int j = 2;
            MK = 1;

            /**************Υπολογισμός σε ποιο ΜΚ ανήκει**************/
            for (i = 0; i < 38; i += 2)
            {
                if (Years >= i && Years < j)
                {
                    string studiesEmployee = studies;
                    // Έλεγχος πτυχίου που έχει, αλλιώς ξέρουμε by default ότι είναι χωρίς μεταπτυχιακό
                    if (studiesEmployee.Equals("Μεταπτυχιακό") || studiesEmployee.Equals("MSc"))
                    {
                        MK += 2;
                    }
                    else if (studiesEmployee.Equals("Διδακτορικό") || studiesEmployee.Equals("PhD"))
                    {
                        MK += 6;
                    }
                    else if (studiesEmployee.Equals("Χωρίς Μεταπτυχιακό") || studiesEmployee.Equals("NoMSc"))
                    {
                        MK = MK;
                    }
                    break;
                }
                else
                {
                    j = j + 2;
                    MK += 1;
                }
            }

            /**************Υπολογισμός πόσο χρόνο ανήκει στο συγκεκριμένο ΜΚ**************/
            ExcessYears = Years % 2;
            ExcessMonths = Months;
            ExcessDays = Days;

        }

        // Count how many children are not adult
        public int NonAdultChildren(string[] ChildrenBirthday)
        {

            int numberOfNonAdults = 0;
            string dateOfBirth = null;
            int age = 0;

            // check each entry of the array  
            foreach (string entry in ChildrenBirthday)
            {
                dateOfBirth = entry;
                DateTime dob = Convert.ToDateTime(dateOfBirth);
                age = CalculateAge(dob);
                if (age < 18)
                {
                    numberOfNonAdults++;
                }
            }
            return numberOfNonAdults;
        }


        public double MaxNetIncome(Employee[] Empls)
        {
            double maxNetIncome = 0.0;
            double grossSalary = 0;
            double netIncome = 0;

            foreach (Employee emp in Empls)
            {
                // Κλήση της συνάρτησης CalculateSalary για να ανακτήσουμε το netIncome του κάθε employee
                CalculateSalary(emp, ref grossSalary, ref netIncome);

                // Υπολογισμός maxNetIncome 
                if (maxNetIncome < netIncome)
                {
                    maxNetIncome = netIncome;
                }
            }
            return maxNetIncome;
        }
    }
}
