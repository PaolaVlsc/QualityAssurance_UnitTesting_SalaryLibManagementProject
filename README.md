# SalaryLib C# Library
It combines functions related to age calculation, IBAN validation, salary computation, and more, to help manage financial and employee dat

# SalaryLib C# Library

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
  - [Overview](#overview)
  - [Testing the "Salary Lib" Library](#testing-the-salary-lib-library)

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

### Usage

The `SalaryLib` library can be incorporated into C# applications for convenient salary and employee-related calculations. To use it, simply include the library in your project and call the relevant methods with the required inputs. Please refer to the code and method descriptions for specific usage details.

## Part B: Unit Testing on SalaryLib

### SalaryLibUnitTests

### Overview

This repository contains a series of unit tests for the "Salary Lib" library. The "Salary Lib" library is designed to calculate salary-related information for employees based on various parameters such as qualifications, experience, and personal details.

### Testing the "Salary Lib" Library

The unit tests in this repository cover multiple aspects of the "Salary Lib" library, ensuring that the library's functions perform as expected. Here is a brief overview of the test methods:

1. **TestValidEmail**: Validates email addresses using a variety of test cases to check if they are correctly recognized as valid or invalid. It checks email formats, special characters, and domains.

2. **TestCheckIBAN**: Verifies IBAN (International Bank Account Number) validation, bank detection, and correctness for a range of input IBANs. It checks the validity of IBANs and detects the corresponding bank name.

3. **TestCalculateSalary**: Calculates gross salary and net income for employees based on their category, studies, work experience, and the number of children. The tests ensure the accuracy of the salary calculations for various employee scenarios.

4. **TestCalculateMK**: Determines the number of MK (military service years), excess years, excess months, and excess days for employees based on their birthdate and qualifications. The tests cover a wide range of cases.

5. **TestNonAdultChildren**: Checks the number of non-adult children based on their birthdates for different employees. The tests determine the count of non-adult children using their birthdate data.

6. **TestMaxNetIncome**: It creates test cases with sample employee data, calls the MaxNetIncome method, and checks whether the result matches the expected output.

![image](https://github.com/PaolaVlsc/QualityAssurance_UnitTesting_SalaryLibManagementProject/assets/87998374/cf46e375-1dc3-461d-9e59-f9dbf26eb28b)

![image](https://github.com/PaolaVlsc/QualityAssurance_UnitTesting_SalaryLibManagementProject/assets/87998374/de365b05-2a6b-4572-a45d-c9024de6cc7e)

![image](https://github.com/PaolaVlsc/QualityAssurance_UnitTesting_SalaryLibManagementProject/assets/87998374/e3c3d3bc-b976-440a-b52f-5d146404154e)

![image](https://github.com/PaolaVlsc/QualityAssurance_UnitTesting_SalaryLibManagementProject/assets/87998374/182f988f-f078-4f79-bbfc-79c8664ef9a1)
