/*
 * Author: Velasco Paola
 * Date: 18 February 2022
 * Unit Test for "Salary Lib" 
 */


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SalaryLib;
using static SalaryLib.SalaryLib;


namespace SalaryLibUnitTests
{
    [TestClass]
    public class SalaryLibUnitTests
    {
        //1
        [TestMethod]
        public void TestValidEmail()
        {
            //Δημιουργία ενός αντικειμένου της κλάσης του dll που θέλουμε τα τεστάρουμε
            SalaryLib.SalaryLib salaryLib = new SalaryLib.SalaryLib();

            //Δημιουργία Περιπτώσεων Ελέγχου
            object[,] testcases =
            {
                {1, true, "cs161020@uniwa.gr"},
                {2, false, "paolavlsc170698@gmail.com"},
                {3, true, "xristoulakis_02makis@yahoo.org"},
                {4, true,"onle!234@meil.me"},
                {5, true, ".@iana.org"},
                {6, false, "Ima Fool@iana.org"},
                {7, true, "2343245#@ok.gr"},
                {8, true, "email@example..com."},
                {9, true, "email@123.123.123.123"},
                {10, true, "_______________@example.com"},
                {11, false, "email@example.co.jp"},
                {12, true, ".first.last@iana.org"}
            };

            //Αρχικοποίηση δείκτη περιπτώσεων ελέγχου
            int i = 0;
            bool failed = false;

            //Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            //Για κάθε περίπτωση ελέγχου, δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    //Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    //δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    Assert.AreEqual((bool)testcases[i, 1], salaryLib.validEMAIL((string)testcases[i, 2]));
                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0}\n \t Reason: {1} ", (int)testcases[i, 0], e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }

        //2
        [TestMethod]
        public void TestCheckIBAN()
        {
            // string IBAN, ref bool validIBAN, ref string bank

            //Δημιουργία ενός αντικειμένου της κλάσης του dll που θέλουμε τα τεστάρουμε
            SalaryLib.SalaryLib salaryLib = new SalaryLib.SalaryLib();

            //Δημιουργία Περιπτώσεων Ελέγχου
            object[,] testcases =
            {
                {1, "GR5002602070000610201620365",true, "Eurobank"},
                {2,"GR5002635235454367544364536",false, ""},
                {3,"GR1601101250000000012300695", true, "National Bank of Greece"},
                {4,"GR5601453552841349465656353", true, "Alpha Bank23" },
                {5,"GR5301146556946221684885386", true, "National Bank of Greece" },
                {6,"GR2001165367252351725889763",true, "National Bank of Greece" },
                {7,"GR2601466292141176874543142",true, "Alpha Bank" },
                {8,"EL4525342592358235",false,"Eurobank" },
                {9,"GR2901443615399651293811729", true, "Alpha Bank"},
                {10,"GR2101739757567455957413737", false, "" },
                {11,"32423dkjfsfsfsdf",false,"Alpha Bank" }
            };


            //Αρχικοποίηση δείκτη περιπτώσεων ελέγχου
            int i = 0;
            bool failed = false;

            //Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            //Για κάθε περίπτωση ελέγχου, δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    //Δήλωση ref μεταβλητών μεθόδου,
                    //προκειμένου να αποθηκευτούν οι τιμές που θα επιστρέψει η μέθοδος
                    bool ValidIBAN = false;
                    string bankName = "";

                    //Καλούμε την μέθοδο που θέλουμε να εξετάσουμε δίνοντας ως παραμέτρους τα
                    //στοιχεία της περίπτωσης ελέγχου,
                    //δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases,
                    //και ως ref τις μεταβλητές που δηλώσαμε
                    salaryLib.CheckIBAN((string)testcases[i, 1], ref ValidIBAN, ref bankName);

                    //Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τις τιμές
                    //που θέλουμε να συγκρίνουμε
                    Assert.AreEqual((bool)testcases[i, 2], ValidIBAN);
                    Assert.AreEqual((string)testcases[i, 3], bankName);
                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0}: {1} - {2} - {3}. \n \t Reason: {4} ", (int)testcases[i, 0], (string)testcases[i, 1], (bool)testcases[i, 2], (string)testcases[i, 3], e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }

        //3
        [TestMethod]
        public void TestCalculateSalary()
        {
            //  CalculateSalary(Employee employee, ref double grossSalary, ref double netIncome)

            // Employee  category, studies, workExperience, children   

            //Δημιουργία ενός αντικειμένου της κλάσης του dll που θέλουμε τα τεστάρουμε
            SalaryLib.SalaryLib salaryLib = new SalaryLib.SalaryLib();

            //Δημιουργία Περιπτώσεων Ελέγχου
            object[,] testcases =
            {
                {1, "PE", "PhD", 4, 2, 1634.00,1132.8516},
                {2, "PE","Χωρίς Μεταπτυχιακό",2,1,1201.00,845.0274},
                {3, "ΠΕ", "PhD", 5, 1,1614.00,1112.4036},
                {4, "ΠΕ", "Διδακτορικό", 4, 2,1634.00,1132.8516},
                {5, "ΤΕ", "PhD", 2, 3, 1542.00,1091.62413333333},
                {6, "TE", "Μεταπτυχιακό", 4, 2, 1327.00,934.0998},
                {7, "ΤΕ", "PhD", 1, 0, 1367.00,949.75},
                {8, "ΠΕ", "MSc", 3, 4, 1439.00,1043.27526666667},
                {9, "PE", "MSc", 7, 1, 1437.00,997.8138},
                {10, "TE", "Χωρίς Μεταπτυχιακό", 27, 2, 1822.00,1254.5628},
                {11, "ΤΕ", "Χωρίς Μεταπτυχιακό", 34, 2,2042.00,1295.2992},
                {12, "PE", "Μεταπτυχιακό", 28, 2, 2106.00,1333.5456},

                //Προσθήκη όλων των περιπτώσεων ελέγχου που αφορούν τη συγκεκριμένη testmethod
            };


            //Αρχικοποίηση δείκτη περιπτώσεων ελέγχου
            int i = 0;
            bool failed = false;

            //Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            //Για κάθε περίπτωση ελέγχου, δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    //Δήλωση ref μεταβλητών μεθόδου,
                    //προκειμένου να αποθηκευτούν οι τιμές που θα επιστρέψει η μέθοδος
                    double grossSalary = 0;
                    double netIncome = 0;

                    // Δημιουργία employee
                    SalaryLib.SalaryLib.Employee employee = new SalaryLib.SalaryLib.Employee();

                    // Αρχικοποίηση αντικειμένου employee
                    employee.category = (string)testcases[i, 1];
                    employee.studies = (string)testcases[i, 2];
                    employee.workExperience = (int)testcases[i, 3];
                    employee.children = (int)testcases[i, 4];


                    //Καλούμε την μέθοδο που θέλουμε να εξετάσουμε δίνοντας ως παραμέτρους τα
                    //στοιχεία της περίπτωσης ελέγχου,
                    //δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases,
                    //και ως ref τις μεταβλητές που δηλώσαμε
                    salaryLib.CalculateSalary(employee, ref grossSalary, ref netIncome);

                    //Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τις τιμές
                    //που θέλουμε να συγκρίνουμε

                    Assert.AreEqual(Math.Round((double)testcases[i, 5], 2), Math.Round(grossSalary, 2));
                    Assert.AreEqual(Math.Round((double)testcases[i, 6], 2), Math.Round(netIncome, 2));

                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0}: \n \t Reason: {1} ", (int)testcases[i, 0], e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }

        //4
        [TestMethod]
        public void TestCalculateMK()
        {
            //Δημιουργία ενός αντικειμένου της κλάσης του dll που θέλουμε τα τεστάρουμε
            SalaryLib.SalaryLib salaryLib = new SalaryLib.SalaryLib();

            //Δημιουργία Περιπτώσεων Ελέγχου
            object[,] testcases =
            {
                {1,"2020/02/22","PhD", 8, 0, 0, 3},
                {2,"2014/05/7","Μεταπτυχιακό", 6, 1, 9, 18},
                {3,"2012/9/23","Διδακτορικό", 11,1,5,2},
                {4,"1994/2/12","Χωρίς Μεταπτυχιακό", 15,0,0,13},
                {5,"2019/10/23","PhD",8,0,4,2 },
                {6,"2012/7/22","Χωρίς Μεταπτυχιακό", 5,1,7,3},
                {7,"1994/2/33","Χωρίς Μεταπτυχιακό", 11,3,4,5},
                {8,"2005/9/5","MSc", 11,0,5,20},
                {9,"2013/8/8","PhD", 11,0,6,17},
                {10,"2017/3/9","PhD",9,0,11,16},
                {11,"1995/1/1","Μεταπτυχιακό",16,1,1,24},
                {12,"1999/12/31","Μεταπτυχιακό",14,0,1,2}
            };

            //Αρχικοποίηση δείκτη περιπτώσεων ελέγχου
            int i = 0;
            bool failed = false;
            int MK = 0;
            int ExcessYears = 0;
            int ExcessMonths = 0;
            int ExcessDays = 0;
            //Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            //Για κάθε περίπτωση ελέγχου, δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {


                    salaryLib.CalculateMK((string)testcases[i, 1], (string)testcases[i, 2], ref MK, ref ExcessYears, ref ExcessMonths, ref ExcessDays);

                    Assert.AreEqual((int)testcases[i, 3], MK);
                    Assert.AreEqual((int)testcases[i, 4], ExcessYears);
                    Assert.AreEqual((int)testcases[i, 5], ExcessMonths);
                    Assert.AreEqual((int)testcases[i, 6], ExcessDays);

                }
                catch (Exception e)
                {
                    failed = true;
                    Console.WriteLine("Failed Test Case: {0} with data {1} - {2} - {3} - {4} - {5} - {6}\n \t Reason: {7} ", (int)testcases[i, 0], (string)testcases[i, 1], (string)testcases[i, 2], MK, ExcessYears, ExcessMonths, ExcessDays, e.Message);
                };
            };


            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }

        //5
        [TestMethod]
        public void TestNonAdultChildren()
        {
            // Δημιουργία πινάκων με ημερομηνίες παιδιών κάθε υπαλλήλου

            // πίνακας παιδιών υπάλληλου01
            string[] dobChildren01 = new string[] {
            "1991/10/28",
            "2020/12/01",
            "2015/3/2"
            };

            string[] dobChildren02 = new string[] {
            "1991/10/28",
            "2020/12/01",
            "1998/3/2"
            };

            string[] dobChildren03 = new string[]
            {
                "2020/01/20",
                "1995/08/18",
                "1993/10/4"
            };

            string[] dobChildren04 = new string[]
            {
                "2015/02/13"
            };

            string[] dobChildren05 = new string[]
            {
                "2019/02/18"
            };

            string[] dobChildren06 = new string[]
            {
                "2020/04/15",
                "1996/9/12"
            };
            string[] dobChildren07 = new string[]
            {
                "2003/03/7",
                "1990/7/3"
            };
            string[] dobChildren08 = new string[]
            {
                "2009/01/18",
                "1992/4/31",
                "2020/5/12"
            };
            string[] dobChildren09 = new string[]
            {
                "2000/06/23"
            };
            string[] dobChildren10 = new string[]
            {
                "2019/03/14",
                "1985/3/5"
            };
            string[] dobChildren11 = new string[]
            {
                "2012/6/7",
                "1999/12/3",
                "2019/03/14",
                "1980/2/5"
            };
            //Δημιουργία ενός αντικειμένου της κλάσης του dll που θέλουμε τα τεστάρουμε 
            SalaryLib.SalaryLib salaryLib = new SalaryLib.SalaryLib();

            //Δημιουργία Περιπτώσεων Ελέγχου
            object[,] testcases =
            {
                { 1, dobChildren01, 2},
                { 2, dobChildren02, 1},
                { 3, dobChildren03, 1},
                { 4, dobChildren04, 1},
                { 5, dobChildren05, 1},
                { 6, dobChildren06, 1},
                { 7, dobChildren07, 0},
                { 8, dobChildren08, 2},
                { 9, dobChildren09, 0},
                { 10, dobChildren10, 1},
                { 11, dobChildren11, 2}
           };

            //Αρχικοποίηση δείκτη περιπτώσεων ελέγχου
            int i = 0;
            bool failed = false;

            //Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            //Για κάθε περίπτωση ελέγχου, δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    //Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    //δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    Assert.AreEqual((int)testcases[i, 2], salaryLib.NonAdultChildren((string[])testcases[i, 1]));
                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0} \n \t Reason: {1} ", (int)testcases[i, 0], e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }

        //6
        [TestMethod]
        public void TestMaxNetIncome()
        {

            const string msg1 = "Λάθος υπολογισμός μέγιστης τιμής.";

            //Δημιουργία ενός αντικειμένου της κλάσης του dll που θέλουμε τα τεστάρουμε
            SalaryLib.SalaryLib salaryLib = new SalaryLib.SalaryLib();


            // Δημιουργία δεδομένων για τις περιπτώσεις ελέγχου 
            Employee[] arrayEmployee1 = new Employee[]
            {
                 new Employee("PE", "PhD", 4, 2),   // 1132.8516
                 new Employee("ΠΕ", "Χωρίς Μεταπτυχιακό", 2, 1) //845.0274
            };

            Employee[] arrayEmployee2 = new Employee[]
            {
                 new Employee("PE", "PhD", 5, 1),   // 1112.4036
                 new Employee("ΠΕ", "Διδακτορικό", 4, 2) //1132.8516
            };

            Employee[] arrayEmployee3 = new Employee[]
            {
                 new Employee("TE", "PhD", 2, 3), //1091.62413333333
                 new Employee("ΤΕ", "Μεταπτυχιακό", 4, 2) //  934.0998
            };

            Employee[] arrayEmployee4 = new Employee[]
            {
                 new Employee("ΤΕ", "PhD", 1, 0), //949.75
                 new Employee("ΠΕ", "MSc", 3, 4) // 1043.27526666667
            };

            Employee[] arrayEmployee5 = new Employee[]
            {
                 new Employee("PE", "MSc", 3, 2), //997.8138
                 new Employee("ΤΕ", "Χωρίς Μεταπτυχιακό", 27, 2) // 1254.5628
            };

            Employee[] arrayEmployee6 = new Employee[]
            {
                 new Employee("ΤΕ", "Χωρίς Μεταπτυχιακό", 34, 2), // 1295.2992
                 new Employee("ΠΕ", "Μεταπτυχιακό", 28, 2) // 1333.5456
            };

            //Δημιουργία Περιπτώσεων Ελέγχου
            object[,] testcases =
            {
                {1, arrayEmployee1, 1132.8516, msg1},
                {2, arrayEmployee2, 1132.8516, msg1},
                {3, arrayEmployee3, 1091.62413333333, msg1},
                {4, arrayEmployee4, 1043.28,msg1 },
                {5, arrayEmployee5, 1254.5628 , msg1},
                {6, arrayEmployee6, 1333.5456, msg1 }
                //Προσθήκη όλων των περιπτώσεων ελέγχου που αφορούν τη συγκεκριμένη testmethod
            };

            //Αρχικοποίηση δείκτη περιπτώσεων ελέγχου
            int i = 0;
            bool failed = false;

            //Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            //Για κάθε περίπτωση ελέγχου, δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    //Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    //δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    Assert.AreEqual(Math.Round((double)testcases[i, 2], 2), Math.Round(salaryLib.MaxNetIncome((Employee[])testcases[i, 1]), 2));

                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ", (int)testcases[i, 0], (string)testcases[i, 3], e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }

    }
}
