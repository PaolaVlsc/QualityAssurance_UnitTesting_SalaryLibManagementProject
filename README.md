# SalaryLib C# Library

It combines functions related to age calculation, IBAN validation, salary computation, and more, to help manage financial and employees.

**Table of Contents**

- [Part A: Salary Management Lib](#part-a-salary-management-lib)
  - [Overview](#overview)
  - [Methods and Features](#methods-and-features)
    - [CalculateAge Method](#calculateage-method)
    - [Employee Struct](#employee-struct)
    - [validEMAIL Method](#validemail-method)
    - [CheckIBAN Method](#checkiban-method)
    - [CalculateSalary Method](#calculatesalary-method)
    - [CalculateMK Method](#calculatemk-method)
    - [NonAdultChildren Method](#nonadultchildren-method)
    - [MaxNetIncome Method](#maxnetincome-method)
  - [Usage](#usage)
- [Part B: Unit Testing on SalaryLib](#part-b-unit-testing-on-salarylib)
  - [SalaryLibUnitTests](#salarylibunittests)
  - [Unit Tests](#testing-the-salary-lib-library)
- [How To Run](#how-to-run)
- [Author](#author)
- [Extras](#extras)

## Part A: Salary Management Lib

This C# code, `SalaryLib.cs`, is a class file for a library named "SalaryLib" that provides various functions and methods related to salary calculations, age calculations, and more. Here's an explanation of its main components and methods:

### Overview

The `SalaryLib` is a C# library that provides a collection of methods for various salary and employee-related calculations. It offers functionalities to calculate age, validate email addresses, check Greek IBANs, determine an employee's salary scale, and more. This library is designed to be used in C# applications where such calculations are required.

### Methods and Features

#### CalculateAge Method

- Calculate a person's age based on their date of birth.
- **Input:** `DateTime p_Dob`
- **Output:** Returns the person's age as an integer.

#### Employee Struct

- Defines a custom struct called `Employee` to represent employee information.
- Contains properties for the employee's category, studies, work experience, and the number of children.

#### validEMAIL Method

- Validate an email address using regular expressions and other checks.
- **Input:** An email address as a string.
- **Output:** Returns `true` if the email is valid, `false` if not.

#### CheckIBAN Method

- Validate a Greek IBAN (International Bank Account Number).
- Check the IBAN's format and calculate whether it is valid.
- Determine which Greek bank the IBAN belongs to and return the bank's name.

#### CalculateSalary Method

- Calculate an employee's gross and net salary based on their category, studies, work experience, and the number of children.
- **Input:** `Employee` object, `grossSalary`, and `netIncome` as output variables.

#### CalculateMK Method

- Calculate the employee's Salary scale.
- **Input:** Employee's hiring date, studies.
- **Output:** MK, excess years, excess months, and excess days.

#### NonAdultChildren Method

- Count the number of non-adult children based on their birthdates.
- **Input:** Array of children's birthdates as strings.
- **Output:** Returns the count of children under 18 years old.

#### MaxNetIncome Method

- Calculate the maximum net income among an array of employees.
- **Input:** Array of `Employee` objects.
- **Output:** Returns the maximum net income.

## Part B: Unit Testing on SalaryLib

### SalaryLibUnitTests

Contains a series of unit tests for the "Salary Lib" library.

### Testing the "Salary Lib" Library

The unit tests in this repository cover multiple aspects of the "Salary Lib" library, ensuring that the library's functions perform as expected. Here is a brief overview of the test methods:

1. **TestValidEmail**: Validates email addresses using a variety of test cases to check if they are correctly recognized as valid or invalid. It checks email formats, special characters, and domains.

2. **TestCheckIBAN**: Verifies IBAN (International Bank Account Number) validation, bank detection, and correctness for a range of input IBANs. It checks the validity of IBANs and detects the corresponding bank name.

3. **TestCalculateSalary**: Calculates gross salary and net income for employees based on their category, studies, work experience, and the number of children. The tests ensure the accuracy of the salary calculations for various employee scenarios.

4. **TestCalculateMK**: Determines the number of MK (military service years), excess years, excess months, and excess days for employees based on their birthdate and qualifications. The tests cover a wide range of cases.

5. **TestNonAdultChildren**: Checks the number of non-adult children based on their birthdates for different employees. The tests determine the count of non-adult children using their birthdate data.

6. **TestMaxNetIncome**: It creates test cases with sample employee data, calls the MaxNetIncome method, and checks whether the result matches the expected output.

## How to run

1. Open solution in Visual Studio 2022
2. Run Tests All
3. Results
<div align="center">
  <img src="https://github.com/PaolaVlsc/QualityAssurance_UnitTesting_SalaryLibManagementProject/assets/87998374/182f988f-f078-4f79-bbfc-79c8664ef9a1" alt="Image 4" width="70%">
</div>

## Author

This project was written by Velasco Paola 2022

## Extras

Report Paper in greek: [Report Paper](https://github.com/PaolaVlsc/QualityAssurance_UnitTesting_SalaryLibManagementProject/blob/master/Extras/project2022_lab_final.pdf)

Εκφώνηση: [here](https://github.com/PaolaVlsc/QualityAssurance_UnitTesting_SalaryLibManagementProject/blob/master/Extras/%CE%95%CE%BA%CF%86%CF%8E%CE%BD%CE%B7%CF%83%CE%B7%20%CE%95%CF%81%CE%B3%CE%B1%CF%83%CF%84.%20%CE%95%CF%81%CE%B3..pdf)
